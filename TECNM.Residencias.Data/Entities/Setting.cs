using System;

namespace TECNM.Residencias.Data.Entities
{
    public sealed class Setting
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Value { get; set; }

        public DateTime UpdatedOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
