using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Runtime.Remoting.Contexts;
using System.Text;
using Java.IO;
using Android.Content.Res;
using System.IO;
using Newtonsoft.Json.Linq;

namespace BarcodeScanner.Droid
{
    /// <summary>
    /// the Main Android Activity that controlls the Android Version of the App
    /// </summary>
    [Activity(Label = "BarcodeScanner", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        /// The Override Procedure for the Create Event of the Android
        /// </summary>
        /// <param name="savedInstanceState">the instance state for the program</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //the main layout for the android toolbar
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //the caller for the base functionality of the android apk
            base.OnCreate(savedInstanceState);

            ReadSettingsFile();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            ZXing.Mobile.MobileBarcodeScanner.Initialize(Application);

            Plugin.Iconize.Iconize.Init(Resource.Id.toolbar, Resource.Id.sliding_tabs);

            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// this function will read the settings from the main appsettings json file
        /// </summary>
        void ReadSettingsFile()
        {
            //we initialize a new string
            String content;
            //then use the asset manager to access the apk assets
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("appsettings.json")))
            {
                content = sr.ReadToEnd();
            }
            dynamic obj = JObject.Parse(content);
            Settings.PublicSettings.WebServicePath = obj.PublicSettings.WebServicePath;
            Settings.PublicSettings.AdminPath = obj.PublicSettings.AdminControl;
        }
    }
}