using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace WebServiceEvidenta.VFPClasses.GeneralClasses
{
    public class ProductFunctions : VFPConnection
    {
        #region GetFunctions
        /// <summary>
        /// this is the main function for retriving the name and the price of a given ProductCode
        /// </summary>
        /// <param name="productCode">the given product code</param>
        /// <returns>the xmlDocument containing the product name and price</returns>
        public XmlDocument getProductName(String productCode)
        {
            //we set the command string
            String command = String.Format("SELECT TOP 1 denm,pv " +
                                                "FROM '{0}' " +
                                                "WHERE UPPER(ALLTRIM(codp)) == '{1}' OR LEFT(UPPER(ALLTRIM(codext)),12) == '{1}' " +
                                                "ORDER BY codp",
                                                base.ProductGlossary,
                                                productCode.ToUpper().Trim());
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
            dt.TableName = "Produs";
            //we initialize a new productDisplay  
            SerializationClasses.ProductDisplay productDisplay = new SerializationClasses.ProductDisplay();
            //then we will retrieve the data from the table and fill the object
            productDisplay.GetProductDisplayFromDataTable(dt);
            //we initialize a serializer over tge ProductDisplay classes
            XmlSerializer serializer = new XmlSerializer(typeof(SerializationClasses.ProductDisplay));
            //we initialize a resultString
            String result = String.Empty;
            //then using a memoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //we serialize the object onto the memoryStream
                serializer.Serialize(memoryStream, productDisplay);
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
        /// this is the main function for retriving the name and the price of a given ProductCode
        /// </summary>
        /// <param name="productCode">the given product code</param>
        /// <returns>the xmlDocument containing the product name and price</returns>
        public XmlDocument getProductDetails(String productCode)
        {
            //we set the command string
            String command = String.Format("SELECT TOP 1 denm,pv FROM '{0}' WHERE UPPER(ALLTRIM(codp)) == '{1}' ORDER BY codp",
                                                base.ProductGlossary,
                                                productCode.ToUpper().Trim());
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
            dt.TableName = "Produs";
            //we initialize a new productDisplay  
            SerializationClasses.ProductDisplay productDisplay = new SerializationClasses.ProductDisplay();
            //then we will retrieve the data from the table and fill the object
            productDisplay.GetProductDisplayFromDataTable(dt);
            //we initialize a serializer over tge ProductDisplay classes
            XmlSerializer serializer = new XmlSerializer(typeof(SerializationClasses.ProductDisplay));
            //we initialize a resultString
            String result = String.Empty;
            //then using a memoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //we serialize the object onto the memoryStream
                serializer.Serialize(memoryStream, productDisplay);
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
        /// this function will get the stocks for the specific product
        /// </summary>
        /// <param name="productCode">the given product code</param>
        /// <returns>the formatted xml document containing</returns>
        public XmlDocument getProductStock(String productCode)
        {
            String command = $"SELECT codp,denp,gest,pv,cant " +
                                $"FROM '{base.StockFile}' " +
                                $"WHERE UPPER(ALLTRIM(codp))=='{productCode.Trim()}' ORDER BY gest";
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
            dt.TableName = "Stocuri";
            //we check the rows 
            if (dt == null || dt.Rows.Count < 1) return null;
            //we initialize a new productDisplay  
            SerializationClasses.ProductStocks productStocks = new SerializationClasses.ProductStocks();
            //then we will retrieve the data from the table and fill the object
            productStocks.GetProductStocksFromDataTable(dt);
            //we initialize a serializer over tge ProductDisplay classes
            XmlSerializer serializer = new XmlSerializer(typeof(SerializationClasses.ProductStocks));
            //we initialize a resultString
            String result = String.Empty;
            //then using a memoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //we serialize the object onto the memoryStream
                serializer.Serialize(memoryStream, productStocks);
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
        /// this function will get the stocks for the specific product
        /// </summary>
        /// <param name="productCode">the given product code</param>
        /// <returns>the formatted xml document containing</returns>
        public XmlDocument getProductStockViaExternalCode(String productCode)
        {
            String command = $"SELECT sf.codp,sf.denp,sf.gest,sf.pv,sf.cant " +
                                $"FROM '{base.StockFile}' AS sf " +
                                $"LEFT JOIN '{base.ProductGlossary}' AS pg " +
                                $"ON sf.codp == pg.codp "+
                                $"WHERE ( UPPER(ALLTRIM(pg.codp)) == '{productCode.Trim()}' " +
                                    $"OR LEFT(UPPER(ALLTRIM(pg.codext)),12) == '{productCode.Trim()}' ) " +
                                $"ORDER BY gest";
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
            dt.TableName = "Stocuri";
            //we check the rows 
            if (dt == null || dt.Rows.Count < 1) return null;
            //we initialize a new productDisplay  
            SerializationClasses.ProductStocks productStocks = new SerializationClasses.ProductStocks();
            //then we will retrieve the data from the table and fill the object
            productStocks.GetProductStocksFromDataTable(dt);
            //we initialize a serializer over tge ProductDisplay classes
            XmlSerializer serializer = new XmlSerializer(typeof(SerializationClasses.ProductStocks));
            //we initialize a resultString
            String result = String.Empty;
            //then using a memoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //we serialize the object onto the memoryStream
                serializer.Serialize(memoryStream, productStocks);
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

        public XmlDocument getProductInfo(String productCode)
        {
            String command = "SELECT sf.codp, pg.denm, sf.gest, mug.deng, pg.fuben, prg.denfb, sf.pv, sf.cant " +
                                $"FROM '{base.StockFile}' as sf " +
                                $"LEFT JOIN '{base.ProductGlossary}' as pg " +
                                    $"ON sf.codp == pg.codp " +
                                $"LEFT JOIN '{base.ManagementUnitGlossary}' as mug " +
                                    $"ON sf.gest == mug.gest " +
                                $"LEFT JOIN '{base.PartnerGlossary}' as prg " +
                                    $"ON pg.fuben == prg.fuben " +
                                $"WHERE ( UPPER(ALLTRIM(pg.codp)) == '{productCode.Trim()}' " +
                                    $"OR LEFT(UPPER(ALLTRIM(pg.codext)),12) == '{productCode.Trim()}' ) " +
                                $"ORDER BY sf.gest" ;
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
            dt.TableName = "Stocuri";
            //we check the rows 
            if (dt == null || dt.Rows.Count < 1) return null;
            //we initialize a new productDisplay  
            SerializationClasses.ProductStockDisplay productStocks = new SerializationClasses.ProductStockDisplay();
            //then we will retrieve the data from the table and fill the object
            productStocks.GetDisplayItemsFromDataTable(dt);
            //we initialize a serializer over tge ProductDisplay classes
            XmlSerializer serializer = new XmlSerializer(typeof(SerializationClasses.ProductStockDisplay));
            //we initialize a resultString
            String result = String.Empty;
            //then using a memoryStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //we serialize the object onto the memoryStream
                serializer.Serialize(memoryStream, productStocks);
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
        #endregion
    }
}