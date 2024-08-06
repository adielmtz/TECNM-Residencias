namespace TECNM.Residencias.Data.Entities
{
    public sealed record City
    {
        public required long Id { get; init; }

        public required long StateId { get; init; }

        public required string Name { get; init; }

        public override string ToString()
        {
            return Name;
        }
    }
}
