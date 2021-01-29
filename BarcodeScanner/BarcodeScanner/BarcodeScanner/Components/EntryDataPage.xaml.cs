using BarcodeScanner.ObjectClasses;
using BarcodeScanner.Services;
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
    public partial class EntryDataPage : ContentPage
    {
        #region Local Parameters
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the base instanceController object
        /// </summary>
        private Backbone.BarcodeScannerController instanceController { get; set; }
        /// <summary>
        /// the local entry document bound to the UI
        /// </summary>
        public EntryDocument entryDocument 
        { 
            get => this.instanceController.EntryDocument; 
            set => this.instanceController.EntryDocument = value; 
        }
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Constructors
        public EntryDataPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// the initialization of the scanner page with the instance controller passed as a parameter
        /// </summary>
        /// <param name="controller">the scanner page controller</param>
        public EntryDataPage(Backbone.BarcodeScannerController controller)
        {
            instanceController = controller;
            InitializeComponent();
            BindingContext = this;
            InitializeRefreshAction();
        }
        #endregion

        #region Button Events
        /// <summary>
        /// this function will return control to the main page
        /// </summary>
        /// <param name="sender">btnReturn</param>
        /// <param name="e">the click event</param>
        private void ReturnToMainPage(object sender, EventArgs e)
        {
            ReturnToMainPage();
        }

        public void SendSalesToServer(object sender, EventArgs e)
        {
            String json = this.instanceController.GetQuantitiesJsonFile;
            WebServiceMethods.SendProductQunatitites(this.instanceController.GetQuantitiesJsonFile);
            entryDocument = new EntryDocument();
            ReturnToMainPage();
        }

        public void CheckIsNotice(object sender, EventArgs e)
        {
            entryDocument.IsNotice = !entryDocument.IsNotice;
            this.chbIsNotice.IsChecked = entryDocument.IsNotice;
        }

        public void SelectPartner(object sender, EventArgs e)
        {
            instanceController.PageNavigation.PushAsync(new PartnerSelect(instanceController),Animation.IsEnabled);
        }

        public void SelectManagementUnit(object sender, EventArgs e)
        {
            //instanceController.PageNavigation.PushAsync()
        }
        #endregion

        #region Functionality
        private void ReturnToMainPage()
        {
            this.instanceController.PageNavigation.PopAsync(true);
        }
        private void InitializeRefreshAction()
        {
            entryDocument.OnChangeManagementUnitName += RefreshManagementUnit;
            entryDocument.OnChangePartnerName += RefreshPartner;
            entryDocument.OnChangeManagementUnitNameAndCode += RefreshManagementUnitCodeAndName;
            entryDocument.OnChangePartnerNameAndCode += RefreshPartnerCodeAndName;
        }
        private void RefreshManagementUnit()
        {
            this.lblManagementUnitName.Text = entryDocument.ManagementUnitName;
        }
        private void RefreshManagementUnitCodeAndName()
        {
            this.txtManagementUnitCode.Text = entryDocument.ManagementUnitCode;
            this.lblManagementUnitName.Text = entryDocument.ManagementUnitName;
        }
        private void RefreshPartner()
        {
            this.lblPartnerName.Text = entryDocument.PartnerName;
        }
        private void RefreshPartnerCodeAndName()
        {
            this.txtPartnerCode.Text = entryDocument.PartnerCode;
            this.lblPartnerName.Text = entryDocument.PartnerName;
        }
        #endregion

        #region Display Functionality
        protected void SelectedOnEntry(object sender, FocusEventArgs e) 
        {
            (sender as Entry).CursorPosition = 0;
            (sender as Entry).SelectionLength = (sender as Entry).Text.Length;
        }
        #endregion

    }
}