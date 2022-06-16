using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Marketing.Domain.DTO
{
    public class SalesDTO
    { 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateSold { get; set; }
        public string SoldProductCode { get; set; }
        public decimal SoldPrdouctCost { get; set; }
        public decimal SoldProductUnitPrice { get; set; }
        public decimal SoldProductTotalPrice { get; set; }
        public string DistributorCode { get; set; }

    }
}
