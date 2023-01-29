namespace Students.Entities.DataTransferObjects
{
    public record TranscriptDto
    {

        public string? CourseName { get; set; }
        public string? CourseCode { get; set; }
        public int? CourseCredit { get; set; }
        public string? AcademicYear { get; set; }
        public int? Semester { get; set; }
        public string? Level { get; set; }
        public string? Grade { get; set; }

        public int? Resit { get; set; }

        public string? ResitDone { get; set; }

        public decimal? Gpoint { get; set; }
        public string? CourseType { get; set; }

    }
}
