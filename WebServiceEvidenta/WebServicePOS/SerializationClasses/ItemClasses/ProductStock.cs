using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebServiceEvidenta.SerializationClasses
{
    [XmlRoot(ElementName = "Stocuri")]
    public class ProductStock
    {
        /// <summary>
        /// the Management Unit for the current Stock
        /// </summary>
        public String ManagementUnit { get; set; }
        /// <summary>
        /// the price of the current stock
        /// </summary>
        public Double ProductPrice { get; set; }
        /// <summary>
        /// the quantity of the current stock
        /// </summary>
        public Double ProductStockQuantity { get; set; }
    }
}