using System;
using TECNM.Residencias.Data.Entities.Common;

namespace TECNM.Residencias.Data.Entities
{
    public sealed class Document : IEntity<long>
    {
        public long Id { get; set; }

        public long StudentId { get; set; }

        public string Type { get; set; } = "";

        public string CurrentName { get; set; } = "";

        public string OriginalName { get; set; } = "";

        public long Size { get; set; }

        public string Checksum { get; set; } = "";

        public DateTime UpdatedOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
