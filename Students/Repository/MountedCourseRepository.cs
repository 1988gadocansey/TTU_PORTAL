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

        public IEnumerable<MountedCourse> GetAllCourses(bool trackChanges)
        {
            IQueryable<MountedCourse> mountedCourses = FindAll(trackChanges);

            return mountedCourses
                        .OrderBy(c => c.COURSE_TYPE)
                        .OrderBy(c => c.Course.COURSE_NAME)
                        .Include(a => a.Course)
                        .ToList();

        }
    }
}
