using Marketing.Domain.Repositories;
using Marketing.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarketingDbContext _context;
        public UnitOfWork(MarketingDbContext context)
        {
            _context = context;
            Distributors = new DistributorRepository(_context);
            Sales = new SalesRepository(_context);
            Products = new ProductRepository(_context);

        }
        public IDistributorRepository Distributors { get; private set; }
        public ISalesRepository Sales { get; private set; }
        public IProductRepository Products { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}
