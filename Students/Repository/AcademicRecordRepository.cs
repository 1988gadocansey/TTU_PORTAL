using Microsoft.EntityFrameworkCore;
using Students.Contracts;
using Students.Entities.Models;

namespace Students.Repository
{
    public class AcademicRecordRepository : RepositoryBase<AcademicRecord>, IAcademicRepository
    {
        public AcademicRecordRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<AcademicRecord> GetTranscript(bool trackChanges, string? semester, Level? level, string? year, Student student)
        {
            IQueryable<AcademicRecord> trancripts = FindAll(trackChanges)
                                  .Where(a => a.sem == semester)
                                  .Where(a => a.level == level.name)
                                  .Where(a => a.year == year)
                                  .Where(a => a.student == student.ID);

            return trancripts.OrderBy(c => c.level)
                        .OrderBy(c => c.year)
                        .Include(a => a.sem)
                        .ToList();

        }
    }
}
