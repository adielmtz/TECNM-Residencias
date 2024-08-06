using System;
using TECNM.Residencias.Data.Entities.Common;

namespace TECNM.Residencias.Data.Entities
{
    public sealed class Contact : IEntity<long>
    {
        public long Id { get; set; }

        public string Type { get; set; } = "";

        public string Value { get; set; } = "";

        public string Extra { get; set; } = "";

        public DateTime UpdatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public override string ToString()
        {
            return $"{Type}: {Value}";
        }
    }
}
