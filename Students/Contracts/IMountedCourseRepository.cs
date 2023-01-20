using Students.Entities.Models;

namespace Students.Contracts
{
    public interface IMountedCourseRepository
    {


        public Task<IEnumerable<MountedCourse>> GetAllCourses(int semester, string level, string programme, string year, CancellationToken token);
    }
}
