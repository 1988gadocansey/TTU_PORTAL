using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class MountedCourseRepository : RepositoryBase<MountedCourse>, IMountedCourseRepository
    {
        public MountedCourseRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<MountedCourse> GetAllCourses(bool trackChanges, int semester, string level, string programme, string years)
        {
            IQueryable<MountedCourse> courses = FindAll(false);

            return courses
                        .Where(a => a.COURSE_SEMESTER == semester)
                        .Where(a => a.PROGRAMME == programme)
                        .Where(a => a.COURSE_LEVEL == level)
                         .Where(a => a.COURSE_YEAR == years)
                        .OrderBy(c => c.COURSE_TYPE)
                        .OrderBy(c => c.Course.COURSE_NAME)
                        .Include(a => a.Course)
                        .ToList();

        }
    }
}
