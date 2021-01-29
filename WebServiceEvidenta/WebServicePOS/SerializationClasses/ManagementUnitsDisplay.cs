using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebServiceEvidenta.SerializationClasses
{
    [XmlRoot(ElementName = "Gestiuni")]
    public class ManagementUnitsDisplay
    {
        public List<ItemClasses.ManagementUnit> managementUnits { get; set; } = new List<ItemClasses.ManagementUnit>();

        public void GetManagementUnitsFromDataTable(DataTable dt)
        {
            foreach(DataRow element in dt.Rows)
            {
                managementUnits.Add(new ItemClasses.ManagementUnit
                {
                    ManagementUnitCode = element[0].ToString().Trim(),
                    ManagementUnitName = element[1].ToString().Trim()
                });
            }
        }
    }
}