using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeScanner.ObjectClasses
{
    public class Qunatities
    {
        /// <summary>
        /// the product quantities list used for the JSON serialization
        /// </summary>
        public List<ProductQuantity> ProductQuantities { get; set; } = new List<ProductQuantity>();

        /// <summary>
        /// this function will transfer the contents of a given products list into the product Quantities list
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public String SetQuantitiesFromProductList(List<Products> products)
        {
            foreach(var element in products)
            {
                ProductQuantities.Add(new ProductQuantity
                {
                    ProductCode = element.ProductCode,
                    ProductName = element.ProductName,
                    ProductPrice = 0,
                    ProductBatch = element.ProductBatch,
                    ProductBatchDate = element.ProductBatchDate,
                    ProductQunatity = Convert.ToDouble(element.ProductQuantity)

                });
            }
            String json = JsonConvert.SerializeObject(this);
            return json;
        }
    }
}
