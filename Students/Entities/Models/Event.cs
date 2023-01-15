using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Students.Entities.Enums;
namespace Students.Entities.Models;
[Table("tpoly_system_log")]
public record Event : BaseEntity
{
    [Key]
    public int? id { get; init; }
    public string? student { get; set; } = default!;
    public EventTypes? eventType { get; set; } = default!;
    public string? activities { get; set; } = default!;
    public string? hostname { get; set; } = default!;
    public string? ipaddress { get; set; } = default!;
    public string? usergent { get; set; } = default!;
    public DateTime? dateTime { get; set; } = DateTime.UtcNow;
}