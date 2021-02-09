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
        public AdminScannerPage()
        {
            instanceController = new Backbone.AdminController(this.Navigation);
            InitializeComponent();
            scanView.IsScanning = true;
        }
        public AdminScannerPage(Backbone.AdminController adminController)
        {
            instanceController = adminController;
            instanceController.PageNavigation = this.Navigation;
            InitializeComponent();
            scanView.IsScanning = true;
        }
        #endregion

        #region Page Events
        public void scanView_OnScanResult(Result result)
        {
            scanView.IsScanning = false;
            Device.BeginInvokeOnMainThread(async() => await GetDisplayPage(result));
            
        }
        public void CallSettings(Object sender, EventArgs e)
        {
            instanceController.PageNavigation.PushAsync(new AdminSettingsPage(instanceController), Animation.IsEnabled);
        }
        #endregion

        #region Functionality
        private async Task GetDisplayPage(Result result)
        {
            instanceController.ProductStockDisplay = WebServiceMethods.GetProductInfo(result.Text);
            instanceController.PageNavigation.PushAsync(new AdminDisplay(instanceController), Animation.IsEnabled);
            //TO DO: Logic for getting the page on display
            scanView.IsScanning = true;
        }
        private async Task GetTestDisplayPage(String result)
        {
            instanceController.ProductStockDisplay = WebServiceMethods.GetProductInfo(result);
            Device.BeginInvokeOnMainThread(async() => await instanceController.PageNavigation.PushAsync(new AdminDisplay(instanceController), Animation.IsEnabled));
            //TO DO: Logic for getting the page on display
            scanView.IsScanning = true;
        }
        #endregion
    }
}