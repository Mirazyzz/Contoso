﻿using System.Linq.Expressions;

namespace Contoso.Domain.Interfaces.Repostiory
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
        Task<T> FindById(int id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();

        Task CreateRange(IEnumerable<T> entity);
    }
}
