using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebServiceEvidenta.SerializationClasses.ItemClasses
{
    /// <summary>
    /// the root element for the PartnerDisplay XML Object
    /// </summary>
    [XmlRoot(ElementName = "Partener")]
    public class PartnerDisplay
    {
        /// <summary>
        /// the PartnerCode for the item
        /// </summary>
        public String PartnerCode { get; set; }
        /// <summary>
        /// the PartnerName for the item
        /// </summary>
        public String PartnerName { get; set; }
        /// <summary>
        /// the Partners FiscalCode
        /// </summary>
        public String PartnerFiscalCode { get; set; }

        /// <summary>
        /// this function will initialize the object with values from the DataTable retrieved from Px
        /// </summary>
        /// <param name="dt">the given data table</param>
        public void GetPartnerDisplayFromDataTable(DataTable dt)
        {
            // Errors might occur for lack of a unique key
            // Also empty keys produce errors
            PartnerCode = dt.Rows[0][0].ToString().Trim();
            PartnerName = dt.Rows[0][1].ToString().Trim();
            PartnerFiscalCode = dt.Rows[0][2].ToString().Trim();
        }
    }
}