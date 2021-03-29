using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static POSTable.ObjectStructures.Enumerators.Enumerators;

namespace POSTable
{
    //The Miscellaneous functions will contain all global use functions
    public class Miscellaneous
    {
        /// <summary>
        /// this function will set the Background Image for the webSite
        /// </summary>
        /// <returns>the background image</returns>
        public static String SetBackgroundImage()
        {
            return Settings.PublicSettings.DisplayMode switch
            {
                Settings.DisplayMode.Night => "url('images/menu_background_night.jpg')",
                Settings.DisplayMode.Light => "url('images/menu_background_light.jpg')",
                Settings.DisplayMode.Picnic => "url('images/menu_background_picnic.jpg')",
                _ => "url('images/menu_background_night.jpg')",
            };
        }

        /// <summary>
        /// this function will set the foreground color to the webSite
        /// </summary>
        /// <returns>the color string</returns>
        public static String SetForegroundColor()
        {
            return Settings.PublicSettings.DisplayMode switch
            {
                Settings.DisplayMode.Light => "black",
                _ => "white",
            };
        }

        /// <summary>
        /// this function will set the currency to the price item
        /// </summary>
        /// <returns>the current currency for the price</returns>
        public static String SetCurrency()
        {
            return Settings.PublicSettings.Currency switch
            {
                Settings.Currency.Euro => "€",
                Settings.Currency.Dollar => "$",
                _ => "Lei",
            };
        }

        /// <summary>
        /// this function will convert a number of seconds to the equivalent milliseconds
        /// </summary>
        /// <param name="seconds">the given seconds</param>
        /// <returns>the milliseconds contained in the seconds</returns>
        public static Double GetMillisecondOfSeconds(Double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalMilliseconds;
        }

        /// <summary>
        /// this function will return the color code for the table based on its status
        /// </summary>
        /// <param name="status">the table status</param>
        /// <returns>the tables color code</returns>
        public static String GetColorOfStatus(Status status)
        {
            return status switch
            {
                Status.open => "#f2f2f2",
                Status.inUse => "#e23636",
                Status.inUseByClient => "#f4a125",
                Status.activeOrder => "#66b3ff",
                Status.beingCooked => "#fafa38",
                Status.isFinished => "#5cd65c",
                _ => "white"
            };
        }
    }
}
