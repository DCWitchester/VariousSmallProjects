using System;
using System.Collections.Generic;
using System.Text;
using static BarcodeScanner.Services.WebServiceMethods;

namespace BarcodeScanner.ObjectClasses
{
    public class EntryDocument
    {
        #region Protected Properties
        protected Int32 id { get; set; } = new Int32();
        protected String managementUnitCode { get; set; } = String.Empty;
        protected String managementUnitName { get; set; } = String.Empty;
        protected String partnerCode { get; set; } = String.Empty;
        protected String partnerName { get; set; } = String.Empty;
        protected Int32 documentNumber { get; set; } = new Int32();
        protected Boolean isNotice { get; set; } = false;
        protected DateTime documentDate { get; set; } = DateTime.Now;
        #endregion

        #region Callers
        public Int32 ID
        {
            get => id;
            set => id = value;
        }

        public String ManagementUnitCode
        {
            get => managementUnitCode;
            set => managementUnitCode = UpdateManagementUnitNameByCode(value);
        }

        public void SetManagementUnitCodeAndName(String managementUnitCode, String managementUnitName)
        {
            this.managementUnitCode = managementUnitCode;
            this.managementUnitName = managementUnitName;
            OnChangeManagementUnitNameAndCode?.Invoke();
        }

        public String ManagementUnitName
        {
            get => managementUnitName;
            set => managementUnitName = value;
        }

        public String PartnerCode
        {
            get => partnerCode;
            set => partnerCode = UpdatePartnerNameByCode(value);
        }

        public void SetPartnerCodeAndName(String partnerCode, String partnerName)
        {
            this.partnerCode = partnerCode;
            this.partnerName = partnerName;
            OnChangePartnerNameAndCode?.Invoke();
        }

        public String PartnerName
        {
            get => partnerName;
            set => partnerName = value;
        }

        public Int32 DocumentNumber
        {
            get => documentNumber;
            set => documentNumber = value;
        }

        public Boolean IsNotice
        {
            get => isNotice;
            set => isNotice = value;
        }

        public DateTime DocumentDate
        {
            get => documentDate;
            set => documentDate = value;
        }

        public String GetDateValue => documentDate.ToString("dd.MM.yyyy");
        #endregion

        #region Functionality
        public String UpdatePartnerNameByCode(String partnerCode)
        {
            if (!String.IsNullOrEmpty(partnerCode))
            {
                this.PartnerName = GetPartnerName(partnerCode) ?? String.Empty;
                if(!String.IsNullOrWhiteSpace(this.PartnerName)) OnChangePartnerName?.Invoke();
            }
            return partnerCode;
        }

        public String UpdateManagementUnitNameByCode(String managementUnit)
        {
            if (!String.IsNullOrWhiteSpace(managementUnit))
            {
                this.ManagementUnitName = GetManagementUnitName(managementUnit) ?? String.Empty;
                if(!String.IsNullOrWhiteSpace(this.ManagementUnitName)) OnChangeManagementUnitName?.Invoke();
            }
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
