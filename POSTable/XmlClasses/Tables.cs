using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.XmlClasses
{
    [XmlRoot(ElementName = "Mese")]
    public class Tables
    {
#pragma warning disable IDE1006 // Naming Styles
        public List<Table> tables { get; set; } = new List<Table>();
#pragma warning restore IDE1006 // Naming Styles
    }
}
