using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("tpoly_laiason_zones")]
public record LiaisonZone : BaseEntity{
    [Key]
    public int? ID { get; init; }
    public string? REGION { get; init; }
    public string? ZONE { get; init; }

    public string? SUBZONES { get; init; }
     
}