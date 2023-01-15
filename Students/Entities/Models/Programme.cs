using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Students.Entities.Models;
[Table("tpoly_programme")]
public record Programme : BaseEntity
{
    public int ID { get; init; }



    public string? DEPTCODE { get; set; }
    [ForeignKey("PROGRAMMECODE")]
    public Department? Department { get; set; }

    [Key]
    public string? PROGRAMMECODE { get; set; }
    public string? PROGRAMME { get; init; } = default!;
    public string? SLUG { get; init; } = default!;
    public int? RUNNING { get; init; } = default!;
    public string? TYPE { get; init; } = default!;
    public string? GRADING_SYSTEM { get; init; } = default!;
    public int? SHOW_ON_PORTAL { get; init; } = default!;
    public string? RESULT { get; init; } = default!;
    public string? HND_CODE { get; init; } = default!;
    public string? COMBINEDCODE { get; init; } = default!;
    public string? COMBINEDEPT { get; init; } = default!;

    //public ICollection<Student>? students { get; } = new HashSet<Student>();
    public virtual ICollection<Student>? students { get; private set; }


}