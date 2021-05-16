using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.IRepositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext dbContext)
            : base(dbContext)
        { }

        public List<Product> GetProductsWithPaging(int pageNum,int countPerPage,int typeId=0)
        {
            return GetListByType(typeId)
                .Skip((pageNum - 1) * countPerPage)
                .Take(countPerPage)
                .Include(a => a.ProductType)
                .ToList();
        }
      
        public int GetGridCount(int typeId)
        {
            return GetListByType(typeId).Count();
        }

        private IQueryable<Product> GetListByType(int typeId)
        {
            if (typeId != 0)
                return FindBy(a => a.ProductType.ProductTypeId == typeId);
            return All;
        }
    }
}
