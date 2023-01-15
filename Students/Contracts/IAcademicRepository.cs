using Students.Entities.Models;

namespace Students.Contracts
{
    public interface IAcademicRepository
    {
        IEnumerable<AcademicRecord> GetTranscript(bool trackChanges, string? semester, Level? level, string? year, Student student);
    }
}
