using System.ComponentModel.DataAnnotations;

namespace ProtoEF.Models
{
    public class Country
    {
        public int CountryId { get; set; }

        [Required]
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }

        [Required]
        public string Name { get; set; }
    }
}