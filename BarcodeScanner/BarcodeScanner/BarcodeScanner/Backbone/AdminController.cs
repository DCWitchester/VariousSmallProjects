using BarcodeScanner.ObjectClasses;
using BarcodeScanner.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BarcodeScanner.Backbone
{
    public class AdminController
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the main navigation object
        /// </summary>
        protected INavigation pageNavigation { get; set; }

        /// <summary>
        /// the public settings instance for the program
        /// </summary>
        protected static PublicSettings defaultSettings { get; set; }
        /// <summary>
        /// the user specific settings for the instance
        /// </summary>
        protected static PublicSettings userSettings { get; set; } = new PublicSettings();

        /// <summary>
        /// the product stock object used for display on the info page
        /// </summary>
        protected ProductStockDisplay productStockDisplay { get; set; }
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

        public static PublicSettings DefaultSettings
        {
            get => defaultSettings;
            set => defaultSettings = value;
        }

        public static PublicSettings PublicSettings
        {
            get => userSettings;
            set => userSettings = value;
        }

        public ProductStockDisplay ProductStockDisplay
        {
            get => productStockDisplay;
            set => productStockDisplay = value;
        }
        #endregion

        #region Constructors
        public AdminController()
        {
            ProductStockDisplay = new ProductStockDisplay();
            GetUserSettings();
        }
        public AdminController(INavigation navigation)
        {
            ProductStockDisplay = new ProductStockDisplay();
            PageNavigation = navigation;
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
        #endregion
    }
}
