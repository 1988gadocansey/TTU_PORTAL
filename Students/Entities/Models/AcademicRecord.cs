using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Students.Entities.Models;
[Table("tpoly_academic_record")]
public record AcademicRecord : BaseEntity
{
    [Key]
    public int ID { get; init; }

    //[JsonPropertyName("mountcourse")]
    public int course { get; set; }

    [ForeignKey("course")]
    public MountedCourse? Courses { get; set; }

    public int student { get; set; }

    [ForeignKey("student")]
    public Student? Students { get; set; }

    public string? level { get; set; }

    [ForeignKey("level")]
    public Level? Levels { get; set; }

    public decimal? quiz1 { get; init; } = default!;
    public decimal? quiz2 { get; init; } = default!;
    public decimal? quiz3 { get; init; } = default!;
    public decimal? midSem1 { get; init; } = default!;
    public decimal? exam { get; init; } = default!;
    public decimal? total { get; init; } = default!;
    public char? grade { get; init; } = default!;
    public decimal? gpoint { get; init; } = default!;

    public string? sem { get; init; } = default!;
    public string? year { get; init; } = default!;
    public string? yrgp { get; init; } = default!;
    public string? groups { get; init; } = default!;
    public string? resit { get; init; } = default!;
    public string? wesit { get; init; } = default!;
    public string? sup { get; init; } = default!;
    public string? dateRegistered { get; init; } = default!;

}