using Students.Entities.Models;

namespace Students.Contracts
{
    public interface IMountedCourseRepository
    {
        IEnumerable<MountedCourse> GetAllCourses(bool trackChanges);
    }
}
