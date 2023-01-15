using Students.Entities.Models;

namespace Students.Contracts
{
    public interface IDashBoardRepository
    {
        IEnumerable<Payment> GetLastPayment(bool trackChanges, Student student);
        Student GetByEmail(User user);

        Student? GetStudentDetails(string email);

        DateTime GetStudentLastSeen(bool trackChanges, User user);
        IEnumerable<Event> GetEvents(bool trackChanges);

        Decimal TotalOwing(bool trackChanges, User user);

        Decimal TotalPaid(bool trackChanges, User user);



    }
}
