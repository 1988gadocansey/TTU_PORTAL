using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("tpoly_lecture_rooms")]
public record LectureRoom : BaseEntity{
    [Key]
    public int? ID { get; init; }
    public string? ROOM { get; init; }
    public string? SLUG { get; init; }

    public string? FLOOR { get; init; }
    public string? EXAMS { get; init; }
    public string? TEACH { get; init; }
}