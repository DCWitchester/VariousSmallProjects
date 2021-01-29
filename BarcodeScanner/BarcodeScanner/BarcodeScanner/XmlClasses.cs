using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BarcodeScanner
{
    public class XmlClasses
    {
        /// <summary>
        /// the root element for the ProductDisplay XML Object
        /// </summary>
        [XmlRoot(ElementName = "Produs")]
        public class ProductDisplay
        {
            //The Product Name and Price are not [XmlAtrributes] because it caused errors on deserialization.
            /// <summary>
            /// The Product Name
            /// </summary>
            public String ProductName { get; set; }
            /// <summary>
            /// The Product Price
            /// </summary>
            public String ProductPrice { get; set; }
        }


        [XmlRoot(ElementName = "Gestiune")]
        public class ManagementUnit
        {
            public String ManagementUnitCode { get; set; }
            public String ManagementUnitName { get; set; }
        }


        [XmlRoot(ElementName = "Partener")]
        public class PartnerDisplay
        {
            /// <summary>
            /// the PartnerCode for the item
            /// </summary>
            public String PartnerCode { get; set; }
            /// <summary>
            /// the PartnerName for the item
            /// </summary>
            public String PartnerName { get; set; }
            /// <summary>
            /// the Partners FiscalCode
            /// </summary>
            public String PartnerFiscalCode { get; set; }
        }


    }
}
