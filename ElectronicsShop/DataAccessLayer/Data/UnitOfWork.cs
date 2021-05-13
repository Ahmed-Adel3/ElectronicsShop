using DataAccessLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer.Data
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        private IProductRepository _productRepository { get; }
        private IProductTypeRepository _productTypeRepository { get; }
        private IProductOrderRepository _productOrderRepository { get; }
        public IProductRepository ProductRepository => _productRepository;
        public IProductTypeRepository ProductTypeRepository => _productTypeRepository;
        public IProductOrderRepository ProductOrderRepository => _productOrderRepository;

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
