using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Students.Entities.Models;
[Table("tpoly_mounted_courses")]
public record MountedCourse : BaseEntity
{
    [Key]
    public int ID { get; set; }





    //public int COURSE { get; set; }  

    public int COURSE { get; set; }

    [ForeignKey("COURSE")]
    public Course Courses { get; set; }



    public int? COURSE_SEMESTER { get; set; }
    public int? COURSE_CREDIT { get; set; }
    public string? COURSE_LEVEL { get; set; }
    public string? COURSE_TYPE { get; set; }



    public string? PROGRAMME { get; set; }

    [ForeignKey("PROGRAMME")]
    public Programme Programmes { get; set; }





    public string? LECTURER { get; set; } = default!;
    public string? COURSE_YEAR { get; set; } = default!;
    public string? YEAR_GROUP { get; set; } = default!;
    public string? OPT { get; set; } = default!;

}