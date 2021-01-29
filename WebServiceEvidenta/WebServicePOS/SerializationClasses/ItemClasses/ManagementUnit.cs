using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebServiceEvidenta.SerializationClasses.ItemClasses
{
    [XmlRoot(ElementName="Gestiune")]
    public class ManagementUnit
    {
        public String ManagementUnitCode { get; set; } = String.Empty;

        public String ManagementUnitName { get; set; } = String.Empty;

        public void GetManagementUnitFromDataTable(DataTable dt)
        {
            // Errors might occur for lack of a unique key
            // Also empty keys produce errors
            ManagementUnitCode = dt.Rows[0][0].ToString().Trim();
            ManagementUnitName = dt.Rows[0][1].ToString().Trim();
        }
    }
}