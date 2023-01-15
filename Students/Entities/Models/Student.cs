
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Students.Entities.Models;
[Table("tpoly_students")]
public record Student : BaseEntity
{
    [Key]
    public int? ID { get; init; }
    public string? STNO { get; init; }

    public string? INDEXNO { get; init; }

    public string? LEVEL { get; set; }
    [ForeignKey("LEVEL")]
    public Level? Level { get; set; }



    public string? PROGRAMMECODE { get; set; }
    [ForeignKey("PROGRAMMECODE")]
    public Programme? Programme { get; set; }

    [NotMapped]
    public string? FullName => FIRSTNAME + " " + OTHERNAMES + " " + SURNAME;






    public string? YEAR { get; init; } = default!;
    public string? FIRSTNAME { get; init; } = default!;
    public string? OTHERNAMES { get; init; } = default!;
    public string? SURNAME { get; init; } = default!;
    public string name => this.SURNAME + this.OTHERNAMES + this.FIRSTNAME;

    public string? GROUP_CLASS { get; init; } = default!;

    public string? SEX { get; init; } = default!;

    public string? DATEOFBIRTH { get; init; } = default!;

    public string? DATEOFBIRTH2 { get; init; } = default!;

    public int Age()
    {
        /*  if (DATEOFBIRTH != null)
         {
             var birthDate = this.DATEOFBIRTH;
             DateTime n = DateTime.Now; // To avoid a race condition around midnight
             int age = n.Year - birthDate.Year;

             if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                 age--;

             return age;
         }
         else
         {
             return 0;
         } */
        return 0;
    }

    public string? TITLE { get; init; } = default!;
    public string? GRADUATING_GROUP { get; init; } = default!;

    public DateTime? DATE_ADMITTED { get; init; } = default!;

    public string? MARITAL_STATUS { get; init; } = default!;

    public string? RESIDENTIAL_ADDRESS { get; init; } = default!;
    public string? TELEPHONENO { get; init; } = default!;

    public string? EMAIL { get; init; } = default!;

    public string? STATUS { get; init; } = default!;
    public string? STUDENT_TYPE { get; init; } = default!;
    public decimal CGPA { get; init; } = default!;
    public string? CLASS { get; init; } = default!;
    public decimal? CWA { get; init; } = default!;
    public string? NAB_CLASS { get; init; } = default!;

    public string? RSA_CLASS { get; init; } = default!;

    public string? DIP_CLASS { get; init; } = default!;
    public string? TYPE { get; init; } = default!;
    public string? ROOM { get; init; } = default!;

    public string? LEVEL_ADMITTED { get; init; } = default!;

    public string? FOREIGNER { get; init; } = default!;
    public int? ALLOW_REGISTER { get; init; } = default!;
    public int? ALLOW_RESULT { get; init; } = default!;

    public int? REGISTERED { get; init; } = default!;
    public int? QUALITY_ASSURANCE { get; init; } = default!;
    public int? LIAISON { get; init; } = default!;
    public int? ASSUMPTION_DUTY { get; init; } = default!;

}