using Students.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Students.Repository;
public class UnitOfWork : IUnitOfWork
{
    private readonly RepositoryContext _dbContext;

    public UnitOfWork(RepositoryContext dbContext)
    {
        _dbContext = dbContext;
    }

    /* 
        public IBookRepository BookRepository
        {
            get { return _bookRepository = _bookRepository ?? new BookRepository(_dbContext); }
        } */


    public void Commit()
        => _dbContext.SaveChanges();


    public async Task CommitAsync()
        => await _dbContext.SaveChangesAsync();


    public void Rollback()
        => _dbContext.Dispose();


    public async Task RollbackAsync()
        => await _dbContext.DisposeAsync();
}