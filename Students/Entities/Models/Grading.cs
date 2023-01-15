using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("tpoly_grade_system")]
public record Grading : BaseEntity{
    [Key]
    public int? id { get; init; }
    public string? grade { get; init; }
    public decimal? lower { get; init; }

    public decimal? upper { get; init; }
    public decimal? value { get; init; }
    public string? type { get; init; }
}