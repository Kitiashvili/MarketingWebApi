using Marketing.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Marketing.Domain.Entities
{
    public class PersonalInfo : Entity
    {
        [Required]
        public DocumentType DocumentType { get; set; }
        [MaxLength(10)]
        [StringLength(10, ErrorMessage = "Max length 10 charachers")]
        public string DocumentSeries { get; set; }
        [MaxLength(10)]
        [StringLength(10, ErrorMessage = "Max length 10 charachers")]
        public string DocumentNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime IssueData { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TermDate { get; set; }
        [Required]
        [MaxLength(50)]
        [StringLength(50, ErrorMessage = "Max length 50 charachers")]
        public string PersonalNo { get; set; }
        [MaxLength(100)]
        [StringLength(100, ErrorMessage = "Max length 100 charachers")]
        public string Agency { get; set; }

    }
}
