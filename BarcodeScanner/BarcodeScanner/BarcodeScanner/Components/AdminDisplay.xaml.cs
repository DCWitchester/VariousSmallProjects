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

        public ProductStockDisplay ProductStockDisplay
        {
            get => instanceController.ProductStockDisplay;
            set => instanceController.ProductStockDisplay = value;
        }
        #endregion

        #region Constructors
        public AdminDisplay()
        {
            InitializeComponent();
            lvStocks.ItemsSource = ProductStockDisplay.StockDisplay;
            BindingContext = this;

        }

        public AdminDisplay(Backbone.AdminController adminController)
        {
            this.instanceController = adminController;
            InitializeComponent();
            lvStocks.ItemsSource = ProductStockDisplay.StockDisplay;
            BindingContext = this;
        }
        #endregion

        #region Page Events
        public void ReturnToMainPage(Object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => await instanceController.PageNavigation.PopAsync(Animation.IsEnabled));
        }
        #endregion

        #region Functionality
        #endregion
    }
}