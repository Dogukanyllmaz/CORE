﻿using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity, new()
    {

        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>> filter = null!);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity); 
        Task DeleteAsync(T entity);

    }
}
