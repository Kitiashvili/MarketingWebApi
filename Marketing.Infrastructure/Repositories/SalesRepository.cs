using Marketing.Domain.DTO;
using Marketing.Domain.Entities;
using Marketing.Domain.Repositories;
using Marketing.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Infrastructure.Repositories
{
    public class SalesRepository : GenericRepository<Sales>, ISalesRepository
    {
        public SalesRepository(MarketingDbContext marketingDbContext)
            : base(marketingDbContext)
        {

        }
    }
}
