using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("products")]

public record Product : BaseEntity
{
    [Key]
    public int Id { get; set; }

    // refers to ID in srms student table
    [Required]
    public string? Code { set; get; }
    [Required]
    public string? Name { set; get; }
    [Required]
    public bool? AcceptPartPayment { set; get; }
    [Required]
    public string? Purpose { set; get; }
    [Required]
    public decimal? Amount { set; get; }
    [Required]
    public string? Currency { set; get; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; init; }
    [Required]
    public string? Banks { init; get; }
    [Required]
    public string? Instructions { init; get; }
    [Required]
    public bool Status { init; get; }

    public string? Url { init; get; }
}