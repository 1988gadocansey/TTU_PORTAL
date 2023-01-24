using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private RepositoryContext _repositoryContext;
        private IUnitOfWork _unitOfWork;
        private RepositoryContext repositoryContext;



        public PaymentRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;


        }

        async Task<IEnumerable<Payment>> IPaymentRepository.GetPaymentsDashboard(int? StudentNo)
        {
            return await _repositoryContext.Payments
                .AsNoTracking()
                .Where(c => c.Students.ID == StudentNo)
                .OrderBy(c => c.BANK_DATE)
                .Include(a => a.Banks)
                .Take(3)
                .ToListAsync();
        }
    }
}