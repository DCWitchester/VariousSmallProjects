using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.XmlClasses
{
    /// <summary>
    /// the MenuItem Object 
    /// </summary>
    public class MenuItem
    {
        [XmlAttribute]
        public Int32 ProductCode { get; set; }
        [XmlAttribute]
        public String ProductName { get; set; }
        [XmlAttribute]
        public Double ProductPrice { get; set; }
        [XmlAttribute]
        public Int32 ProductCategory { get; set; }
        [XmlAttribute]
        public Int32 DisplayOrder { get; set; }
    }
}
