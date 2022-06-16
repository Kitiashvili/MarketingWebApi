using Marketing.Domain.DTO;
using Marketing.Domain.Entities;
using Marketing.Domain.Repositories;
using Marketing.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Infrastructure.Repositories
{
    public class DistributorRepository : GenericRepository<Distributor>, IDistributorRepository
    {
        public DistributorRepository(MarketingDbContext marketingDbContext)
            : base(marketingDbContext)
        {
            
        }

        public async Task<bool> IfCanBeRecomendator(Distributor recomendator)
        {
            if(recomendator != null )
            {
                var childCount = await Task.Run(() =>
                Query()
                    .Include(x => x.ChildDistributors)
                    .Where(x => x.Id == recomendator.Id)
                    .FirstOrDefault());
                var count = childCount.ChildDistributors.Count;

                if (count >= 3)
                    return false;

                var tmpId = recomendator.Id;
                var hierarchy = 0;            
                while (hierarchy < 5)
                {
                    var top = Query().FirstOrDefault(x => x.Id == tmpId);
                    if (top == null || !top.RecomendatorId.HasValue) { return true; }
                    tmpId = top.RecomendatorId.Value;
                    hierarchy+= 1;
                }
                return false;

                
            }
            else
            { return true; }
            
        }

        public  async Task<Distributor> GetRecomendatorId(DistributorDTO dDto)
        {
            try
            {
                var recomendator = await Task.Run(() => 
                FindByConditionAsync(x => x.DistributorCode
                .ToString() == dDto.RecomendatorCode.ToString()).Result.FirstOrDefault());; 
                return recomendator;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Distributor> GetSalesDistributorId(SalesDTO sDto)
        {
            var distributor = await Task.Run(() =>
            FindByConditionAsync(x => x.DistributorCode.ToString()
            == sDto.DistributorCode.ToString()).Result.FirstOrDefault());
            return distributor;
        }

    }
}
