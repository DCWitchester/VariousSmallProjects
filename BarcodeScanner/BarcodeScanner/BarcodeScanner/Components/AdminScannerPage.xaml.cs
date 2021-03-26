using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BarcodeScanner.Services;

namespace BarcodeScanner.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminScannerPage : ContentPage
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        protected Backbone.AdminController instanceController { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Constructors
        /// <summary>
        /// the base constructor for the scanner page
        /// </summary>
        public AdminScannerPage()
        {
            //the instance controller will be initialized over the navigation
            instanceController = new Backbone.AdminController(this.Navigation);
            //then we will initialize the components
            InitializeComponent();
            //and start the barcode scanner
            scanView.IsScanning = true;
        }
        /// <summary>
        /// the base constructor that receives the admin controller 
        /// </summary>
        /// <param name="adminController">the admin controller passed from the parent</param>
        public AdminScannerPage(Backbone.AdminController adminController)
        {
            //we set the instance controller to the one received from the parent
            instanceController = adminController;
            //add the page navigation to the controller
            instanceController.PageNavigation = this.Navigation;
            //we initialize the page components
            InitializeComponent();
            //and start the barcode scanner
            scanView.IsScanning = true;
        }
        #endregion

        #region Page Events
        /// <summary>
        /// the main function called by the scan view
        /// </summary>
        /// <param name="result">the result returned from the zxing scanner </param>
        public void scanView_OnScanResult(Result result)
        {
            //we stop the scanning temporary because it used to throw errors
            scanView.IsScanning = false;
            //then we invoke the display page on the main thread => this is needed because pages that aren't called on the main thread will not be shown
            Device.BeginInvokeOnMainThread(async() => await GetDisplayPage(result));
        }
        /// <summary>
        /// this function will call and display the setting page 
        /// </summary>
        /// <param name="sender">btnSettingsIcon</param>
        /// <param name="e">the click event</param>
        public void CallSettings(Object sender, EventArgs e)
        {
            instanceController.PageNavigation.PushAsync(new AdminSettingsPage(instanceController), Animation.IsEnabled);
        }
        #endregion

        #region Functionality
        /// <summary>
        /// this function will call the display page with the result of the zxing scanner
        /// </summary>
        /// <param name="result">the given result</param>
        /// <returns>a unused task </returns>
        private async Task GetDisplayPage(Result result)
        {
            instanceController.ProductStockDisplay = WebServiceMethods.GetProductInfo(result.Text);
            instanceController.PageNavigation.PushAsync(new AdminDisplay(instanceController), Animation.IsEnabled);
            scanView.IsScanning = true;
        }
        private async Task GetTestDisplayPage(String result)
        {
            instanceController.ProductStockDisplay = WebServiceMethods.GetProductInfo(result);
            Device.BeginInvokeOnMainThread(async() => await instanceController.PageNavigation.PushAsync(new AdminDisplay(instanceController), Animation.IsEnabled));
            scanView.IsScanning = true;
        }
        #endregion
    }
}