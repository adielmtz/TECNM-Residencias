namespace TECNM.Residencias.Data.Entities
{
    public sealed record Extra
    {
        public required long Id { get; init; }

        public required ExtraType Type { get; init; }

        public required string Value { get; init; }
    }

    public enum ExtraType
    {
        Database,
        Editor,
        Language,
        Methodology,
    }
}
