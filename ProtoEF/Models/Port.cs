using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoEF.Models
{
    public class Port
    {
        public int PortId { get; set; }
        [Required]
        [Display(Name ="Port Type")]
        public string PortType { get; set; }
        [Required]
        [Display(Name = "Port Code")]
        public string PortCode { get; set; }
        [Required]
        [Display(Name = "Port Name")]
        public string PortName { get; set; }
    }
}
