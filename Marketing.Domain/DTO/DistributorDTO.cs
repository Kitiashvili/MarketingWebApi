using Marketing.Domain.Entities;
using Marketing.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Marketing.Domain.DTO
{
    public class DistributorDTO 
    {

        [Required]
        [StringLength(50, ErrorMessage = "Max length 50 charachers")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Max length 50 charachers")]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public AddressInfo AddressInfo { get; set; }
        public string RecomendatorCode { get; set; }
    }
}
