using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Payment> GetAllPayments(bool trackChanges)
        {
            IQueryable<Payment> payments = FindAll(trackChanges);

            return payments.OrderBy(c => c.YEAR)
                        .OrderBy(c => c.BANK_DATE)
                        .Include(a => a.PAYMENTTYPE)
                        .ToList();

        }
    }
}
