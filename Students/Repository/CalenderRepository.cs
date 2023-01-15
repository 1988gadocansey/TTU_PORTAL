using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class CalenderRepository : RepositoryBase<Calender>, ICalenderRepository
    {
        public CalenderRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Calender> GetCalender(bool trackChanges) =>
           FindAll(trackChanges)
           .OrderBy(c =>c.ID )
           
           .ToList();
    }
}
