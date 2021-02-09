using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceEvidenta.SerializationClasses.ItemClasses
{
    public class StockDisplay
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        protected String managementUnitCode { get; set; } = String.Empty;
        protected String managementUnitName { get; set; } = String.Empty;
        protected Double quantity { get; set; } = new Double();
        protected Double price { get; set; } = new Double();
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Callers 
        public String ManagementUnitCode
        {
            get => managementUnitCode;
            set => managementUnitCode = value;
        }
        public String ManagementUnitName
        {
            get => managementUnitName;
            set => managementUnitName = value;
        }
        public Double Quantity
        {
            get => quantity;
            set => quantity = value;
        }
        public Double Price
        {
            get => price;
            set => price = value;
        }
        #endregion
    }
}