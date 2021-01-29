using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace WebServiceEvidenta.VFPClasses.GeneralClasses
{
    public class PartnerFunctions : VFPConnection
    {
        /// <summary>
        /// this function will retrieve a partner display element for the given partner code
        /// </summary>
        /// <param name="partnerCode">the given product code</param>
        /// <returns>the xmlDocument containing the product name and price</returns>
        public XmlDocument getPartner(String partnerCode)
        {
            //we set the command string
            String command = String.Format("SELECT TOP 1 fuben,denfb,codf " +
                                                $"FROM '{base.PartnerGlossary}' " +
                                                $"WHERE UPPER(ALLTRIM(fuben)) == '{partnerCode}' " +
                                                "ORDER BY fuben");
            //we initialize a new command
            System.Data.OleDb.OleDbCommand oCmd = base.FileBaseConnection.CreateCommand();
            //then set the command text for the ole object
            oCmd.CommandText = command;
            //then initialize a new dataTable
            DataTable dt = new DataTable();
            //we try to open the connection on the base class
            if (!base.OpenConnection()) return null;
            try
            {
                //and load it from the reader
                dt.Load(oCmd.ExecuteReader());
            }
            catch { return null; }
            finally
            {
                //always remember the fifth of november
                //oh, and to close your connection
                base.CloseConnection();
            }
            //and set a name for the table just because I can
            dt.TableName = "Partener";
            //we initialize a new PartnerDisplay
            SerializationClasses.ItemClasses.PartnerDisplay partnerDisplay = new SerializationClasses.ItemClasses.PartnerDisplay();
            //then we retrieve the data from the table and fill the object
            partnerDisplay.GetPartnerDisplayFromDataTable(dt);
            //we initialize a serializer over the PartnerDisplay and fill the object
            XmlSerializer serializer = new XmlSerializer(typeof(SerializationClasses.ItemClasses.PartnerDisplay));
            //and a new result String
            String result = String.Empty;
            //then using a memoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //we serialize the object onto the memoryStream
                serializer.Serialize(memoryStream, partnerDisplay);
                //then place myself at the start of the stream
                memoryStream.Position = 0;
                //and dump the string into the result string
                result = new StreamReader(memoryStream).ReadToEnd();
            }
            //we create a new XmlDocument
            XmlDocument xmlDocument = new XmlDocument();
            //and load it from the resulted string
            xmlDocument.LoadXml(result);
            //before finally returning the result.
            return xmlDocument;

        }

        /// <summary>
        /// this function will retrieve a partner display element for the given partner code
        /// </summary>
        /// <param name="partnerCode">the given product code</param>
        /// <returns>the xmlDocument containing the product name and price</returns>
        public XmlDocument getPartners()
        {
            //we set the command string
            String command = String.Format("SELECT fuben,denfb,codf " +
                                                $"FROM '{base.PartnerGlossary}' " +
                                                "WHERE !EMPTY(fuben) " +
                                                "ORDER BY fuben");

            //we initialize a new command
            System.Data.OleDb.OleDbCommand oCmd = base.FileBaseConnection.CreateCommand();
            //then set the command text for the ole object
            oCmd.CommandText = command;
            //then initialize a new dataTable
            DataTable dt = new DataTable();
            //we try to open the connection on the base class
            if (!base.OpenConnection()) return null;
            try
            {
                //and load it from the reader
                dt.Load(oCmd.ExecuteReader());
            }
            catch { return null; }
            finally
            {
                //always remember the fifth of november
                //oh, and to close your connection
                base.CloseConnection();
            }
            //and set a name for the table just because I can
            dt.TableName = "Parteneri";
            //we initialize a new PartnerDisplay
            SerializationClasses.PartnersDisplay partnersDisplay = new SerializationClasses.PartnersDisplay();
            //then we retrieve the data from the table and fill the object
            partnersDisplay.GetPartnersFromDataTable(dt);
            //we initialize a serializer over the PartnerDisplay and fill the object
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializationClasses.ItemClasses.PartnerDisplay>));
            //and a new result String
            String result = String.Empty;
            //then using a memoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //we serialize the object onto the memoryStream
                serializer.Serialize(memoryStream, partnersDisplay.partners);
                //then place myself at the start of the stream
                memoryStream.Position = 0;
                //and dump the string into the result string
                result = new StreamReader(memoryStream).ReadToEnd();
            }
            //we create a new XmlDocument
            XmlDocument xmlDocument = new XmlDocument();
            //and load it from the resulted string
            xmlDocument.LoadXml(result);
            //before finally returning the result.
            return xmlDocument;

        }
    }
}