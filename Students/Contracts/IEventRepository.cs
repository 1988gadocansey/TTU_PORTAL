using Students.Entities.Models;

namespace Students.Contracts
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvent(bool trackChanges, string userEmail);

        void SaveEvent(bool trackChanges, Event e);
    }
}
