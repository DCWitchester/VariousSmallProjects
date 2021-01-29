using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Data;
using System.Xml.Serialization;
using WebServiceEvidenta.SerializationClasses.ItemClasses;

namespace WebServiceEvidenta.VFPClasses.GeneralClasses
{
    public class ManagementUnitFunctions : VFPConnection
    {
        public XmlDocument GetManagementUnits()
        {
            //we set the command string
            String command = String.Format("SELECT gest,deng " +
                                                $"FROM '{base.ManagementUnitGlossary}' " +
                                                "WHERE !EMPTY(gest) " +
                                                "ORDER BY gest");
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
            dt.TableName = "Gestiuni";
            //we initialize a new PartnerDisplay
            SerializationClasses.ManagementUnitsDisplay managementUnitsDisplay = new SerializationClasses.ManagementUnitsDisplay();
            //then we retrieve the data from the table and fill the object
            managementUnitsDisplay.GetManagementUnitsFromDataTable(dt);
            //we initialize a serializer over the PartnerDisplay and fill the object
            XmlSerializer serializer = new XmlSerializer(typeof(List<ManagementUnit>));
            //and a new result String
            String result = String.Empty;
            //then using a memoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //we serialize the object onto the memoryStream
                serializer.Serialize(memoryStream, managementUnitsDisplay.managementUnits);
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

        public XmlDocument GetManagementUnit(String ManagementUnitCode)
        {
            //we set the command string
            String command = String.Format("SELECT TOP 1 gest,deng " +
                                                $"FROM '{base.ManagementUnitGlossary}' " +
                                                $"WHERE gest = '{ManagementUnitCode.Trim()}' AND !EMPTY(gest) " +
                                                "ORDER BY gest");
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
            dt.TableName = "Gestiune";
            //we initialize a new PartnerDisplay
            ManagementUnit managementUnitDisplay = new ManagementUnit();
            //then we retrieve the data from the table and fill the object
            managementUnitDisplay.GetManagementUnitFromDataTable(dt);
            //we initialize a serializer over the PartnerDisplay and fill the object
            XmlSerializer serializer = new XmlSerializer(typeof(ManagementUnit));
            //and a new result String
            String result = String.Empty;
            //then using a memoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //we serialize the object onto the memoryStream
                serializer.Serialize(memoryStream, managementUnitDisplay);
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