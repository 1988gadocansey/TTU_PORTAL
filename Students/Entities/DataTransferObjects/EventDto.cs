using Students.Entities.Enums;
namespace Students.Entities.DataTransferObjects
{
    public class EventDto
    {

        public string? Hostname { get; }


        // public int? EventType { get; }

        public string? IPaddress { get; }
        public string? UserAGent { get; }
        public string? Activities { get; }

        public DateTime? LastSeen { get; init; }


    }
}
