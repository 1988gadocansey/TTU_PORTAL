using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Students.Entities.Models;
[Table("tpoly_academic_record")]
public record AcademicRecord : BaseEntity
{
    [Key]
    public int ID { get; init; }


    public int course { get; set; }

    [ForeignKey("course")]
    public MountedCourse? Course { get; set; }

    public int student { get; set; }

    [ForeignKey("student")]
    public Student? Student { get; set; }

    public string? level { get; set; }

    [ForeignKey("level")]
    public Level? Level { get; set; }

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