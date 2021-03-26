using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace BarcodeScanner.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageScanner : ContentPage
    {
        #region LocalParameters
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the base instanceController object
        /// </summary>
        Backbone.BarcodeScannerController instanceController { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Constructors
        /// <summary>
        /// the initialization of the scanner page
        /// </summary>
        public PageScanner()
        {
            InitializeComponent();
            scanView.IsScanning = true;
        }

        /// <summary>
        /// the initialization of the scanner page with the instance controller passed as a parameter
        /// </summary>
        /// <param name="controller">the scanner page controller</param>
        public PageScanner(Backbone.BarcodeScannerController controller)
        {
            instanceController = controller;
            InitializeComponent();
            scanView.IsScanning = true;
        }
        #endregion

        #region Button Events

#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// this function is called by th zxing scanner upon obtaining a valid result
        /// </summary>
        /// <param name="result">the calid result</param>
        public void scanView_OnScanResult(Result result)
        {
            //we stop scanning temporarily
            scanView.IsScanning = false;
            //the call the get quantity function in the main thread.
            //all ui elements need to be displayed in the main thread in order to be visible
            Device.BeginInvokeOnMainThread(async () => await GetQuantity(result));
        }
#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// the main event on the Scanner object
        /// </summary>
        /// <param name="result">the scanner result</param>
        /// <returns>the current Task</returns>
        private async Task GetQuantity(Result result)
        {
            //we call the display prompt async in order to request the quantity from the user
            String quantity = await DisplayPromptAsync("Cantitate", "Introduceti cantitatea:", keyboard: Keyboard.Numeric);
            //we then initialize the lot and date string to empty values
            String lot = String.Empty;
            String date = String.Empty;
            //then we check the settings to see if they use batches or not
            if (Backbone.BarcodeScannerController.PublicSettings.UseBatches)
            {
                //we request the batch and its date directly from the user
                lot = await DisplayPromptAsync("Cantitate", "Introduceti lotul:", keyboard: Keyboard.Default);
                date = await DisplayPromptAsync("Cantitate", "Introduceti data (zz.ll.aaaa) lotului:", keyboard: Keyboard.Default);
            }
            //then we add a newly instantiated product object to the list
            instanceController.Products.Add(new ObjectClasses.Products
            {
                ID = instanceController.Products.Count + 1,
                ProductName = Services.WebServiceMethods.GetProductName(result.Text),
                ProductCode = result.Text,
                ProductQuantity = quantity,
                ProductBatch = lot,
                ProductBatchDate = Regex.Replace(date,"[^0-9.]","")
            });
            //and reactivate the scan
            scanView.IsScanning = true;
            //before leaving the page
            await instanceController.PageNavigation.PopAsync(Animation.IsEnabled);
        }

        /// <summary>
        /// ***DEPRECATED***
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public async Task GetQuantity(String result)
        {
            String quantity = await DisplayPromptAsync("Cantitate", "Introduceti cantitatea:", keyboard: Keyboard.Numeric);
            String lot = String.Empty;
            String date = String.Empty;
            if (Backbone.BarcodeScannerController.PublicSettings.UseBatches)
            {
                lot = await DisplayPromptAsync("Cantitate", "Introduceti lotul:", keyboard: Keyboard.Default);
                date = await DisplayPromptAsync("Cantitate", "Introduceti data (zz.ll.aaaa) lotului:", keyboard: Keyboard.Default);
            }

            instanceController.Products.Add(new ObjectClasses.Products
            {
                ID = instanceController.Products.Count + 1,
                ProductName = Services.WebServiceMethods.GetProductName(result),
                ProductCode = result,
                ProductQuantity = quantity,
                ProductBatch = lot,
                ProductBatchDate = Regex.Replace(date, "[^0-9.]", "")
            });
            scanView.IsScanning = true;
            await instanceController.PageNavigation.PopAsync(Animation.IsEnabled);
        }

        /// <summary>
        /// this function will return control to the main page
        /// </summary>
        /// <param name="sender">btnReturn</param>
        /// <param name="e">the click event</param>
        private void ReturnToMainPage(object sender, EventArgs e)
        {
            instanceController.PageNavigation.PopAsync(Animation.IsEnabled);
        }

        /// <summary>
        /// **DEPRECATED**
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestScanner(object sender, EventArgs e)
        {
            scanView.IsScanning = false;
            Device.BeginInvokeOnMainThread(async () => await GetQuantity("5449000016669"));
        }
        #endregion
    }
}