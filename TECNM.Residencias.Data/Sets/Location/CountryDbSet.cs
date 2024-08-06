using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TECNM.Residencias.Data.Entities;
using TECNM.Residencias.Data.Sets.Common;

namespace TECNM.Residencias.Data.Sets.Location
{
    public sealed class CountryDbSet : DbSet<Country>
    {
        private static readonly Dictionary<long, Country> _countries = new();
        private static bool _prefetched = false;

        public CountryDbSet(IDbContext context) : base(context)
        {
        }

        public Country GetCountryById(long id)
        {
            Country? country;
            if (_countries.TryGetValue(id, out country))
            {
                return country;
            }

            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, name FROM country WHERE id = $id";
            command.Parameters.Add("$id", SqliteType.Integer).Value = id;
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                country = new Country
                {
                    Id   = reader.GetInt64(0),
                    Name = reader.GetString(1),
                };

                _countries[country.Id] = country;
                return country;
            }

            throw new UnreachableException($"Illegal Country Id: {id}");
        }

        public IReadOnlyList<Country> GetCountries()
        {
            if (_prefetched)
            {
                return new List<Country>(_countries.Values);
            }

            using var command = Context.Database.CreateCommand();
            command.CommandText = "SELECT id, name FROM country ORDER BY name";
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var country = new Country
                {
                    Id   = reader.GetInt64(0),
                    Name = reader.GetString(1),
                };

                _countries.TryAdd(country.Id, country);
            }

            _prefetched = true;
            return new List<Country>(_countries.Values);
        }

        public override bool Insert(Country entity)
        {
            throw new NotSupportedException();
        }

        public override int Update(Country entity)
        {
            throw new NotSupportedException();
        }

        public override int Delete(Country entity)
        {
            throw new NotSupportedException();
        }

        public override bool InsertOrUpdate(Country entity)
        {
            throw new NotSupportedException();
        }
    }
}
