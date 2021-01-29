using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BarcodeScanner.Services;
using ZXing;

namespace BarcodeScanner
{
    public partial class MainPage : ContentPage
    {

#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the instance controller used as the backbone of the project
        /// </summary>
        Backbone.BarcodeScannerController instanceController { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// the initialization of the Main Page
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            //we instantiate the instance controller
            instanceController = new Backbone.BarcodeScannerController(this.Navigation);
            //then set the item source to the list object
            ForwardPage();
        }

        public async void ForwardPage()
        {
            Backbone.BarcodeScannerController.PublicSettings.AdminControl = false;
            Backbone.BarcodeScannerController.PublicSettings.UseBatches = true;

            if (Backbone.BarcodeScannerController.PublicSettings.AdminControl)
            {
                //TODO => forward to Admin Control
            }
            else if (Backbone.BarcodeScannerController.PublicSettings.UseBatches)
            {
                await Navigation.PushAsync(new Components.StorageServiceWithBatchesPage(instanceController), true);
            }
            else
            {
                await Navigation.PushAsync(new Components.StorageServiceWithoutBatchesPage(instanceController), true);
            }
        }
    }
}
