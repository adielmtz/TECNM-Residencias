using System;

namespace TECNM.Residencias.Data.Entities.Common
{
    public interface IEntity<T>
    {
        public T Id { get; set; }

        public bool Enabled { get; set; }

        public DateTime UpdatedOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
