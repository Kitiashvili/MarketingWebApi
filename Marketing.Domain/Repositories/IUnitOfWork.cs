using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDistributorRepository Distributors { get; }
        ISalesRepository Sales { get; }
        IProductRepository Products { get; }

        Task CompleteAsync();

    }
}
