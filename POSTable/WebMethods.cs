using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTable
{
    /// <summary>
    /// the Main Class for containing WebMethods
    /// </summary>
    public class WebMethods
    {
        /// <summary>
        /// this String will retrieve the getMenu WebService adress
        /// </summary>
        public static String GetMenu => Settings.PublicSettings.WebServicePath + "/GetMeniu";
        /// <summary>
        /// this String will retrieve the setSale WebService adress and prepare it for receiving the parameter
        /// </summary>
        public static String SetSales => Settings.PublicSettings.WebServicePath + "/SetSale?sale=";
        /// <summary>
        /// this String will retrieve the getIsTableOpen WebService adress and prepare it for receiving the parameter
        /// </summary>
        public static String GetIsTableOpen => Settings.PublicSettings.WebServicePath + "/GetIsTableOpen?table=";
        /// <summary>
        /// this String will retrieve the getAdministrations WebService adress
        /// </summary>
        public static String GetAdministrations => Settings.PublicSettings.WebServicePath + "/GetAdministration";
        /// <summary>
        /// this String will retrieve the getCategories WebService adress
        /// </summary>
        public static String GetCategories => Settings.PublicSettings.WebServicePath + "/GetCategories";
        /// <summary>
        /// this String will retrieve the getTables WebService adress
        /// </summary>
        public static String GetTables => Settings.PublicSettings.WebServicePath + "/GetTables";
        /// <summary>
        /// this String will retrieve the getWaiter WebService adress and prepare it for receiving the parameter
        /// </summary>
        public static String GetWaiter => Settings.PublicSettings.WebServicePath + "/GetWaiter?waiterCode=";
        /// <summary>
        /// the String will retrieve the checkWaiter WebService adress and prepare it for receiving the parameter
        /// </summary>
        public static String CheckWaiter => Settings.PublicSettings.WebServicePath + "/CheckWaiter?waiterCode=";
    }
}
