using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BarcodeScanner.Services
{
    class WebServiceMethods
    {
        #region Public Functions
        #region Element Functions
        public static String GetProductName(String productCode)
        {
            HttpClient http = new HttpClient();
            String xmlDocument = http.GetStringAsync(WebMethods.GetProductDetails + productCode.Substring(0,12)).Result;
            //and deserialize the object to the needed structure
            return DeserializeProductDisplayDocument(xmlDocument);
                        
        }

        public static String GetManagementUnitName(String managementUnitCode)
        {
            HttpClient http = new HttpClient();
            //we initialize a string for containing the retrieved xmlDocuments
            try
            {
                String xmlDocument = http.GetStringAsync(WebMethods.GetManagementUnitDisplay + managementUnitCode.Substring(0, 4)).Result;
                return DeserializeManagementUnitDisplayDocument(xmlDocument);
            }
            catch { return null; }
        }

        public static String GetPartnerName(String partnerCode)
        {
            HttpClient http = new HttpClient();
            try
            {
                String xmlDocument = http.GetStringAsync(WebMethods.GetPartnerDisplay + partnerCode.Substring(0, 4)).Result;
                return DeserializePartnerDisplayDocument(xmlDocument);
            }
            catch { return null; }
        }

        /// <summary>
        /// this function will function to send the product qunatities file
        /// </summary>
        /// <param name="products">the given products list</param>
        public static void SendProductQunatitites(List<ObjectClasses.Products> products, ObjectClasses.EntryDocument entryDocument)
        {
            ObjectClasses.Quantities quantities = new ObjectClasses.Quantities();
            String json = JsonConvert.SerializeObject(quantities.SetQuantitiesFromProductList(products).SetHeaderFromEntryDocument(entryDocument));

            HttpClient httpClient = new HttpClient();
            httpClient.GetAsync(WebMethods.SetProductQuantity + json);
        }

        /// <summary>
        /// this function will function to send the product qunatities file
        /// </summary>
        /// <param name="products">the given products list</param>
        public static void SendProductQunatitites(String json)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.GetAsync(WebMethods.SetProductQuantity + json);
        }
        #endregion

        #region List Functions 
        public static ObservableCollection<XmlClasses.PartnerDisplay> GetPartnersDisplay()
        {
            HttpClient http = new HttpClient();
            try
            {
                String elements = http.GetStringAsync(WebMethods.GetPartnersDisplay).Result;
                return DeserializePartnersDisplayDocument(elements);
            }
            catch { return null; }
            
        }

        public static ObservableCollection<XmlClasses.ManagementUnit> GetManagementUnitsDisplay()
        {
            HttpClient http = new HttpClient();
            try
            {
                String elements = http.GetStringAsync(WebMethods.GetManagementUnitsDisplay).Result;
                return DeserializeManagementUnitsDisplayDocument(elements);
            }
            catch { return null; }
        }
        #endregion

        #endregion

        #region Private Functions
        #region Element Functions
        /// <summary>
        /// this function will deserialize the xml Menu Document
        /// </summary>
        /// <param name="xmlDocument">the retrieved XmlDocument</param>
        private static String DeserializeProductDisplayDocument(String xmlDocument)
        {
            //we initialize a serializer over the menu object
            XmlSerializer serializer = new XmlSerializer(typeof(XmlClasses.ProductDisplay));
            //initialize a new Meniu class
            XmlClasses.ProductDisplay product = new XmlClasses.ProductDisplay();
            //then using a text reader
            using (TextReader reader = new StringReader(xmlDocument))
            {
                //we deserialize the meniu to a class
                product = (XmlClasses.ProductDisplay)serializer.Deserialize(reader);
            }
            return product.ProductName;
        }

        /// <summary>
        /// this function will deserialize the xml Menu Document
        /// </summary>
        /// <param name="xmlDocument">the retrieved XmlDocument</param>
        private static String DeserializeManagementUnitDisplayDocument(String xmlDocument)
        {
            //we initialize a serializer over the menu object
            XmlSerializer serializer = new XmlSerializer(typeof(XmlClasses.ManagementUnit));
            //initialize a new Meniu class
            XmlClasses.ManagementUnit managementUnit = new XmlClasses.ManagementUnit();
            //then using a text reader
            using (TextReader reader = new StringReader(xmlDocument))
            {
                //we deserialize the meniu to a class
                managementUnit = (XmlClasses.ManagementUnit)serializer.Deserialize(reader);
            }
            return managementUnit.ManagementUnitName;
        }

        /// <summary>
        /// this function will deserialize the xml Menu Document
        /// </summary>
        /// <param name="xmlDocument">the retrieved XmlDocument</param>
        private static String DeserializePartnerDisplayDocument(String xmlDocument)
        {
            //we initialize a serializer over the menu object
            XmlSerializer serializer = new XmlSerializer(typeof(XmlClasses.PartnerDisplay));
            //initialize a new class
            XmlClasses.PartnerDisplay partner = new XmlClasses.PartnerDisplay();
            //then using a text reader
            using (TextReader reader = new StringReader(xmlDocument))
            {
                //we deserialize the meniu to a class
                partner = (XmlClasses.PartnerDisplay)serializer.Deserialize(reader);
            }
            return partner.PartnerName;
        }
        #endregion

        #region List Functions

        private static ObservableCollection<XmlClasses.PartnerDisplay> DeserializePartnersDisplayDocument(String xmlDocument)
        {
            //we initialize a serializer over the menu object
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<XmlClasses.PartnerDisplay>));
            //initialize a new class
            ObservableCollection<XmlClasses.PartnerDisplay> partners = new ObservableCollection<XmlClasses.PartnerDisplay>();
            //then using a text reader
            using (TextReader reader = new StringReader(xmlDocument))
            {
                //we deserialize the object a class
                partners = (ObservableCollection<XmlClasses.PartnerDisplay>)serializer.Deserialize(reader);
            }
            return partners;
        }

        private static ObservableCollection<XmlClasses.ManagementUnit> DeserializeManagementUnitsDisplayDocument(String xmlDocument)
        {
            //we initialize a serializer over the menu object
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<XmlClasses.ManagementUnit>));
            //initialize a new class
            ObservableCollection<XmlClasses.ManagementUnit> managementUnits = new ObservableCollection<XmlClasses.ManagementUnit>();
            //then using a text reader
            using (TextReader reader = new StringReader(xmlDocument))
            {
                //we deserialize the object a class
                managementUnits = (ObservableCollection<XmlClasses.ManagementUnit>)serializer.Deserialize(reader);
            }
            return managementUnits;
        }
        #endregion
        #endregion
    }
}
