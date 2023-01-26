using Students.Entities.Models;

namespace Students.Contracts
{
    public interface ITimeTableRepository
    {
        //IEnumerable<Payment> GetAllPayments(bool trackChanges);

        public Task<IEnumerable<TeachingTimeTable>> GetUpComingLectures(Student student, int Semester, string AcademicYear, CancellationToken cancellationToken);

        public Task<IEnumerable<TeachingTimeTable>> GetTeachingTimeTable(Student student, int Semester, string AcademicYear, CancellationToken cancellationToken);


    }
}
