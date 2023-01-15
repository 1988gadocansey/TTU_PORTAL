using Students.Entities.Models;

namespace Students.Contracts
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses(bool trackChanges);
    }
}
