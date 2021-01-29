using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebServiceEvidenta.Miscellaneous;

namespace WebServiceEvidenta.VFPClasses.SpecificClasses
{
    public class QuantityFileFunctions: VFPConnection
    {
        #region Public Functionality

        #region Set Functions
        /// <summary>
        /// this function will dump a json file to the
        /// </summary>
        /// <param name="quantityDocument">the json document</param>
        public void SetQuantityFile(String quantityDocument)
        {
            //we Deserialize the Object into the sale
            SerializationClasses.Quantities quantities = JsonConvert.DeserializeObject<SerializationClasses.Quantities>(quantityDocument);
            CheckQuantityFile();
            //we initialize a new command
            System.Data.OleDb.OleDbCommand oCmd = base.FileBaseConnection.CreateCommand();
            //we try to open the connection on the base class
            if (!base.OpenConnection()) return;
            //then we iterate the list elements
            foreach (SerializationClasses.ProductQuantity element in quantities.ProductQuantities)
            {
                String command = $"INSERT INTO '{base.QuantityFile}' " +
                                    $"VALUES ('{quantities.UserBundle}','{quantities.ManagementUnit}','{quantities.PartnerCode}'" +
                                    $",{quantities.DocumentNumber},{(quantities.IsAviz ? ".T." : ".F.")}, " +
                                    $"{Miscellaneous.Miscellaneous.ConvertDateStringToFoxDate(quantities.DocumentDate)}," +
                                    $"'{element.ProductCode.Substring(0, 12)}',{element.ProductQunatity}, '{element.ProductBatch}', " +
                                    $"{Miscellaneous.Miscellaneous.ConvertDateStringToFoxDate(element.ProductBatchDate)}) " + Environment.NewLine;
                oCmd.CommandText = command;
                oCmd.ExecuteNonQuery();
            }
        }
        #endregion

        #endregion

        #region LocalFunctionality
        /// <summary>
        /// this function will check the existance of the Quantity file and create it if needed
        /// </summary>
        void CheckQuantityFile()
        {
            if (!File.Exists(base.QuantityFile))
            {
                //the base string command for the creation of the file
                String commad = $"CREATE TABLE '{base.QuantityFile}' {base.QuantityFileStructure}";
                //we initialize a new command
                System.Data.OleDb.OleDbCommand oCmd = base.FileBaseConnection.CreateCommand();
                //set the command text to the db command
                oCmd.CommandText = commad;
                //we try to open the connection on the base class
                if (!base.OpenConnection()) return;
                try
                {
                    //and load it from the reader
                    oCmd.ExecuteNonQuery();
                }
                catch { return; }
                finally
                {
                    //always remember the fifth of november
                    //oh, and to close your connection
                    base.CloseConnection();
                }
            }
        }
        #endregion
    }
}
