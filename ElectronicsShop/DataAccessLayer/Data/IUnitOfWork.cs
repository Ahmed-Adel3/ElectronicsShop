using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Data
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IProductTypeRepository ProductTypeRepository { get; }
        IProductOrderRepository ProductOrderRepository { get; }


        void SaveChanges();
    }
}
