using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarcodeScanner
{
    public partial class App : Application
    {
        public App()
        {
            //the initialization of the base components for the controller
            InitializeComponent();

            //we initialize the Iconize Plugin to be able to access the font awesome methods
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
                                    .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                                    .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule());

            //the initialization of the instance controller -> used to access the instance settings
            Backbone.BarcodeScannerController instanceController = new Backbone.BarcodeScannerController();
            SetPage(instanceController);
            //MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }


        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        /// <summary>
        /// this function will set the initial call page and the instance controller based on the initial settings file
        /// </summary>
        /// <param name="instanceController">the initial instance controller <para/> Used only for accessing the settings file</param>
        protected void SetPage(Backbone.BarcodeScannerController instanceController)
        {
            
            //Backbone.BarcodeScannerController.PublicSettings.AdminControl = true;
            //we check the setting of the admin control which is the base setting for deciding the
            if (Backbone.BarcodeScannerController.PublicSettings.AdminControl)
            {
                //we set the public and default setting for the admin controller from the barcode scanner main controller
                Backbone.AdminController.PublicSettings = Backbone.BarcodeScannerController.PublicSettings;
                Backbone.AdminController.DefaultSettings = Backbone.BarcodeScannerController.DefaultSettings;
                //then we declare the main page as a navigation page extension type over the admin scanner page
                //the Navigation Page extension is needed in order to be able to navigate between pages in Xamarin
                //than beiing said you need to make sure that navigation pages do not show their own header if you want to have your own personalized header element
                MainPage = new NavigationPage(new Components.AdminScannerPage());
            }
            //if the user doesn't go down the admin brach the possibilities will branch one more based upon the use of the batches folder
            else if (Backbone.BarcodeScannerController.PublicSettings.UseBatches)
            {
                //the storage service page with batches and without batches use the same controller
                //I would have liked to make them a single page but i didn't have the time
                MainPage = new NavigationPage(new Components.StorageServiceWithBatchesPage(instanceController));
            }
            else
            {
                MainPage = new NavigationPage(new Components.StorageServiceWithoutBatchesPage(instanceController));
            }
        }
    }
}
