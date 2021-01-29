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
        Backbone.BarcodeScannerController instanceController { get; set; }
        public ObservableCollection<XmlClasses.ManagementUnit> managementUnits { get; set; } = new ObservableCollection<XmlClasses.ManagementUnit>();
#pragma warning restore IDE1006 //Naming Styles

        #region Instance Callers
        public ManagementUnit()
        {
            InitializeComponent();
        }

        public ManagementUnit(Backbone.BarcodeScannerController barcodeScannerController)
        {
            instanceController = barcodeScannerController;
            InitializeComponent();
            managementUnits = WebServiceMethods.GetManagementUnitsDisplay();
            lvManagementUnits.ItemsSource = managementUnits;
        }
        #endregion

        #region Button Events
        public void ManagementUnitSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            instanceController.EntryDocument.SetManagementUnitCodeAndName((e.SelectedItem as XmlClasses.ManagementUnit).ManagementUnitCode,
                                                                            (e.SelectedItem as XmlClasses.ManagementUnit).ManagementUnitName);
            instanceController.PageNavigation.PopModalAsync(Animation.IsEnabled);
        }
        public void LeavePage(Object sender, EventArgs e)
        {
            instanceController.PageNavigation.PopModalAsync(Animation.IsEnabled);
        }
        #endregion
    }
}