namespace TECNM.Residencias.Data.Entities.DataObjects
{
    public sealed class CompanySearchDto
    {
        public required long Id { get; set; }

        public required string Rfc { get; set; }

        public required string Name { get; set; }

        public override string ToString()
        {
            return $"{Rfc} : {Name}";
        }
    }
}
