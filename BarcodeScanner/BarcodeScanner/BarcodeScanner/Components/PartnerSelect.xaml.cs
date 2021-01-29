using BarcodeScanner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarcodeScanner.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PartnerSelect : ContentPage
    {
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the instance controller used as the backbone of the project
        /// </summary>
        Backbone.BarcodeScannerController instanceController { get; set; }
        public ObservableCollection<XmlClasses.PartnerDisplay> partnerDisplays { get; set; } = new ObservableCollection<XmlClasses.PartnerDisplay>();
#pragma warning restore IDE1006 // Naming Styles

        #region Instance Callers
        public PartnerSelect()
        {
            InitializeComponent();
        }

        public PartnerSelect(Backbone.BarcodeScannerController barcodeScannerController)
        {
            instanceController = barcodeScannerController;
            InitializeComponent();
            partnerDisplays = WebServiceMethods.GetPartnersDisplay();
            lvPartners.ItemsSource = partnerDisplays;
        }
        #endregion

        #region Button Events
        public void SelectPartner(Object sender, SelectedItemChangedEventArgs e)
        {
            instanceController.EntryDocument.SetPartnerCodeAndName((e.SelectedItem as XmlClasses.PartnerDisplay).PartnerCode, 
                                                                    (e.SelectedItem as XmlClasses.PartnerDisplay).PartnerName);
            instanceController.PageNavigation.PopModalAsync(Animation.IsEnabled);
            
        }

        public void LeavePage(Object sender, EventArgs e)
        {
            instanceController.PageNavigation.PopModalAsync(Animation.IsEnabled);
        }
        #endregion
    }
}