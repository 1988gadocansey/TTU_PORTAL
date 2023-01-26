using System.Linq;
using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class TimeTableRepository : ITimeTableRepository
    {
        private RepositoryContext _repositoryContext;

        public TimeTableRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;


        }
        async Task<IEnumerable<TeachingTimeTable>> ITimeTableRepository.GetTeachingTimeTable(Student student, int Semester, string AcademicYear, CancellationToken cancellationToken)
        {

            return await _repositoryContext.TeachingTimeTables
                .AsNoTracking()
                .Where(c => c.MountedCoursesTtable.COURSE_YEAR == AcademicYear)
                .Where(c => c.MountedCoursesTtable.COURSE_SEMESTER == Semester)
                .Where(c => c.MountedCoursesTtable.COURSE_LEVEL == student.LEVEL)
                .Where(c => c.MountedCoursesTtable.PROGRAMME == student.PROGRAMMECODE)
                 //.GroupBy(c => c.clase)
                 .Include(a => a.MountedCoursesTtable)
                .OrderBy(c => c.day)
                .OrderBy(c => c.clase)
                .OrderBy(c => c.MountedCoursesTtable.Courses.COURSE_CODE)
                .ToListAsync(cancellationToken);
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
                  .Include(a => a.MountedCoursesTtable)
                .Include(a => a.MountedCoursesTtable.Courses)

                //.GroupBy(c => c.clase)
                .OrderBy(c => c.clase)
                .OrderBy(c => c.MountedCoursesTtable.Courses.COURSE_CODE)
                .ToListAsync(cancellationToken);
        }
    }
}