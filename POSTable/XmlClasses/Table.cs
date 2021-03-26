using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.XmlClasses
{
    public class Table
    {
        [XmlAttribute]
        public Int32 TableID { get; set; }

        [XmlAttribute]
        public Int32 Status { get; set; }

        [XmlAttribute]
        public Int32 WaiterID { get; set; }

        [XmlAttribute]
        public String WaiterCode { get; set; }

        [XmlAttribute]
        public String WaiterName { get; set; }
    }
}
