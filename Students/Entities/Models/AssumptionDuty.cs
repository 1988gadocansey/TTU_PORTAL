using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("tpoly_laiason_assumptionofduty")]
public record AssumptionDuty : BaseEntity
{
    [Key]
    public int? ID { get; init; }
    public string? NAME { get; set; }
    public string? INDEXNO { get; set; }

    public string? LEVEL { get; set; }

    public string? SESSION_TYPE { get; set; }
    public string? PROGRAMME { get; set; }
    public string? CONTACT_ADDRESS { get; set; }
    public string? PHONE { get; set; }
    public string? EMAIL { get; set; }

    public string? DATE_OF_DUTY { get; set; }

    public string? COMPANY_NAME { get; set; }
    public string? COMPANY_ADDRESS { get; set; }
    public string? COMPANY_PHONE { get; set; }
    public string? COMPANY_EMAIL { get; set; }
    public string? COMPANY_LOCATION { get; set; }
    public string? COMPANY_EXACT_LOCATION { get; set; }
    public string? COMPANY_SUPERVISOR { get; set; }
    public string? COMPANY_SUPERVISOR_NO { get; set; }
    public string? COMPANY_SUBZONE { get; set; }
    public int? STATUS { get; set; }
    public DateTime? INPUTEDDATE { get; set; } = default!;
}