using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("liaison_data")]
public record Liaison : BaseEntity
{
    [Key]
    public int? id { get; init; }
    public string? indexno { get; set; }
    public string? level { get; set; }

    public string? date_duty { get; set; }
    public string? company_name { get; set; }
    public string? company_address { get; set; }

    public string? company_phone { get; set; }
    public string? company_email { get; set; }
    public string? company_address_to { get; set; }
    public string? company_supervisor { get; set; }
    public string? company_subzone { get; set; }

    public string? year { get; set; }

    public int? terms { get; set; }

    public short? status { get; set; }
}