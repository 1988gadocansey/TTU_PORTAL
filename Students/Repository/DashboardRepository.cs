using System.Linq;
using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class DashboardRepository : IDashBoardRepository
    {
        private RepositoryContext _repositoryContext;


        public DashboardRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;


        }

        public async Task<IEnumerable<AcademicRecord>> GetAllIssues(Student student, CancellationToken token)
        {
            return await _repositoryContext.AcademicRecords.Where(a => a.student == student.ID)
                                                 .Where(a => a.grade == 'F')
                                                 .Where(a => a.resit == "no")
                                                 .Where(a => a.total > 1)
                                                 .OrderBy(c => c.Course.Courses.COURSE_CODE)
                                                 .OrderBy(c => c.resit)
                                                 .Include(a => a.Course)
                                                 .Include(a => a.Course.Courses)
                                                 .ToListAsync(token);
        }

        public async Task<decimal> GetFacultyDuesPaid(Student student, Calender calender, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudentDetails(string email, CancellationToken cancellationToken) => await _repositoryContext.Students?.Where(c => c.EMAIL == email).FirstAsync();

        public async Task<decimal> GetTotalFeesCurrent(Student student, Calender calender, CancellationToken token)
        {
            if (student.TYPE == "Foriegn")
            {
                var total = await _repositoryContext.Bills
                           .Where(a => a.LEVEL == student.LEVEL)
                           .Where(a => a.YEAR == calender.ADMIT)
                           .Where(a => a.FOREIGNER == 1)
                           .Where(a => a.PROGRAMME == student.PROGRAMMECODE)
                           .FirstAsync();

                return Convert.ToDecimal(total);
            }
            var totalLocal = await _repositoryContext.Bills
                          .Where(a => a.LEVEL == student.LEVEL)
                          .Where(a => a.YEAR == calender.ADMIT)
                          .Where(a => a.FOREIGNER == 1)
                          .Where(a => a.PROGRAMME == student.PROGRAMMECODE)
                          .FirstAsync();
            return Convert.ToDecimal(totalLocal);
        }

        public async Task<decimal> GetTotalFeesOwing(Student student, Calender calender, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetTotalLatePenalty(Student student, Calender calender, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetTotalPayment(Student student, Calender calender, CancellationToken token)
        {
            if (student.STATUS == "Admitted")
            {
                var total = await _repositoryContext.Payments
                            .Where(a => a.Students.ID == student.ID)
                            .Where(a => a.YEAR == calender.ADMIT)
                            .Where(a => a.FEE_CODE == "111")
                            .SumAsync(a => a.AMOUNT);


                return Convert.ToDecimal(total);
            }

            return (decimal)await _repositoryContext.Payments
                            .Where(a => a.Students.ID == student.ID)
                            .Where(a => a.YEAR == calender.YEAR)
                            .Where(a => a.FEE_CODE == "111")
                            .SumAsync(a => a.AMOUNT);

        }

        public Task<decimal> getTotalPaymentCurrent(Student student, Calender calender, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetTotalPaymentGraduation(Student student, Calender calender, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> getTotalPaymentPrevious(Student student, Calender calender, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetTotalPaymentResit(Student student, Calender calender, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetTotalPaymentResitAll(Student student, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}