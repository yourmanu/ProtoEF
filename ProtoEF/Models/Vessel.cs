using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoEF.Models
{
    public class Vessel
    {
        public int VesselId { get; set; }
        [Required]
        [Display(Name ="Vessel Name")]
        public string VesselName { get; set; }

    }
}
