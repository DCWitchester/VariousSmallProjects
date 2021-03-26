using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTable.ObjectStructures
{
    /// <summary>
    /// the main MenuItem Object used for Display
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// the Product Code
        /// </summary>
        public Int32 ProductCode { get; set; } = new Int32();
        /// <summary>
        /// the Product Name
        /// </summary>
        public String ProductName { get; set; } = String.Empty;
        /// <summary>
        /// the Product Price
        /// </summary>
        public Double ProductPrice { get; set; } = new Double();
        /// <summary>
        /// the Product Quantity
        /// </summary>
        public Int32 ProductQuantity { get; set; } = 0;
        /// <summary>
        /// the property used for Display Settings
        /// </summary>
        public Boolean IsSelected { get; set; } = false;
        /// <summary>
        /// the property used for the display order
        /// </summary>
        public Int32 DisplayOrder { get; set; } = 0;
        /// <summary>
        /// the property linked to the product category
        /// </summary>
        public Int32 ProductCategory { get; set; } = 0;
    }
}
