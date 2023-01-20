using Students.Entities.Models;

namespace Students.Contracts
{
    public interface ICalenderRepository
    {
        Task<Calender> GetCalender();
    }
}
