using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Course> GetAllCourses(bool trackChanges) =>
           FindAll(trackChanges)
           .OrderBy(c =>c.COURSE_NAME )
           
           .ToList();
    }
}
