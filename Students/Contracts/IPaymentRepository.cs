using Students.Entities.Models;

namespace Students.Contracts
{
    public interface IPaymentRepository
    {
        //IEnumerable<Payment> GetAllPayments(bool trackChanges);

        public Task<IEnumerable<Payment>> GetPaymentsDashboard(int? StudentNo);
    }
}
