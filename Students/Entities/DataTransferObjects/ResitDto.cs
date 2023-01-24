namespace Students.Entities.DataTransferObjects;
public record ResitDto
{
    public string? courseName { get; init; }
    public string? courseCode { get; init; }
    public string? grade { get; init; }

}