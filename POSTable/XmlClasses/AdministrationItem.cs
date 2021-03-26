using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.XmlClasses
{
    /// <summary>
    /// the main Administration Item for use with XML Serialization
    /// </summary>
    public class AdministrationItem
    {
        [XmlAttribute]
        public String AdminitrationCode { get; set; }
        [XmlAttribute]
        public String AdministrationName { get; set; }
        [XmlAttribute]
        public Int32 DisplayOrder { get; set; }
    }
}
