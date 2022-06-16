using Marketing.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Marketing.Domain.Entities
{
    public class AddressInfo : Entity
    {
        public AddressType AddressType { get; set; }
        [Required]
        [MaxLength(100)]
        [StringLength(100, ErrorMessage = "Max length 100 charachers")]
        public string AddressDetail { get; set; }
    }
}
