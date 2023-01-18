using Students.Entities.Models;

namespace Students.Contracts
{
    public interface ICalenderRepository
    {
        Calender GetCalender(bool trackChanges);
    }
}
