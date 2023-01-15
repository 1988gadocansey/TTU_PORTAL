using Students.Entities.Models;

namespace Students.Contracts
{
    public interface ICalenderRepository
    {
        IEnumerable<Calender> GetCalender(bool trackChanges);
    }
}
