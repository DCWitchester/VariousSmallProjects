using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeScanner.Services
{
    class WebMethods
    {
        #region Get Functions
        public static String GetProductDetails              => Backbone.BarcodeScannerController.PublicSettings.StorageService + "/GetProductName?ProductCode=";
        public static String GetProductStock                => Backbone.BarcodeScannerController.PublicSettings.StorageService + "/GetProductStock?ProductCode=";
        public static String GetProductInfo                 => Backbone.BarcodeScannerController.PublicSettings.StorageService + "/GetProductInfo?ProductCode=";
        public static String GetProductStockViaExternalCode => Backbone.BarcodeScannerController.PublicSettings.StorageService + "/GetProductStockViaExternalCode?ProductCode=";
        public static String GetPartnerDisplay              => Backbone.BarcodeScannerController.PublicSettings.StorageService + "/GetPartnerDisplay?PartnerCode=";
        public static String GetPartnersDisplay             => Backbone.BarcodeScannerController.PublicSettings.StorageService + "/GetPartnersDisplay";
        public static String GetManagementUnitDisplay       => Backbone.BarcodeScannerController.PublicSettings.StorageService + "/GetManagementUnitDisplay?ManagementUnitCode=";
        public static String GetManagementUnitsDisplay      => Backbone.BarcodeScannerController.PublicSettings.StorageService + "/GetManagementUnitsDisplay";
        #endregion Get Functions

        #region Set Functions
        public static String SetProductQuantity             => Backbone.BarcodeScannerController.PublicSettings.StorageService + "/SetQuantityFile?QuantityFile=";
        #endregion Set Functions

    }
}
