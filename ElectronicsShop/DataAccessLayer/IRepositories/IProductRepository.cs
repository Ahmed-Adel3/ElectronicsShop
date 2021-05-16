using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public List<Product> GetProductsWithPaging(int pageNum, int countPerPage, int typeId = 0);
        int GetGridCount(int typeId);
    }
}
