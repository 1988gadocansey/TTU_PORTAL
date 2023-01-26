using System.Linq;
using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class ExamTimeTableRepository : IExamTimeTableRepository
    {
        private RepositoryContext _repositoryContext;
        private IUnitOfWork _unitOfWork;



        public ExamTimeTableRepository(RepositoryContext repositoryContext, IUnitOfWork unitOfWork)
        {
            _repositoryContext = repositoryContext;

            _unitOfWork = unitOfWork;
        }

        async Task<IEnumerable<ExamTimeTable>> IExamTimeTableRepository.GetExamTimeTable(Student student, int Semester, string AcademicYear, CancellationToken cancellationToken)
        {
            return await _repositoryContext.ExamTimeTables
              .AsNoTracking()
              .Where(c => c.MountedCoursesTtable.COURSE_YEAR == AcademicYear)
              .Where(c => c.MountedCoursesTtable.COURSE_SEMESTER == Semester)
              .Where(c => c.MountedCoursesTtable.COURSE_LEVEL == student.LEVEL)
              .Where(c => c.MountedCoursesTtable.PROGRAMME == student.PROGRAMMECODE)
               .Include(a => a.MountedCoursesTtable)
              //.GroupBy(c => c.clase)
              .OrderBy(c => c.day)
              .OrderBy(c => c.clase)
              .OrderBy(c => c.MountedCoursesTtable.Courses.COURSE_CODE)
              .ToListAsync(cancellationToken);
        }


    }
}