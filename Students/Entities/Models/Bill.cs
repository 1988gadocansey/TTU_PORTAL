using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("tpoly_bills")]
public record Bills : BaseEntity
{
    [Key]
    public int? ID { get; init; }
    /*  public int PROGRAMME { get; set; }
     [ForeignKey("PROGRAMME")]
     public Programme? Programme { get; init; } */
    public string? PROGRAMME { get; set; }

    public string LEVEL { get; set; }
    /*  public int LEVEL { get; set; }
     [ForeignKey("LEVEL")]
     public Level? Level { get; init; } */

    public string? YEAR { get; init; }
    public int? SERVICES { get; init; }
    public int? EXAMINATION { get; init; }

    public int? AFUF { get; set; }
    public int? PRACTICALS { get; set; }
    public int? COMPENSATION { get; set; }
    public decimal? FEES { get; set; }
    public int? SRC { get; set; }

    public int? FACULTY { get; set; }

    public int? HALL { get; set; }

    public int? CLOTHING { get; set; }
    public int? PPE { get; set; }
    public int? HEALTH { get; set; }
    public int? THESIS { get; set; }
    public decimal? AMOUNT { get; set; }
    public int? FOREIGNER { get; set; }


}