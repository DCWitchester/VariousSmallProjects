using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.XmlClasses
{
    /// <summary>
    /// the XmlRoot for the Administrations List
    /// </summary>
    [XmlRoot(ElementName = "Gest")]
    public class Administrations
    {
        public List<AdministrationItem> administrations { get; set; } = new List<AdministrationItem>();

    }
}
