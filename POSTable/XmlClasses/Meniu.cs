using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.XmlClasses
{
    /// <summary>
    /// the Meniu Root Element
    /// </summary>
    [XmlRoot(ElementName = "Meniu")]
    public class Meniu
    {
        public List<MenuItem> Menu { get; set; } = new List<MenuItem>();
    }
}
