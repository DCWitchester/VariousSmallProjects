using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebServiceEvidenta.SerializationClasses
{
    /// <summary>
    /// the root element for the ProductDisplay XML Object
    /// </summary>
    [XmlRoot(ElementName = "Stocuri")]
    public class ProductStocks
    {
        /// <summary>
        /// the base product code
        /// </summary>
        public String ProductCode { get; set; } 
        /// <summary>
        /// the base product name
        /// </summary>
        public String ProductName { get; set; }
        /// <summary>
        /// the main list for containing the producst stocks
        /// </summary>
        public List<ProductStock> ProductStockList { get; set; } = new List<ProductStock>();

        /// <summary>
        /// this function will instantiate the current object from the data table and return the instance
        /// </summary>
        /// <param name="dt">the given data table</param>
        public void GetProductStocksFromDataTable(DataTable dt)
        {
            this.ProductCode = dt.Rows[0][0].ToString().Trim();
            this.ProductName = dt.Rows[0][1].ToString().Trim();

            foreach(DataRow element in dt.Rows)
            {
                ProductStockList.Add(new ProductStock
                {
                    ManagementUnit = element[2].ToString(),
                    ProductPrice = (Double)(Decimal)element[3],
                    ProductStockQuantity = (Double)(Decimal)element[4]
                });
            }
        }
    }
}