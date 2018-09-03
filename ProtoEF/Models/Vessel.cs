using System.ComponentModel.DataAnnotations;

namespace ProtoEF.Models
{
    public class Vessel
    {
        public int VesselId { get; set; }

        [Required]
        [Display(Name = "Vessel Name")]
        public string VesselName { get; set; }
    }
}