using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.IRepositories
{
    public interface IProductOrderRepository : IGenericRepository<ProductOrder>
    {
        public List<ProductOrder> GetProductOrdersWithPaging(int pageNum, int countPerPage);
    }
}
