using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoEF.Models
{
    public class Jobtype
    {
        public string JobType { get; set; }
        public string Name { get; set; }
        public int JobYear { get; set; }
        public string CostCenter { get; set; }
        public string JobPrefix { get; set; }
        public int JobNumber { get; set; }
        public int MaxJobNumber { get; set; }
        public int JobNumberLength { get; set; }
    }
}
