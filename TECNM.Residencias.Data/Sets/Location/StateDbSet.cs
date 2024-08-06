using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Sets.Common;

namespace TECNM.Residencias.Data.Sets.Location
{
    public sealed class StateDbSet : DbSet<State>
    {
        private static readonly Dictionary<long, IReadOnlyList<State>> _statesByCountry = new();
        private static readonly Dictionary<long, State> _states = new();

        public StateDbSet(IDbContext context) : base(context)
        {
        }

        public State GetStateById(long id)
        {
            State? state;
            if (_states.TryGetValue(id, out state))
            {
                return state;
            }

            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, country_id, name FROM state WHERE id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = id;
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                state = HydrateObject(reader);
                _states[state.Id] = state;
                return state;
            }

            throw new UnreachableException($"Illegal State Id: {id}");
        }

        public IReadOnlyList<State> GetStatesByCountry(Country country)
        {
            return GetStatesByCountry(country.Id);
        }

        public IReadOnlyList<State> GetStatesByCountry(long countryId)
        {
            if (_statesByCountry.TryGetValue(countryId, out var states))
            {
                return states;
            }

            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, country_id, name FROM state WHERE country_id = $p0 ORDER BY name";
            command.Parameters.Add("$p0", SqliteType.Integer).Value = countryId;
            using var reader = command.ExecuteReader();

            var result = new List<State>();
            while (reader.Read())
            {
                var state = HydrateObject(reader);
                result.Add(state);
                _states[state.Id] = state;
            }

            _statesByCountry[countryId] = result;
            return result;
        }

        public override bool Insert(State entity)
        {
            throw new NotSupportedException();
        }

        public override int Update(State entity)
        {
            throw new NotSupportedException();
        }

        public override int Delete(State entity)
        {
            throw new NotSupportedException();
        }

        public override bool InsertOrUpdate(State entity)
        {
            throw new NotSupportedException();
        }

        protected override State HydrateObject(IDataReader reader)
        {
            Debug.Assert(reader.FieldCount == 3);
            return new State
            {
                Id        = reader.GetInt64(0),
                CountryId = reader.GetInt64(1),
                Name      = reader.GetString(2),
            };
        }
    }
}
