using Students.Entities.Models;

namespace Students.Contracts
{
    public interface IMountedCourseRepository
    {
        IEnumerable<MountedCourse> GetAllCourses(bool trackChanges, int semester, string level, string programme, string year);
    }
}
