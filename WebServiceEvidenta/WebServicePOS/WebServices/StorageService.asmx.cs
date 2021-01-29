using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using WebServiceEvidenta.VFPClasses.GeneralClasses;
using WebServiceEvidenta.VFPClasses.SpecificClasses;

namespace WebServiceEvidenta.WebServices
{
    /// <summary>
    /// Summary description for StorageService
    /// </summary>
    [WebService(Namespace = "http://www.mentorsoft.ro/WebAdministration/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StorageService : System.Web.Services.WebService
    {

        [WebMethod]
        public XmlDocument GetProductName(String ProductCode)
        {
            using (ProductFunctions vfp = new ProductFunctions())
            {
                return vfp.getProductName(ProductCode);
            }
        }

        [WebMethod]
        public void SetQuantityFile(String QuantityFile)
        {
            using (QuantityFileFunctions vfp = new QuantityFileFunctions())
            {
                vfp.SetQuantityFile(QuantityFile);
            }
        }

        [WebMethod]
        public XmlDocument GetProductStock(String ProductCode)
        {
            using (ProductFunctions vfp = new ProductFunctions())
            {
                return vfp.getProductStock(ProductCode);
            }
        }

        [WebMethod]
        public XmlDocument GetProductStockViaExternalCode(String ProductCode)
        {
            using (ProductFunctions vfp = new ProductFunctions())
            {
                return vfp.getProductStockViaExternalCode(ProductCode);
            }
        }

        [WebMethod]
        public XmlDocument GetPartnerDisplay(String PartnerCode)
        {
            using (PartnerFunctions vfp = new PartnerFunctions())
            {
                return vfp.getPartner(PartnerCode);
            }
        }

        [WebMethod]
        public XmlDocument GetPartnersDisplay()
        {
            using (PartnerFunctions vfp = new PartnerFunctions())
            {
                return vfp.getPartners();
            }
        }

        [WebMethod]
        public XmlDocument GetManagementUnitDisplay(String ManagementUnitCode)
        {
            using (ManagementUnitFunctions vfp = new ManagementUnitFunctions())
            {
                return vfp.GetManagementUnit(ManagementUnitCode);
            }
        }

        [WebMethod]
        public XmlDocument GetManagementUnitsDisplay()
        {
            using (ManagementUnitFunctions vfp = new ManagementUnitFunctions())
            {
                return vfp.GetManagementUnits();
            }
        }
    }
}
