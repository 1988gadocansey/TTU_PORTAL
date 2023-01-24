using System.Linq;
using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class TimeTableRepository : ITimeTableRepository
    {
        private RepositoryContext _repositoryContext;
        private IUnitOfWork _unitOfWork;
        private RepositoryContext repositoryContext;



        public TimeTableRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;


        }

        async Task<IEnumerable<TeachingTimeTable>> ITimeTableRepository.GetUpComingLectures(Student student, int Semester, string AcademicYear, CancellationToken cancellationToken)
        {
            // DayOfWeek day = DateTime.Today.DayOfWeek;
            DateTime day = DateTime.UtcNow;
            return await _repositoryContext.TeachingTimeTables
                .AsNoTracking()
                .Where(c => c.MountedCoursesTtable.COURSE_YEAR == AcademicYear)
                .Where(c => c.MountedCoursesTtable.COURSE_SEMESTER == Semester)
                .Where(c => c.MountedCoursesTtable.COURSE_LEVEL == student.LEVEL)
                .Where(c => c.MountedCoursesTtable.PROGRAMME == student.PROGRAMMECODE)
                 .Where(c => c.day == day.ToString("dddd"))
                //.GroupBy(c => c.clase)
                .OrderBy(c => c.clase)
                .OrderBy(c => c.MountedCoursesTtable.Courses.COURSE_CODE)
                .ToListAsync(cancellationToken);
        }
    }
}