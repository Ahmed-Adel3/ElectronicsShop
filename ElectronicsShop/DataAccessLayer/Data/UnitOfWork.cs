using DataAccessLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public IProductRepository _productRepository { get; }
        public IProductTypeRepository _productTypeRepository { get; }
        public IProductOrderRepository _productOrderRepository { get; }
        public IProductRepository ProductRepository => _productRepository;
        public IProductTypeRepository ProductTypeRepository => _productTypeRepository;
        public IProductOrderRepository ProductOrderRepository => _productOrderRepository;
        public UnitOfWork(
            ApplicationContext context ,
            IProductRepository productRepository,
            IProductTypeRepository ProductTypeRepository,
            IProductOrderRepository ProductOrderRepository )
        {
            _context = context;
            _productRepository = productRepository;
            _productTypeRepository = ProductTypeRepository;
            _productOrderRepository = ProductOrderRepository;
        }
        public void SaveChanges()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    this._context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    saveFailed = true;
                    ex.Entries.Single().Reload();
                }

            } while (saveFailed);
        }
    }
}
