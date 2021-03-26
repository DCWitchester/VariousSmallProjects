using System;
using System.Collections.Generic;
using System.Text;
using static BarcodeScanner.Services.WebServiceMethods;

namespace BarcodeScanner.ObjectClasses
{
    public class EntryDocument
    {
        #region Protected Properties
        /// <summary>
        /// the base id for the EntryDocument 
        /// </summary>
        protected Int32 id { get; set; } = new Int32();
        /// <summary>
        /// the management unit code 
        /// </summary>
        protected String managementUnitCode { get; set; } = String.Empty;
        /// <summary>
        /// the management unit name
        /// </summary>
        protected String managementUnitName { get; set; } = String.Empty;
        /// <summary>
        /// the partner Code
        /// </summary>
        protected String partnerCode { get; set; } = String.Empty;
        /// <summary>
        /// the partner name
        /// </summary>
        protected String partnerName { get; set; } = String.Empty;
        /// <summary>
        /// the document number
        /// </summary>
        protected Int32 documentNumber { get; set; } = new Int32();
        /// <summary>
        /// the check that will tell if the document is a notice or not
        /// </summary>
        protected Boolean isNotice { get; set; } = false;
        /// <summary>
        /// the document date 
        /// </summary>
        protected DateTime documentDate { get; set; } = DateTime.Now;
        #endregion

        #region Callers
        /// <summary>
        /// the caller for the ID
        /// </summary>
        public Int32 ID
        {
            get => id;
            set => id = value;
        }

        /// <summary>
        /// the management unit code caller
        /// </summary>
        public String ManagementUnitCode
        {
            get => managementUnitCode;
            set => managementUnitCode = UpdateManagementUnitNameByCode(value);
        }

        /// <summary>
        /// this function will set the management unit code and name from the received parameters then call the page refresh
        /// </summary>
        /// <param name="managementUnitCode">the management unit code</param>
        /// <param name="managementUnitName">the management unit name</param>
        public void SetManagementUnitCodeAndName(String managementUnitCode, String managementUnitName)
        {
            this.managementUnitCode = managementUnitCode;
            this.managementUnitName = managementUnitName;
            OnChangeManagementUnitNameAndCode?.Invoke();
        }

        /// <summary>
        /// the caller for the management unit name
        /// </summary>
        public String ManagementUnitName
        {
            get => managementUnitName;
            set => managementUnitName = value;
        }

        /// <summary>
        /// the caller for the partner code
        /// </summary>
        public String PartnerCode
        {
            get => partnerCode;
            set => partnerCode = UpdatePartnerNameByCode(value);
        }

        /// <summary>
        /// this function will set the partner code and name received as parameters and then call the refresh
        /// </summary>
        /// <param name="partnerCode">the given partner code</param>
        /// <param name="partnerName">the given partner name</param>
        public void SetPartnerCodeAndName(String partnerCode, String partnerName)
        {
            this.partnerCode = partnerCode;
            this.partnerName = partnerName;
            OnChangePartnerNameAndCode?.Invoke();
        }

        /// <summary>
        /// the caller for the partner name
        /// </summary>
        public String PartnerName
        {
            get => partnerName;
            set => partnerName = value;
        }

        /// <summary>
        /// the caller for the document number
        /// </summary>
        public Int32 DocumentNumber
        {
            get => documentNumber;
            set => documentNumber = value;
        }

        /// <summary>
        /// the caller for the state of the document(if it is an invoice or a notice)
        /// </summary>
        public Boolean IsNotice
        {
            get => isNotice;
            set => isNotice = value;
        }

        /// <summary>
        /// the caller for the document date
        /// </summary>
        public DateTime DocumentDate
        {
            get => documentDate;
            set => documentDate = value;
        }

        /// <summary>
        /// the caller for the formatted date string 
        /// </summary>
        public String GetDateValue => documentDate.ToString("dd.MM.yyyy");
        #endregion

        #region Functionality
        /// <summary>
        /// this function will update a partners name from the webService by its given name
        /// </summary>
        /// <param name="partnerCode">the given partner code</param>
        /// <returns>the partner code</returns>
        public String UpdatePartnerNameByCode(String partnerCode)
        {
            if (!String.IsNullOrEmpty(partnerCode))
            {
                this.PartnerName = GetPartnerName(partnerCode) ?? String.Empty;
                if(!String.IsNullOrWhiteSpace(this.PartnerName)) OnChangePartnerName?.Invoke();
            }
            //the partner code is returned because this function will be called by the setter of the partner code
            return partnerCode;
        }

        /// <summary>
        /// this function will update the management unit name by its given code
        /// </summary>
        /// <param name="managementUnit">the given code</param>
        /// <returns>the given code</returns>
        public String UpdateManagementUnitNameByCode(String managementUnit)
        {
            if (!String.IsNullOrWhiteSpace(managementUnit))
            {
                this.ManagementUnitName = GetManagementUnitName(managementUnit) ?? String.Empty;
                if(!String.IsNullOrWhiteSpace(this.ManagementUnitName)) OnChangeManagementUnitName?.Invoke();
            }
            //the management unit code is returned because this function will be called by the setter of the management unit code
            return managementUnit;
        }
        #endregion

        #region PageRefresh
        /// <summary>
        /// the onChange Action Caller => will contain the invocable action on page refresh
        /// </summary>
        public event Action OnChangePartnerName;

        /// <summary>
        /// the onChange Action Caller => will contain the invocable action on page refresh
        /// </summary>
        public event Action OnChangeManagementUnitName;

        /// <summary>
        /// the onChange Action Caller => will contain the invocable action on page refresh
        /// </summary>
        public event Action OnChangePartnerNameAndCode;

        /// <summary>
        /// the onChange Action Caller => will contain the invocable action on page refresh
        /// </summary>
        public event Action OnChangeManagementUnitNameAndCode;
        #endregion
    }
}
