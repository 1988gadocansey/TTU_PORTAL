namespace Students.Entities.Dto
{
    public record IssuesDto
    {

        public string? CourseName { get; set; }
        public string? CourseCode { get; set; }
        public int? CourseCredit { get; set; }

        public string? AcademicYear { get; set; }

    }
}
