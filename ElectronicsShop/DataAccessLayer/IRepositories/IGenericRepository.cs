using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        IQueryable<T> GetAllByPage(int pageNumber, int pageSize);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllByPageAsync(int pageNumber, int pageSize);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<List<T>> FindByAsnc(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        Task<T> AddAsync(T entity);
        void Delete(T entity);
        Task<int> DeleteAsync(T entity);
        void Edit(T entity);
        Task<T> EditAsync(T entity, int id);
        int Count();
        Task<int> CountAsync();
    }
}
