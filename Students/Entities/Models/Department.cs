using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Students.Entities.Models;
[Table("tpoly_department")]
public record Department : BaseEntity
{


    public int ID { get; init; }

    [Key]
    public string? DEPTCODE { get; init; }
    //public string? FACCODE {get; init;}= default!;
    [ForeignKey(nameof(Faculty))]
    public Faculty FACCODE { get; set; }
    public string? DEPARTMENT { get; init; } = default!;
    public int? DHND_CODE { get; init; } = default!;
    public string? SLUG { get; init; } = default!;
    public DateTime? SYNC_CGPA { get; init; } = default!;
    public DateTime? SYNC_NAP { get; init; } = default!;
    public virtual ICollection<Programme>? programmes { get; private set; }



}