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

        public List<Product> GetHomePageProducts(int pageNum,int countPerPage)
        {
            return All.Skip((pageNum - 1) * countPerPage).Take(countPerPage).Include(a => a.ProductType).ToList();
        }
    }
}
