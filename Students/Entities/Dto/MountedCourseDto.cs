namespace Students.Entities.Dto
{
    public record MountedCourseDto
    {

        public string? CourseName { get; init; }
        public string? CourseCode { get; init; }

        public string? CourseLevel { get; init; }
        public int? CourseCredit { get; init; }
        public int? CourseId { get; init; }
        public string? CourseType { get; init; }
        public string? CourseLecturer { get; init; }

    }
}
