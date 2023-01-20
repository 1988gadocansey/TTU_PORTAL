using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class CalenderRepository : ICalenderRepository
    {
        private RepositoryContext _repositoryContext;
        private IUnitOfWork _unitOfWork;


        public CalenderRepository(RepositoryContext repositoryContext, IUnitOfWork unitOfWork)
        {
            _repositoryContext = repositoryContext;

            _unitOfWork = unitOfWork;
        }

        public async Task<Calender> GetCalender()
        {
            var calender = await _repositoryContext.Calenders.AsNoTracking().FirstOrDefaultAsync(a => a.STATUS == 1);

            return calender;



        }
    }
}
