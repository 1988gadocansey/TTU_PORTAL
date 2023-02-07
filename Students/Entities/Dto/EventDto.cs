using Students.Entities.Enums;
namespace Students.Entities.Dto
{
    public record EventDto
    {

        public string? Hostname { get; }


        // public int? EventType { get; }

        public string? IPaddress { get; }
        public string? UserAGent { get; }
        public string? Activities { get; }

        public DateTime? LastSeen { get; init; }


    }
}
