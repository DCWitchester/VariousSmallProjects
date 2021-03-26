using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POSTable.XmlClasses
{
    /// <summary>
    /// the Answer XML Element
    /// </summary>
    [XmlRoot(ElementName = "Raspuns")]
    public class Answer
    {
        public Boolean Valoare { get; set; }
    }
}
