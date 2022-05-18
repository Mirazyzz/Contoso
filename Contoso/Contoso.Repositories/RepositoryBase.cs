using Contoso.Domain.Interfaces.Repostiory;
using Contoso.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Contoso.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ContosoDbContext _context;

        public RepositoryBase(ContosoDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T?> FindById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);

            return entity;
        }

        public async Task CreateRange(IEnumerable<T> entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
