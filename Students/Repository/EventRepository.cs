using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        //  private IUnitOfWork _unitOfWork;
        public EventRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            //_unitOfWork = unitOfWork;
        }

        IEnumerable<Event> IEventRepository.GetAllEvent(bool trackChanges, string userEmail)
        {
            IQueryable<Event> events = FindAll(false);

            return events
                        .Where(a => a.student == userEmail)
                        .OrderByDescending(c => c.dateTime)
                        .Take(10)
                        //.Include("User")
                        .ToList();

        }

        void IEventRepository.SaveEvent(bool trackChanges, Event e)
        {
            Add(e);

        }
    }
}