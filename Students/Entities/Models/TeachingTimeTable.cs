using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("tpoly_teaching_table")]
public record TeachingTimeTable : BaseEntity
{
    [Key]
    public int id { get; init; } = default!;
    public string? begin { get; init; }
    public string? end { get; init; }
    public string? venue { get; init; }
    public int vcourse { get; set; }

    [ForeignKey("vcourse")]
    public MountedCourse? MountedCoursesTtable { get; set; }

    [Column("class")]
    public string? clase { get; init; }
    public string? vlecturer { get; init; }
    public string? day { get; init; }

}