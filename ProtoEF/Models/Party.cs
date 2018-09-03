using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProtoEF.Models
{
    public class Party
    {
        public int PartyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        [Display(Name = "A/C Code")]
        public string AccountCode { get; set; }

        [Display(Name = "Customs Code")]
        public string CustomsCode { get; set; }

        [Display(Name = "Tax No")]
        public string TaxNo { get; set; }

        [Required]
        [Display(Name = "Payment Term")]
        public int PaymentTermId { get; set; }

        [ForeignKey("PaymentTermId")]
        public virtual PaymentTerm PaymentTerm { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}