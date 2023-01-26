using Students.Entities.Models;

namespace Students.Contracts
{
    public interface IExamTimeTableRepository
    {

        public Task<IEnumerable<ExamTimeTable>> GetExamTimeTable(Student student, int Semester, string AcademicYear, CancellationToken cancellationToken);
    }
}
