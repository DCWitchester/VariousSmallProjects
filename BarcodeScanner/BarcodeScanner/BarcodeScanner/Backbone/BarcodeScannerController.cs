using BarcodeScanner.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Essentials;
using BarcodeScanner.ObjectClasses;
using Newtonsoft.Json;

namespace BarcodeScanner.Backbone
{
    public class BarcodeScannerController
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the main navigation object
        /// </summary>
        protected INavigation pageNavigation { get; set; }

        /// <summary>
        /// the initial Barcode Object
        /// </summary>
        protected Barcode barcode { get; set; }

        /// <summary>
        /// the Observable Collection bound to the Grid item on the main Page
        /// </summary>
        protected ObservableCollection<Products> products { get; set; }

        /// <summary>
        /// the public settings instance for the program
        /// </summary>
        protected static PublicSettings defaultSettings { get; set; }
        /// <summary>
        /// the user specific settings for the instance
        /// </summary>
        protected static PublicSettings userSettings { get; set; } = new PublicSettings();
        /// <summary>
        /// the entry document for the instance
        /// </summary>
        protected EntryDocument entryDocument { get; set; } = new EntryDocument();

        /// <summary>
        /// the onChange Action Caller => will contain the invocable action on page refresh
        /// </summary>
        public event Action OnResetItemList;
#pragma warning restore IDE1006 // Naming Styles

        #endregion

        #region Callers 
        /// <summary>
        /// the navigation page caller
        /// </summary>
        public INavigation PageNavigation
        {
            get => pageNavigation;
            set => pageNavigation = value;
        }
        /// <summary>
        /// the barcode page caller
        /// </summary>
        public Barcode Barcode 
        {
            get => barcode;
            set => barcode = value;
        }
        /// <summary>
        /// the page observable collection
        /// </summary>
        public ObservableCollection<Products> Products
        {
            get => products;
            set => products = value;
        }
        /// <summary>
        /// the default settings
        /// </summary>
        public static PublicSettings DefaultSettings
        {
            get => defaultSettings;
            set => defaultSettings = value;
        }

        /// <summary>
        /// the user specific settings
        /// </summary>
        public static PublicSettings PublicSettings
        {
            get => userSettings;
            set => userSettings = value;
        }

        /// <summary>
        /// the base entry document
        /// </summary>
        public EntryDocument EntryDocument 
        { 
            get => entryDocument; 
            set => entryDocument = value; 
        }

        /// <summary>
        /// the serialized qunatities file used for calling the webService
        /// </summary>
        public String GetQuantitiesJsonFile => JsonConvert.SerializeObject(new Quantities(this.EntryDocument, this.Products.ToList()));
        #endregion

        #region Constructors
        /// <summary>
        /// the base constructor without parameters
        /// </summary>
        public BarcodeScannerController() 
        {
            barcode = new ObjectClasses.Barcode();
            products = new ObservableCollection<ObjectClasses.Products>();
            GetUserSettings();
        }

        /// <summary>
        /// the base constructor with the INavigation received from the parent page
        /// </summary>
        /// <param name="navigation">the inavigation</param>
        public BarcodeScannerController(INavigation navigation)
        {
            barcode = new ObjectClasses.Barcode();
            products = new ObservableCollection<ObjectClasses.Products>();
            pageNavigation = navigation;
            GetUserSettings();
        }
        #endregion

        #region Functionality
        /// <summary>
        /// this function will get the specific settings for the instance user
        /// </summary>
        public static void GetUserSettings()
        {
            userSettings.AdminControl   = Preferences.Get(SettingsKeys.AdminControl, defaultValue: defaultSettings.AdminControl);
            userSettings.WebServicePath = Preferences.Get(SettingsKeys.WebServicePath, defaultValue: defaultSettings.WebServicePath);
            userSettings.UseBatches     = Preferences.Get(SettingsKeys.UseBatches, defaultValue: defaultSettings.UseBatches);
            userSettings.UserBundle     = Preferences.Get(SettingsKeys.UserBundle, defaultValue: defaultSettings.UserBundle);
        }

        /// <summary>
        /// this function will set the specific settings for the instance user
        /// </summary>
        public static void SetUserSettings()
        {
            Preferences.Set(SettingsKeys.AdminControl, userSettings.AdminControl);
            Preferences.Set(SettingsKeys.UseBatches, userSettings.UseBatches);
            Preferences.Set(SettingsKeys.WebServicePath, userSettings.WebServicePath);
            Preferences.Set(SettingsKeys.UserBundle, userSettings.UserBundle);
        }

        /// <summary>
        /// this function will reset the user settings for the program instance to their default values
        /// </summary>
        public static void ResetSettingsToDefaults()
        {
            Preferences.Clear();
        }

        /// <summary>
        /// this function will reset the instance controller to its original state
        /// </summary>
        public void ResetInstanceElements()
        {
            //the new initialization of the barcode element
            barcode = new Barcode();
            //we clear the products list
            products.Clear();
            //we initialize a new entry document
            entryDocument = new EntryDocument();
        }
        #endregion
    }
}
