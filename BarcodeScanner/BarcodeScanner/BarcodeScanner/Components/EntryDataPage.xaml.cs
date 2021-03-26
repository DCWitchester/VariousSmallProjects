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

        /// <summary>
        /// this function will call the webservice with the JSON file
        /// </summary>
        /// <param name="sender">btnSendToServer</param>
        /// <param name="e">the click event</param>
        public void SendSalesToServer(object sender, EventArgs e)
        {
            //we will get the json file from the controller
            String json = this.instanceController.GetQuantitiesJsonFile;
            //then call the webService Method with the given json file
            WebServiceMethods.SendProductQunatitites(this.instanceController.GetQuantitiesJsonFile);
            //then reset the instance elements <= practically we reset the program
            instanceController.ResetInstanceElements();
            //and return to the main page
            ReturnToMainPage();
        }

        /// <summary>
        /// this function will check(or uncheck) the notice check box
        /// </summary>
        /// <param name="sender">btnCheckNotice</param>
        /// <param name="e">the click event</param>
        public void CheckIsNotice(object sender, EventArgs e)
        {
            entryDocument.IsNotice = !entryDocument.IsNotice;
            this.chbIsNotice.IsChecked = entryDocument.IsNotice;
        }

        /// <summary>
        /// this function will select a given partner
        /// </summary>
        /// <param name="sender">btnPartnerSearch</param>
        /// <param name="e">the click event</param>
        public void SelectPartner(object sender, EventArgs e)
        {
            instanceController.PageNavigation.PushAsync(new PartnerSelect(instanceController), Animation.IsEnabled);
        }

        /// <summary>
        /// this function will select a given management unit
        /// </summary>
        /// <param name="sender">btnManagementUnitSearch</param>
        /// <param name="e">the click event</param>
        public void SelectManagementUnit(object sender, EventArgs e)
        {
            instanceController.PageNavigation.PushAsync(new ManagementUnit(instanceController), Animation.IsEnabled);
        }
        #endregion

        #region Functionality
        /// <summary>
        /// this function will return focus to the main page
        /// </summary>
        private void ReturnToMainPage()
        {
            this.instanceController.PageNavigation.PopAsync(Animation.IsEnabled);
        }

        /// <summary>
        /// this function will bind the change events that require the page to refresh 
        /// </summary>
        private void InitializeRefreshAction()
        {
            entryDocument.OnChangeManagementUnitName        += RefreshManagementUnit;
            entryDocument.OnChangePartnerName               += RefreshPartner;
            entryDocument.OnChangeManagementUnitNameAndCode += RefreshManagementUnitCodeAndName;
            entryDocument.OnChangePartnerNameAndCode        += RefreshPartnerCodeAndName;
        }
        /// <summary>
        /// this function will refresh the display of the lblManagementUnitName Object
        /// </summary>
        private void RefreshManagementUnit()
        {
            this.lblManagementUnitName.Text = entryDocument.ManagementUnitName;
        }
        /// <summary>
        /// this function will refresh the display of the txtManagementUnitCode and the lblManagementUnitName Object
        /// </summary>
        private void RefreshManagementUnitCodeAndName()
        {
            this.txtManagementUnitCode.Text = entryDocument.ManagementUnitCode;
            this.lblManagementUnitName.Text = entryDocument.ManagementUnitName;
        }
        /// <summary>
        /// this function will refresh the display of the lblPartnerName Object
        /// </summary>
        private void RefreshPartner()
        {
            this.lblPartnerName.Text = entryDocument.PartnerName;
        }
        /// <summary>
        /// this function will refresh the display of the txtPartnerCode and lblPartnerName
        /// </summary>
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