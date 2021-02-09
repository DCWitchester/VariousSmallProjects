using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BarcodeScanner.ObjectClasses
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

        protected ObservableCollection<StockDisplay> stockDisplay { get; set; } = new ObservableCollection<StockDisplay>();
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

        public ObservableCollection<StockDisplay> StockDisplay
        {
            get => stockDisplay;
            set => stockDisplay = value;
        }
        #endregion
    }
}
