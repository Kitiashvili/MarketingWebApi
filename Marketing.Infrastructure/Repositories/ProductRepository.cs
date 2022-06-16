using Marketing.Domain.Entities;
using Marketing.Domain.Repositories;
using Marketing.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketing.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MarketingDbContext marketingDbContext)
           : base(marketingDbContext)
        {

        }
    }
}
