using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.XmlClasses
{
    /// <summary>
    /// the SaleItem Object
    /// </summary>
    public class SaleItem
    {
        [XmlAttribute]
        public Int32 ProductCode { get; set; }
        [XmlAttribute]
        public String ProductName { get; set; }
        [XmlAttribute]
        public Double ProductPrice { get; set; }
        [XmlAttribute]
        public Int32 ProductQuantity { get; set; }
        /*
        [XmlAttribute]
        public DateTime SaleTime { get; set; }
        */
        [XmlAttribute]
        public String SaleClient { get; set; }
        [XmlAttribute]
        public Int32 Table { get; set; }
    }
}
