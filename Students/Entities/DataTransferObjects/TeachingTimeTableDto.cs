namespace Students.Entities.DataTransferObjects;

public record TeachingTimeTableDto
{

    public string? Venue { get; init; }
    public string? Begin { get; init; }
    public string? End { get; init; }

    public string? Day { get; init; }

    public string? Course { get; init; }

    public string? Classes { get; init; }

    public string? Lecturer { get; init; }
}
