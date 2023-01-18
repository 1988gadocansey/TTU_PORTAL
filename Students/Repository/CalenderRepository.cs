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

        public Calender GetCalender(bool trackChanges) => Get(a => a.STATUS == 1);
    }
}
