using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeScanner.Settings
{
    public class PublicSettings
    {
        private String webServicePath { get; set; }
        /// <summary>
        /// the webService Caller Path
        /// </summary>
        public String WebServicePath 
        { 
            get => webServicePath; 
            set => webServicePath = value; 
        }
        /// <summary>
        /// the admin path Caller Path
        /// </summary>
        public Boolean AdminControl { get; set; }
        /// <summary>
        /// the use of batches for products
        /// </summary>
        public Boolean UseBatches { get; set; }

        public String UserBundle { get; set; }

        /// <summary>
        /// the main Storage Service Web Path
        /// </summary>
        public String StorageService => webServicePath + "/WebServices/StorageService.asmx/";
        /// <summary>
        /// the main Product Display Web Path
        /// </summary>
        public String ProductDisplay => webServicePath + "/WebServices/ProductDisplay.asmx/";
    }
}
