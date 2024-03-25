using api.Contracts;
using api.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _context;
        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

        }

        public IQueryable<T> FindAll()
        {   
               return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {

            return _context.Set<T>()
            .Where(expression)
            .AsNoTracking();          
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
