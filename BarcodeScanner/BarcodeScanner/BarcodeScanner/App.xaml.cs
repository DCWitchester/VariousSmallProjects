using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarcodeScanner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
                                    .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                                    .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule());

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

        protected void SetPage(Backbone.BarcodeScannerController instanceController)
        {
            Backbone.BarcodeScannerController.PublicSettings.AdminControl = true;
            if (Backbone.BarcodeScannerController.PublicSettings.AdminControl)
            {

                Backbone.AdminController.PublicSettings = Backbone.BarcodeScannerController.PublicSettings;
                Backbone.AdminController.DefaultSettings = Backbone.BarcodeScannerController.DefaultSettings;
                //TODO => forward to Admin Control
                MainPage = new NavigationPage(new Components.AdminScannerPage());
            }
            else if (Backbone.BarcodeScannerController.PublicSettings.UseBatches)
            {
                MainPage = new NavigationPage(new Components.StorageServiceWithBatchesPage(instanceController));
            }
            else
            {
                MainPage = new NavigationPage(new Components.StorageServiceWithoutBatchesPage(instanceController));
            }
        }
    }
}
