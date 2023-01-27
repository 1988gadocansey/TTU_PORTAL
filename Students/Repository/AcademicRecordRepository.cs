using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class AcademicRecordRepository : IAcademicRepository
    {
        private RepositoryContext _repositoryContext;
        public AcademicRecordRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        /*  async Task<IEnumerable<AcademicRecord>> IAcademicRepository.GetAllIssues(Student student, CancellationToken token)
         {
             return await _repositoryContext.AcademicRecords
               .AsNoTracking()
               .Where(a => a.student == student.ID)
               .Where(a => a.PROGRAMME == programme)
               .Where(a => a.COURSE_LEVEL == level)
         }
  */

    }
}
