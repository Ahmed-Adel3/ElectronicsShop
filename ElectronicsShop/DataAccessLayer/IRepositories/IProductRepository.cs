using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public List<Product> GetHomePageProducts(int pageNum, int countPerPage);
    }
}
