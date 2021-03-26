using BarcodeScanner.ObjectClasses;
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
    public partial class AdminDisplay : ContentPage
    {
        #region Properties
        /// <summary>
        /// the base instanceController object
        /// </summary>
        private Backbone.AdminController instanceController { get; set; }

        /// <summary>
        /// the caller for the base productStockDisplay
        /// </summary>
        public ProductStockDisplay ProductStockDisplay
        {
            get => instanceController.ProductStockDisplay;
            set => instanceController.ProductStockDisplay = value;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// the base constructor for the page 
        /// </summary>
        public AdminDisplay()
        {
            InitializeComponent();
            //we bind the list view to the stock display list
            lvStocks.ItemsSource = ProductStockDisplay.StockDisplay;
            //and set the form binding context
            BindingContext = this;

        }

        /// <summary>
        /// the base constructor for the page with the adminController
        /// </summary>
        /// <param name="adminController">the admin controller received from the caller</param>
        public AdminDisplay(Backbone.AdminController adminController)
        {
            //the instance controller will be linked to the admin controller received from the parent
            this.instanceController = adminController;
            //we initialize the component
            InitializeComponent();
            //we set the item source for the stock display 
            lvStocks.ItemsSource = ProductStockDisplay.StockDisplay;
            //and bind the page context to this
            BindingContext = this;
        }
        #endregion

        #region Page Events
        /// <summary>
        /// this function will return to the main page
        /// </summary>
        /// <param name="sender">lblReturnButton</param>
        /// <param name="e">the click event</param>
        public void ReturnToMainPage(Object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => await instanceController.PageNavigation.PopAsync(Animation.IsEnabled));
        }
        #endregion

        #region Functionality
        #endregion
    }
}