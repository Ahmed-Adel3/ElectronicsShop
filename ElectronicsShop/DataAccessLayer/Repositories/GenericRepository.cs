using DataAccessLayer.Data;
using DataAccessLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationContext _dbContext;
        public ApplicationContext DbContext => _dbContext ;

        protected GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> All => GetAll();

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public void Add(T entity)
        {
            EntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            DbContext.Set<T>().Add(entity);
        }

        public int Count()
        {
            return DbContext.Set<T>().Count();
        }

    }
}
