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
            productsListView.ItemsSource = instanceController.Products;
            //TODO: Delete later
            AddElementsToList();
        }

        /// <summary>
        /// the caller on the btnScanner => will initialize the scanning event
        /// </summary>
        /// <param name="sender">btnScanner</param>
        /// <param name="e">Click Event</param>
        private async void CallScanPage(object sender, EventArgs e)
        {
            //will call the navigation to the scanner page
            await Navigation.PushAsync(new Components.PageScanner(instanceController),true);
        }

        /// <summary>
        /// the caller on the btnSendServer => will send the current products to the server and reset the list
        /// </summary>
        /// <param name="sender">btnSendServer</param>
        /// <param name="e">Click Event</param>
        private void SendProductItems(object sender,EventArgs e)
        {
            //will call the WebServiceMethod to send the products list to the server
            WebServiceMethods.SendProductQunatitites(instanceController.Products.ToList());
            ReinitializeProducts();
        }

        /// <summary>
        /// the caller on the btnResetList => will reinitialize the products list
        /// </summary>
        /// <param name="sender">btnResetList</param>
        /// <param name="e">Click Event</param>
        private void ResetProductList(object sender, EventArgs e)
        {
            ReinitializeProducts();
        }

        /// <summary>
        /// this function will remove the passed element from the list
        /// </summary>
        /// <param name="sender">btnTrash</param>
        /// <param name="e">Click Event</param>
        private void RemoveElement(object sender, EventArgs e)
        {
            var mi = (ObjectClasses.Products)((Button)sender).CommandParameter;
            instanceController.Products.Remove(mi);
        }

        /// <summary>
        /// *TEMPORARY*
        /// </summary>
        private void AddElementsToList()
        {
            instanceController.Products.Add(new ObjectClasses.Products
            {
                ID = 1,
                ProductCode = "104586951035",
                ProductName = "Pantofi de sarac",
                ProductQuantity = "22"
            });
            instanceController.Products.Add(new ObjectClasses.Products
            {
                ID = 2,
                ProductCode = "064553519801",
                ProductName = "Tricou de sarac",
                ProductQuantity = "8"
            });
            instanceController.Products.Add(new ObjectClasses.Products
            {
                ID = 3,
                ProductCode = "005554691138",
                ProductName = "Pantaloni de sarac",
                ProductQuantity = "11"
            });
            instanceController.Products.Add(new ObjectClasses.Products
            {
                ID = 4,
                ProductCode = "155049503816",
                ProductName = "Manusi de sarac",
                ProductQuantity = "3"
            });
            instanceController.Products.Add(new ObjectClasses.Products
            {
                ID = 6,
                ProductCode = "855614950310",
                ProductName = "Fular de sarac",
                ProductQuantity = "16"
            });
            instanceController.Products.Add(new ObjectClasses.Products
            {
                ID = 7,
                ProductCode = "036055195481",
                ProductName = "Fes de sarac",
                ProductQuantity = "17"
            });
            instanceController.Products.Add(new ObjectClasses.Products
            {
                ID = 8,
                ProductCode = "038459011556",
                ProductName = "Geaca de sarac",
                ProductQuantity = "11"
            });
            instanceController.Products.Add(new ObjectClasses.Products
            {
                ID = 9,
                ProductCode = "355658041901",
                ProductName = "Sosese de sarac",
                ProductQuantity = "5"
            });
        }

        /// <summary>
        /// this function will reinitialize the products list and rebind it to the list view
        /// </summary>
        private void ReinitializeProducts()
        {
            //will reinitialize the list into a new list object
            instanceController.Products = new System.Collections.ObjectModel.ObservableCollection<ObjectClasses.Products>();
            //then reset the item source to make sure the list is kept
            //this might not be needed <= doing it out of paranoia
            productsListView.ItemsSource = instanceController.Products;
        }
    }
}
