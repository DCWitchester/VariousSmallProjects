using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebServiceEvidenta.SerializationClasses.ItemClasses;

namespace WebServiceEvidenta.SerializationClasses
{
    public class ProductStockDisplay
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        protected String productBarcode { get; set; } = String.Empty;
        protected String productCode { get; set; } = String.Empty;
        protected String productName { get; set; } = String.Empty;
        protected String partnerCode { get; set; } = String.Empty;
        protected String partnerName { get; set; } = String.Empty;

        protected List<StockDisplay> stockDisplay { get; set; } = new List<StockDisplay>();
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Callers
        public String ProductBarcode
        {
            get => productBarcode;
            set => productBarcode = value;
        }
        public String ProductCode
        {
            get => productCode;
            set => productCode = value;
        }
        public String ProductName
        {
            get => productName;
            set => productName = value;
        }
        public String PartnerCode
        {
            get => partnerCode;
            set => partnerCode = value;
        }
        public String PartnerName
        {
            get => partnerName;
            set => partnerName = value;
        }

        public List<StockDisplay> StockDisplay
        {
            get => stockDisplay;
            set => stockDisplay = value;
        }
        #endregion

        public void GetDisplayItemsFromDataTable(DataTable dataTable)
        {
            this.ProductCode = dataTable.Rows[0][0].ToString().Trim();
            this.ProductName = dataTable.Rows[0][1].ToString().Trim();
            this.PartnerCode = dataTable.Rows[0][4].ToString().Trim();
            this.PartnerName = dataTable.Rows[0][5].ToString().Trim();

            foreach(DataRow item in dataTable.Rows) 
            {
                StockDisplay.Add(new StockDisplay
                {
                    ManagementUnitCode = item[2].ToString().Trim(),
                    ManagementUnitName = item[3].ToString().Trim(),
                    Price = (Double)(Decimal)item[6],
                    Quantity = (Double)(Decimal)item[7]
                });
            }
        }
    }
}