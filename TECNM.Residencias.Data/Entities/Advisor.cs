using System;
using TECNM.Residencias.Data.Entities.Common;

namespace TECNM.Residencias.Data.Entities
{
    public sealed class Advisor : IEntity<long>
    {
        public long Id { get; set; }

        public long CompanyId { get; set; }

        public AdvisorType Type { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Section { get; set; } = "";

        public string Role { get; set; } = "";

        public string Email { get; set; } = "";

        public string Phone { get; set; } = "";

        public bool Enabled { get; set; }

        public DateTime UpdatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

    public enum AdvisorType
    {
        Internal,
        External,
    }
}
