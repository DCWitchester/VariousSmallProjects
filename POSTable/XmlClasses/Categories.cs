using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.XmlClasses
{
    /// <summary>
    /// the Root item for the XML Categories
    /// </summary>
    [XmlRoot(ElementName = "Gategorii")]
    public class Categories
    {
#pragma warning disable IDE1006 // Naming Styles
        public List<Category> categories { get; set; } = new List<Category>();
#pragma warning restore IDE1006 // Naming Styles
    }
}
