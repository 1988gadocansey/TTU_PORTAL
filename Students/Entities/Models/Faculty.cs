using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Students.Entities.Models;
[Table("tpoly_faculty")]
public record Faculty : BaseEntity
{
      [Key]
       public int ID { get; init; } = default!;
 
    
    public string? FACULTY { get; init; } = default!;
    public string? FACCODE { get; init; } = default!;
    public string? BANK { get; init; } = default!;
    public int? FHND_CODE { get; init; } = default!;
    public string? SLUG { get; init; } = default!;

}