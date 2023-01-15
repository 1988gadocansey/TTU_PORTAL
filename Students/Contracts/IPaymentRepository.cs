using Students.Entities.Models;

namespace Students.Contracts
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllPayments(bool trackChanges);
    }
}
