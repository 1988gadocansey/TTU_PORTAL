using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("tpoly_banks")]
public record Bank : BaseEntity
{

    public int ID { get; init; }
    [Key]
    public string? ACCOUNT_NUMBER { get; set; } = default!;
    public string? NAME { get; set; } = default!;

}