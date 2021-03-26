using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BarcodeScanner.Services;

namespace BarcodeScanner.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagementUnit : ContentPage
    {
#pragma warning disable IDE1006 //Naming Styles
        /// <summary>
        /// the instance controller received from the parent
        /// </summary>
        Backbone.BarcodeScannerController instanceController { get; set; }
        /// <summary>
        /// an observable collection over the deserialized management unit xml 
        /// </summary>
        public ObservableCollection<XmlClasses.ManagementUnit> managementUnits { get; set; } = new ObservableCollection<XmlClasses.ManagementUnit>();
#pragma warning restore IDE1006 //Naming Styles

        #region Instance Callers
        /// <summary>
        /// the constructor without any parameters 
        /// </summary>
        public ManagementUnit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// the constructor called with the instance controller form the parrent
        /// </summary>
        /// <param name="barcodeScannerController">the instance controller for the curent execution path</param>
        public ManagementUnit(Backbone.BarcodeScannerController barcodeScannerController)
        {
            //we set the instance controller from the barcodeScanner controller
            instanceController = barcodeScannerController;
            //we initialize the page display components
            InitializeComponent();
            //we call the webService method to retrieve the complete list of management units
            managementUnits = WebServiceMethods.GetManagementUnitsDisplay();
            //and finaly we set the item source for the management unit list view
            lvManagementUnits.ItemsSource = managementUnits;
        }
        #endregion

        #region Button Events
        /// <summary>
        /// the selection of the management unit
        /// </summary>
        /// <param name="sender">lvManagementUnits</param>
        /// <param name="e">ItemSelected event</param>
        public void ManagementUnitSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            instanceController.EntryDocument.SetManagementUnitCodeAndName((e.SelectedItem as XmlClasses.ManagementUnit).ManagementUnitCode,
                                                                            (e.SelectedItem as XmlClasses.ManagementUnit).ManagementUnitName);
            instanceController.PageNavigation.PopAsync(Animation.IsEnabled);
        }
        /// <summary>
        /// this function will close the curent page and return focus to the parent
        /// </summary>
        /// <param name="sender">btnSettings</param>
        /// <param name="e">click event</param>
        public void LeavePage(Object sender, EventArgs e)
        {
            instanceController.PageNavigation.PopAsync(Animation.IsEnabled);
        }
        #endregion
    }
}