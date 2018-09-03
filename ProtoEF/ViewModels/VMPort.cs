using ProtoEF.Models;
using System.Collections.Generic;


namespace ProtoEF.ViewModels
{
    public class VMPort
    {
        public VMPort()
        {
            Ports = new List<Port>();
            PortTypes = new List<PortType>
                {
                    new PortType { PortTypeId = "S", PortTypeName = "Sea" },
                    new PortType { PortTypeId = "A", PortTypeName = "Air" }
                };
        }

        public IEnumerable<Port> Ports { get; set; }
        public IEnumerable<PortType> PortTypes { get; set; }
    }

    public class PortType
    {
        public string PortTypeId { get; set; }
        public string PortTypeName { get; set; }
    }
}