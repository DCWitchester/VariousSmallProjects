using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebServiceEvidenta.SerializationClasses
{
    [XmlRoot(ElementName="Parteneri")]
    public class PartnersDisplay
    {
        /// <summary>
        /// the item list of available partners
        /// </summary>
        public List<ItemClasses.PartnerDisplay> partners { get; set; } = new List<ItemClasses.PartnerDisplay>();

        /// <summary>
        /// this function will unload the given data table to the list object
        /// </summary>
        /// <param name="dt">the given data table</param>
        public void GetPartnersFromDataTable(DataTable dt)
        {
            foreach(DataRow element in dt.Rows)
            {
                partners.Add(new ItemClasses.PartnerDisplay
                {
                    PartnerCode = element[0].ToString().Trim(),
                    PartnerName = element[1].ToString().Trim(),
                    PartnerFiscalCode = element[2].ToString().Trim()
                });
            }
        }
    }
}