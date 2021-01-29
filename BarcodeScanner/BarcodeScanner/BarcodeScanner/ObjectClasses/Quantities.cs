using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BarcodeScanner.ObjectClasses
{
    public class Quantities
    {
        public String UserBundle { get; set; } = String.Empty;
        public String ManagementUnit { get; set; } = String.Empty;
        public String PartnerCode { get; set; } = String.Empty;
        public Int32 DocumentNumber { get; set; } = new Int32();
        public Boolean IsAviz { get; set; } = new Boolean();
        public String DocumentDate { get; set; } = String.Empty;

        /// <summary>
        /// the product quantities list used for the JSON serialization
        /// </summary>
        public List<ProductQuantity> ProductQuantities { get; set; } = new List<ProductQuantity>();

        /// <summary>
        /// this function will transfer the contents of a given products list into the product Quantities list
        /// </summary>
        /// <param name="products">the given products list</param>
        public Quantities SetQuantitiesFromProductList(List<Products> products)
        {
            foreach (var element in products)
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
            return this;
        }

        public Quantities SetHeaderFromEntryDocument(EntryDocument entryDocument)
        {
            this.UserBundle = Backbone.BarcodeScannerController.PublicSettings.UserBundle;
            this.ManagementUnit = entryDocument.ManagementUnitCode;
            this.PartnerCode = entryDocument.PartnerCode;
            this.DocumentNumber = entryDocument.DocumentNumber;
            this.DocumentDate = entryDocument.GetDateValue;
            this.IsAviz = entryDocument.IsNotice;
            return this;
        }

        public String GetJsonFile() => JsonConvert.SerializeObject(this);

        public Quantities(EntryDocument entryDocument,List<Products> products)
        {
            SetHeaderFromEntryDocument(entryDocument);
            SetQuantitiesFromProductList(products);
        }

        public Quantities() { }
    }
}
