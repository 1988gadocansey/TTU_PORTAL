using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Students.Entities.Models;
[Table("tpoly_courses")]
public record Course : BaseEntity
{
    
    [Key]
    public int ID { get; set; }
    public string? COURSE_CODE { get; init; } = default!;
    public int? COURSE_CREDIT { get; init; } = default!;
    public string? COURSE_NAME { get; init; } = default!;
    public int? COURSE_SEMESTER { get; init; } = default!;
     
    public string? SLUG { get; init; } = default!;
    public string? course_name2 { get; init; } = default!;

}