using Students.Entities.Models;

namespace Students.Contracts
{
    public interface IDashBoardRepository
    {
        public Task<Student> GetStudentDetails(string email, CancellationToken token);

        public Task<IEnumerable<AcademicRecord>> GetAllIssues(Student student, CancellationToken token);
        public Task<Decimal> GetTotalPayment(Student student, Calender calender, CancellationToken token);

        public Task<Decimal> GetTotalFeesOwing(Student student, Calender calender, CancellationToken token);

        public Task<Decimal> GetTotalFeesCurrent(Student student, Calender calender, CancellationToken token);

        public Task<Decimal> getTotalPaymentCurrent(Student student, Calender calender, CancellationToken token);

        public Task<Decimal> getTotalPaymentPrevious(Student student, Calender calender, CancellationToken token);

        public Task<Decimal> GetTotalPaymentResit(Student student, Calender calender, CancellationToken token);

        public Task<Decimal> GetTotalPaymentResitAll(Student student, CancellationToken token);

        public Task<Decimal> GetTotalPaymentGraduation(Student student, Calender calender, CancellationToken token);
        public Task<Decimal> GetTotalLatePenalty(Student student, Calender calender, CancellationToken token);

        public Task<Decimal> GetFacultyDuesPaid(Student student, Calender calender, CancellationToken token);


    }
}
