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

            MainPage = new NavigationPage(new MainPage());
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
    }
}
