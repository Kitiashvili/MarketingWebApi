using Marketing.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Marketing.Domain.Entities
{
    public class Distributor : Entity
    {
        public Guid DistributorCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public AddressInfo AddressInfo { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
        public virtual ICollection<Distributor> ChildDistributors { get; set; }
        public int? RecomendatorId { get; set; }
        public virtual Distributor Recomendator { get; set; }
    }
}
