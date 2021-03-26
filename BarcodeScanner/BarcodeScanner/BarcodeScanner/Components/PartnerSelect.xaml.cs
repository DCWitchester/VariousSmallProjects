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
        /// <summary>
        /// the observable collection of deserialized partner display xml elements
        /// </summary>
        public ObservableCollection<XmlClasses.PartnerDisplay> partnerDisplays { get; set; } = new ObservableCollection<XmlClasses.PartnerDisplay>();
#pragma warning restore IDE1006 // Naming Styles

        #region Instance Callers
        /// <summary>
        /// the base contructor that takes no parameters
        /// </summary>
        public PartnerSelect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// the base constructor that receives the instance controller from the parent
        /// </summary>
        /// <param name="barcodeScannerController">the instance controller for the curent execution path</param>
        public PartnerSelect(Backbone.BarcodeScannerController barcodeScannerController)
        {
            //we set the instance controller from the barcodeScanner controller received from the parent
            instanceController = barcodeScannerController;
            //we initialize the page display components
            InitializeComponent();
            //we call the webService method to retrieve the complete list of partners
            partnerDisplays = WebServiceMethods.GetPartnersDisplay();
            //and finaly we set the item source for the partners list view
            lvPartners.ItemsSource = partnerDisplays;
        }
        #endregion

        #region Button Events
        /// <summary>
        /// the selection of the partner
        /// </summary>
        /// <param name="sender">lvPartners</param>
        /// <param name="e">ItemSelected event</param>
        public void SelectPartner(Object sender, SelectedItemChangedEventArgs e)
        {
            instanceController.EntryDocument.SetPartnerCodeAndName((e.SelectedItem as XmlClasses.PartnerDisplay).PartnerCode, 
                                                                    (e.SelectedItem as XmlClasses.PartnerDisplay).PartnerName);
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