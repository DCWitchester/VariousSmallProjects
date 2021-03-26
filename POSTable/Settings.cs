using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTable
{
    /// <summary>
    /// the settings class will contain this Settings
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// the Display Mode Enum
        /// </summary>
        public enum DisplayMode
        {
            //Night Mode
            Night = 1,
            //Light Mode
            Light = 2,
            //Night Mode + Picnic Background
            Picnic = 3
        }
        /// <summary>
        /// the Currency settings
        /// </summary>
        public enum Currency
        {
            RON = 1,
            Euro = 2,
            Dollar = 3
        }

        /// <summary>
        /// this class will contain global static settings
        /// </summary>
        public class PublicSettings
        {
            /// <summary>
            /// the webService Path
            /// </summary>
            public static String WebServicePath { get; set; }
            /// <summary>
            /// the programs default display Mode
            /// </summary>
            public static DisplayMode DisplayMode { get; set; }
            /// <summary>
            /// the currency displayed with the price
            /// </summary>
            public static Currency Currency { get; set; }
            /// <summary>
            /// the refresh timer for the table menu
            /// </summary>
            public static Double TableRefreshTimer { get; set; }

            /// <summary>
            /// this function will read the settings form the program iconfig
            /// </summary>
            /// <param name="configuration">the given config settings7</param>
            public static void ReadSetting(IConfiguration configuration)
            {
                //the we retrieve the settings from the configuration
                Settings.PublicSettings.WebServicePath = configuration["PublicSettings:WebServicePath"];
                Settings.PublicSettings.DisplayMode = (Settings.DisplayMode)Convert.ToInt32(configuration["PublicSettings:Mode"]);
                Settings.PublicSettings.Currency = (Settings.Currency)Convert.ToInt32(configuration["PublicSettings:Moneda"]);
                Settings.PublicSettings.TableRefreshTimer = Convert.ToDouble(configuration["PublicSettings:RefreshMese"]);
            }
        }
    }
}
