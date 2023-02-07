namespace Students.Entities.Dto
{
    public record DashBoardDto
    {

        public string? Cgpa { get; init; }



        public string? FullName { get; init; }
        public string? DateOfBirth { get; init; }
        public string? Programme { get; init; }

        public DateTime? LastSeen { get; init; }
        public string? IndexNumber { get; init; }
        public int? StudentNumber { get; init; }

        public string? Status { get; init; }
        public string? CurrentClass { get; init; }

        public string? CurrentLevel { get; init; }

        public int? Registered { get; init; }

        public int? LecturerAssessed { get; init; }

    }
}
