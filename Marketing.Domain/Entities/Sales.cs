using System;
using System.Collections.Generic;
using System.Text;

namespace Marketing.Domain.Entities
{
    public class Sales : Entity
    {
        public Guid SalesCode { get; set; }
        public DateTime DateSold { get; set; }
        public string SoldProductCode { get; set; }
        public decimal SoldPrdouctCost { get; set; }
        public decimal SoldProductUnitPrice { get; set; }
        public decimal SoldProductTotalPrice { get; set; }
        public int? DistributorId { get; set; }
        public virtual Distributor Distributor { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
