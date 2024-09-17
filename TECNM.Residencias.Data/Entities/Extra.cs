using System;

namespace TECNM.Residencias.Data.Entities
{
    public sealed class Extra
    {
        public required long Id { get; set; }

        public required ExtraType Type { get; set; }

        public required string Value { get; set; }

        public DateTime UpdatedOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }

    public enum ExtraType
    {
        Database,
        Editor,
        Language,
        Methodology,
    }
}
