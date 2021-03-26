using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.XmlClasses
{
    /// <summary>
    /// the XmlRoot for the waiter item
    /// </summary>
    [XmlRoot(ElementName = "Ospatar")]
    public class Waiter
    {
        [XmlAttribute]
        public Int32 ID { get; set; }

        [XmlAttribute]
        public String WaiterCode { get; set; }

        [XmlAttribute]
        public String WaiterName { get; set; }
    }
}
