using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.XmlClasses
{
    /// <summary>
    /// The Sale Object
    /// *Deprecated*
    /// </summary>
    [XmlRoot(ElementName = "Vanzare")]
    public class Sale
    {
        public List<SaleItem> Vanzare = new List<SaleItem>();
    }
}
