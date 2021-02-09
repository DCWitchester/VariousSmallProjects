using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarcodeScanner.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminSettingsPage : ContentPage
    {
        #region LocalParameters
#pragma warning disable IDE1006
        /// <summary>
        /// the base instanceController object
        /// </summary>
        private Backbone.AdminController instanceController { get; set; }
        /// <summary>
        /// the local setting bound to the UI
        /// </summary>
        public Settings.PublicSettings localSettings { get; set; }
#pragma warning restore IDE1006
        #endregion

        #region Constructors
        /// <summary>
        /// the initialization of the settings page
        /// </summary>
        public AdminSettingsPage()
        {
            localSettings = Backbone.AdminController.PublicSettings;
            InitializeComponent();
        }

        /// <summary>
        /// the initialization of the scanner page with the instance controller passed as a parameter
        /// </summary>
        /// <param name="controller">the scanner page controller</param>
        public AdminSettingsPage(Backbone.AdminController controller)
        {
            instanceController = controller;
            localSettings = Backbone.AdminController.PublicSettings;
            InitializeComponent();
            BindingContext = this;
        }
        #endregion

        #region Functionality
        /// <summary>
        /// the main event on the click of the return button
        /// </summary>
        /// <param name="sender">btnReturn</param>
        /// <param name="e">the click event</param>
        public void ReturnToCaller(object sender, EventArgs e)
        {
            ReturnToCaller();
        }

        /// <summary>
        /// the main event on the click of the return button
        /// </summary>
        /// <param name="sender">btnUseBatches</param>
        /// <param name="e">the click event</param>
        public void CheckUseBatches(object sender, EventArgs e)
        {
            chbUseBatches.IsChecked = !localSettings.UseBatches;
        }

        /// <summary>
        /// the main event on the click of the return button
        /// </summary>
        /// <param name="sender">btnAdminControl</param>
        /// <param name="e">the click event</param>
        public void CheckAdminControl(object sender, EventArgs e)
        {
            chbAdminControl.IsChecked = !localSettings.AdminControl;
        }

        /// <summary>
        /// the button event for btnSave
        /// </summary>
        /// <param name="sender">btnSave</param>
        /// <param name="e">Click Event</param>
        public void SaveSettings(object sender, EventArgs e)
        {
            Backbone.AdminController.PublicSettings = localSettings;
            Backbone.AdminController.SetUserSettings();
            ReturnToCaller();
        }

        /// <summary>
        /// the button event for the btnReset
        /// </summary>
        /// <param name="sender">btnReset</param>
        /// <param name="e">Click Event</param>
        public void ResetSettings(object sender, EventArgs e)
        {
            localSettings = Backbone.AdminController.DefaultSettings;
            Backbone.AdminController.ResetSettingsToDefaults();
            Refresh();
        }
        #endregion

        #region UI Events
        /// <summary>
        /// this function will force the UI Refresh for the Refresh doesn't occur as needed
        /// </summary>
        public void Refresh()
        {
            this.chbUseBatches.IsChecked = localSettings.UseBatches;
            this.chbAdminControl.IsChecked = localSettings.AdminControl;
            this.txtWebServicePath.Text = localSettings.WebServicePath;
        }
        /// <summary>
        /// this function will return control to the caller page
        /// </summary>
        public void ReturnToCaller()
        {
            instanceController.PageNavigation.PopAsync(Animation.IsEnabled);
        }

        #region Display Functionality
        protected void SelectedOnEntry(object sender, FocusEventArgs e)
        {
            (sender as Entry).CursorPosition = 0;
            (sender as Entry).SelectionLength = (sender as Entry).Text.Length;
        }
        #endregion
        #endregion UI Events
    }
}