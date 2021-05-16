using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.IRepositories
{
    public class ProductOrderRepository : GenericRepository<ProductOrder>, IProductOrderRepository
    {
        public ProductOrderRepository(ApplicationContext dbContext)
            : base(dbContext)
        { }

        public List<ProductOrder> GetProductOrdersWithPaging(int pageNum, int countPerPage)
        {
            return All
            .Skip((pageNum - 1) * countPerPage)
            .Take(countPerPage)
            .Include(a => a.Client)
            .Include(a=>a.Product)
            .ToList();
        }
    }
}
