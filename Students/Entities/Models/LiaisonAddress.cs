 
using System.ComponentModel.DataAnnotations.Schema;
namespace Students.Entities.Models;
[Table("liaison_address")]
public record LiaisonAddress : BaseEntity{

    public string? addresses { get; set; }= default!;
}