using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("tpoly_levels")]
public record Level : BaseEntity
{


    public int? id { get; init; }
    [Key]
    public string? name { get; init; } = default!;
    public string? slug { get; init; } = default!;
    // public virtual ICollection<Student>? students { get; } = new HashSet<Student>();
}