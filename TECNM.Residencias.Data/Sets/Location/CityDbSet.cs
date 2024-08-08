using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Sets.Common;

namespace TECNM.Residencias.Data.Sets.Location
{
    public sealed class CityDbSet : DbSet<City>
    {
        private static readonly Dictionary<long, IReadOnlyList<City>> _citiesByState = new();
        private static readonly Dictionary<long, City> _cities = new();

        public CityDbSet(IDbContext context) : base(context)
        {
        }

        public City GetCityById(long id)
        {
            City? city;
            if (_cities.TryGetValue(id, out city))
            {
                return city;
            }

            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, state_id, name FROM loc_city WHERE id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = id;
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                city = HydrateObject(reader);
                _cities[city.Id] = city;
                return city;
            }

            throw new UnreachableException($"Illegal City Id: {id}");
        }

        public IReadOnlyList<City> GetCitiesByState(State state)
        {
            return GetCitiesByState(state.Id);
        }

        public IReadOnlyList<City> GetCitiesByState(long stateId)
        {
            if (_citiesByState.TryGetValue(stateId, out var cities))
            {
                return cities;
            }

            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, state_id, name FROM loc_city WHERE state_id = $p0 ORDER BY name";
            command.Parameters.Add("$p0", SqliteType.Integer).Value = stateId;
            using var reader = command.ExecuteReader();

            var result = new List<City>();
            while (reader.Read())
            {
                var city = HydrateObject(reader);
                result.Add(city);
                _cities[city.Id] = city;
            }

            _citiesByState[stateId] = result;
            return result;
        }

        public override bool Insert(City entity)
        {
            throw new NotImplementedException();
        }

        public override int Update(City entity)
        {
            throw new NotImplementedException();
        }

        public override int Delete(City entity)
        {
            throw new NotImplementedException();
        }

        public override bool InsertOrUpdate(City entity)
        {
            throw new NotImplementedException();
        }

        protected override City HydrateObject(IDataReader reader)
        {
            Debug.Assert(reader.FieldCount == 3);
            return new City
            {
                Id      = reader.GetInt64(0),
                StateId = reader.GetInt64(1),
                Name    = reader.GetString(2),
            };
        }
    }
}
