using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        Backbone.BarcodeScannerController instanceController { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Constructors
        public PageScanner()
        {
            InitializeComponent();
            scanView.IsScanning = true;
        }

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
            //Device.BeginInvokeOnMainThread(async () => await DisplayAlert("Barcode", "Codul de bare este" + result.Text, "Ok"));
            scanView.IsScanning = false;
            Device.BeginInvokeOnMainThread(async () => await GetQuantity(result));
        }
#pragma warning restore IDE1006 // Naming Styles

        public async Task GetQuantity(Result result)
        {
            String quantity = await DisplayPromptAsync("Cantitate", "Introduceti cantitatea:", keyboard: Keyboard.Numeric);
            String lot = await DisplayPromptAsync("Cantitate", "Introduceti lotul:", keyboard: Keyboard.Default);
            String date = await DisplayPromptAsync("Cantitate", "Introduceti data (zz.ll.aaaa) lotului:", keyboard: Keyboard.Default);

            instanceController.Products.Add(new ObjectClasses.Products
            {
                ID = instanceController.Products.Count + 1,
                ProductName = Services.WebServiceMethods.GetProductName(result.Text),
                ProductCode = result.Text,
                ProductQuantity = quantity,
                ProductBatch = lot,
                ProductBatchDate = date
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

        private void ReturnToMainPage(object sender, EventArgs e)
        {
            //Device.BeginInvokeOnMainThread(async () => await GetQuantity("5941101006070"));
            //Task.Run(async () => await GetQuantity("5941101006070"));
            instanceController.PageNavigation.PopAsync(true);
        }

        #endregion
    }
}