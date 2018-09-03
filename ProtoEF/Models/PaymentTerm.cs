using System.ComponentModel.DataAnnotations;

namespace ProtoEF.Models
{
    public class PaymentTerm
    {
        public int PaymentTermId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Credit Days")]
        public int CreditDays { get; set; }
    }
}