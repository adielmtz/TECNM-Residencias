using System;
using TECNM.Residencias.Data.Entities.Common;

namespace TECNM.Residencias.Data.Entities
{
    public sealed class Student : IEntity<long>
    {
        public long Id { get; set; }

        public long SpecialtyId { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Email { get; set; } = "";

        public string Phone { get; set; } = "";

        public Gender Gender { get; set; }

        public string Semester { get; set; } = "";

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public long? InternalAsesorId { get; set; }

        public long? ExternalAsesorId { get; set; }

        public long? ReviewerAsesorId { get; set; }

        public long CompanyId { get; set; }

        public string Department { get; set; } = "";

        public string Schedule { get; set; } = "";

        public bool Closed { get; set; }

        public string Notes { get; set; } = "";

        public DateTime UpdatedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public override string ToString()
        {
            return $"({Id}) {FirstName} {LastName}";
        }
    }

    public enum Gender
    {
        Male,
        Female,
        Other,
    }
}
