using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Students.Entities.Models;
[Table("tpoly_feedetails")]
public record Payment : BaseEntity
{
    [Key]
    public int? ID { get; init; }


    public int STUDENT { get; set; }

    [ForeignKey("STUDENT")]
    public Student? Students { get; set; }



    public string? INDEXNO { get; init; } = default!;
    public string? PROGRAMME { get; init; } = default!;
    public string? LEVEL { get; init; } = default!;
    public string? CURRENCY { get; init; } = default!;
    public string? PAYMENTTYPE { get; init; } = default!;
    public string? AMOUNT { get; init; } = default!;
    public string? PAYMENTDETAILS { get; init; } = default!;


    public string BANK { get; set; }

    [ForeignKey("BANK")]
    public Bank? Banks { get; set; }

    public string? BANK_DATE { get; init; } = default!;
    public string? TRANSACTION_ID { get; init; } = default!;
    public string? FEE_CODE { get; init; } = default!;
    public string? YEAR { get; init; } = default!;
    public string? SEMESTER { get; init; } = default!;

    public DateTime? TRANSDATE { get; init; } = default!;

}