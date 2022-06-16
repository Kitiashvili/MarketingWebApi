using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Marketing.Domain.Entities
{
    public class Product : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
