using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Students.Entities.Models;
[Table("tpoly_feedetails")]
public record Payment : BaseEntity
{
    [Key]
    public string? ID { get; init; }

    [ForeignKey(nameof(Student))]
    public Student? STUDENT { get; set; }
    public string? INDEXNO { get; init; } = default!;
    public string? PROGRAMME { get; init; } = default!;
    public string? LEVEL { get; init; } = default!;
    public string? CURRENCY { get; init; } = default!;
    public string? PAYMENTTYPE { get; init; } = default!;
    public string? AMOUNT { get; init; } = default!;
    public string? PAYMENTDETAILS { get; init; } = default!;
    [ForeignKey(nameof(Bank))]
    public Bank? BANK { get; init; }
    public DateTime? BANK_DATE { get; init; } = default!;
    public string? TRANSACTION_ID { get; init; } = default!;
    public string? FEE_CODE { get; init; } = default!;
    public string? YEAR { get; init; } = default!;
    public string? SEMESTER { get; init; } = default!;

    public DateTime? TRANSDATE { get; init; } = default!;

}