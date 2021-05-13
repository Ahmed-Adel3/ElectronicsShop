using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.IRepositories
{
    public class ProductOrderRepository : GenericRepository<ProductOrder>, IProductOrderRepository
    {
        public ProductOrderRepository(ApplicationContext dbContext)
            : base(dbContext)
        { }
    }
}
