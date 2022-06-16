using Marketing.Domain.DTO;
using Marketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Domain.Repositories
{
    public interface IDistributorRepository : IGenericRepository<Distributor>
    {
        Task<Distributor> GetRecomendatorId(DistributorDTO disCode);
        Task<bool> IfCanBeRecomendator(Distributor distributor);
        Task<Distributor> GetSalesDistributorId(SalesDTO salesDTO);

    }
}
