namespace Students.Entities.DataTransferObjects
{
    public record ExternalAuthDto
    {
        public string? Provider { get; set; }
        public string? IdToken { get; set; }
    }
}
