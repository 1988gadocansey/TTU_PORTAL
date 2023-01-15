using Students.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Students.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        private IUnitOfWork _unitOfWork;

        private readonly DbSet<T> _entitiySet;

        public RepositoryBase(RepositoryContext repositoryContext, IUnitOfWork unitOfWork)
        {
            RepositoryContext = repositoryContext;

            _entitiySet = RepositoryContext.Set<T>();
        }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
              RepositoryContext.Set<T>()
                .AsNoTracking() :
              RepositoryContext.Set<T>().Take(10);

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
            !trackChanges ?
              RepositoryContext.Set<T>()

                .Where(expression)

                .AsNoTracking() :
              RepositoryContext.Set<T>()
                .Where(expression);

        public IQueryable<T> Querys(Expression<Func<T, bool>> filter)
        {
            return RepositoryContext.Set<T>().Where(filter);
        }

        public T Query(Expression<Func<T, bool>> filter)
        {
            //  RepositoryContext.Set<T>().FirstOrDefault<T>(filter);
            return
           RepositoryContext.Set<T>().FirstOrDefault(filter);

        }

        /*  public void Create(T entity)
         {
             RepositoryContext.Set<T>().Add(entity);
             RepositoryContext.SaveChanges();
             _unitOfWork.Commit();
         }

         public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

         public void Update(T entity) => RepositoryContext.UpdateRange();
  */
        public void Add(T entity)
              => RepositoryContext.Add(entity);


        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await RepositoryContext.AddAsync(entity, cancellationToken);


        public void AddRange(IEnumerable<T> entities)
            => RepositoryContext.AddRange(entities);


        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            => await RepositoryContext.AddRangeAsync(entities, cancellationToken);


        public T Get(Expression<Func<T, bool>> expression)
            => _entitiySet.FirstOrDefault(expression);


        public IEnumerable<T> GetAll()
            => _entitiySet.AsEnumerable();


        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
            => _entitiySet.Where(expression).AsEnumerable();


        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _entitiySet.ToListAsync(cancellationToken);


        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitiySet.Where(expression).ToListAsync(cancellationToken);


        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitiySet.FirstOrDefaultAsync(expression, cancellationToken);


        public void Remove(T entity)
            => RepositoryContext.Remove(entity);


        public void RemoveRange(IEnumerable<T> entities)
            => RepositoryContext.RemoveRange(entities);


        public void Update(T entity)
            => RepositoryContext.Update(entity);


        public void UpdateRange(IEnumerable<T> entities)
            => RepositoryContext.UpdateRange(entities);
    }
}
