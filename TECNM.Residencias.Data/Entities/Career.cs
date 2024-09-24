using System;

namespace TECNM.Residencias.Data.Entities
{
    public sealed class Career
    {
        public long Id { get; set; }

        public string Name { get; set; } = "";

        public bool Enabled { get; set; }

        public DateTime UpdatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
