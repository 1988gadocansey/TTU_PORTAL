using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("tpoly_main_exams")]
public record ExamTimeTable : BaseEntity{
    [Key]
    public int? id { get; init; }
    public string? session { get; init; }
    public string? venue { get; init; }

    public string? index_range { get; init; }
    public string? year { get; init; }
    public string? res { get; init; }
}