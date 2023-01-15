using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("tpoly_academic_settings")]
public record Calender : BaseEntity{
    [Key]
    public int? ID { get; init; }
    public string? YEAR { get; init; }
    public string? SEMESTER{ get; init; }
    public int? STATUS{ get; init; }
    public int? LIAISON{ get; init; }
    public string? QA{ get; init; }
    public string? RESULT_BLOCK{ get; init; }
    public string? RESIT{ get; init; }
    public int? RESIT_REG{ get; init; }
    public int? REG100H{ get; init; }
    public int? REG200H{ get; init; }
    public int? REG300H{ get; init; }
    public int? REG100NT{ get; init; }
    public int? REG200NT{ get; init; }
    public int? REG100BT {get; init; }
    public int? REG200BT{ get; init; }
    public int? REG300BT{ get; init; }
    public int? REG400BT{ get; init; }
    public int? REG100BTT{ get; init; }
    public int? REG200BTT{ get; init; }
    public int? REG500MT{ get; init; }
    public int? REG600MT{ get; init; }
}