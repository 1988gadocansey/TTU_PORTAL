using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class MountedCourseRepository : IMountedCourseRepository
    {
        private RepositoryContext _repositoryContext;
        private IUnitOfWork _unitOfWork;


        public MountedCourseRepository(RepositoryContext repositoryContext, IUnitOfWork unitOfWork)
        {
            _repositoryContext = repositoryContext;

            _unitOfWork = unitOfWork;
        }

        async Task<IEnumerable<MountedCourse>> IMountedCourseRepository.GetAllCourses(int semester, string level, string programme, string years, CancellationToken cancellationToken)
        {


            return await _repositoryContext.MountedCourses
                .AsNoTracking()

                       .Where(a => a.COURSE_SEMESTER == semester)
                       .Where(a => a.PROGRAMME == programme)
                       .Where(a => a.COURSE_LEVEL == level)
                        .Where(a => a.COURSE_YEAR == years)
                       .OrderBy(c => c.COURSE_TYPE)
                       .OrderBy(c => c.Courses.COURSE_NAME)
                       .Include(a => a.Courses)
                       .ToListAsync(cancellationToken);

        }


    }
}
