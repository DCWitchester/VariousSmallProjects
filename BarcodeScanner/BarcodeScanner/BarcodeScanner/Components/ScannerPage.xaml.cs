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
        public void scanView_OnScanResult(Result result)
        {
            scanView.IsScanning = false;
            Device.BeginInvokeOnMainThread(async () => await GetQuantity(result));
        }
#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// the main event on the Scanner object
        /// </summary>
        /// <param name="result">the scanner result</param>
        /// <returns>the current Task</returns>
        public async Task GetQuantity(Result result)
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
                ProductName = Services.WebServiceMethods.GetProductName(result.Text),
                ProductCode = result.Text,
                ProductQuantity = quantity,
                ProductBatch = lot,
                ProductBatchDate = Regex.Replace(date,"[^0-9.]","")
            });
            scanView.IsScanning = true;
            await instanceController.PageNavigation.PopAsync(true);
        }

        /// <summary>
        /// ***DEPRECATED***
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public async Task GetQuantity(String result)
        {
            String quantity = await DisplayPromptAsync("Cantitate", "Introduceti cantitatea:", keyboard: Keyboard.Numeric);
            instanceController.Products.Add(new ObjectClasses.Products
            {
                ID = instanceController.Products.Count + 1,
                ProductName = Services.WebServiceMethods.GetProductName(result),
                ProductCode = result,
                ProductQuantity = quantity
            });
            await instanceController.PageNavigation.PopAsync(true);
        }

        /// <summary>
        /// this function will return control to the main page
        /// </summary>
        /// <param name="sender">btnReturn</param>
        /// <param name="e">the click event</param>
        private void ReturnToMainPage(object sender, EventArgs e)
        {
            instanceController.PageNavigation.PopAsync(true);
        }

        #endregion
    }
}