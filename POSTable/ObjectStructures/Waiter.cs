using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTable.ObjectStructures
{
    public class Waiter
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the base id property
        /// </summary>
        protected Int32 id { get; set; } = -1;
        /// <summary>
        /// the waiteCode property
        /// </summary>
        protected String waiterCode { get; set; } = String.Empty;
        /// <summary>
        /// the waiterName property
        /// </summary>
        protected String waiterName { get; set; } = String.Empty;
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Callers
        /// <summary>
        /// the caller for the id property
        /// </summary>
        public Int32 ID 
        { 
            get => id; 
            protected set => id = value; 
        }

        /// <summary>
        /// the caller for the waiterCode property
        /// </summary>
        public String WaiterCode
        {
            get => waiterCode;
            protected set => waiterCode = value;
        }

        /// <summary>
        /// the caller the waiterName property
        /// </summary>
        public String WaiterName
        {
            get => waiterName;
            protected set => waiterName = value;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// the initial simple construtor
        /// </summary>
        public Waiter() { }

        /// <summary>
        /// the base constructor that instantiates the value of both the waiterCode and id
        /// </summary>
        /// <param name="waiterCode">the waiter Code</param>
        /// <param name="waiterName">the waiter Name</param>
        /// <param name="id">the optional id</param>
        public Waiter(String waiterCode, String waiterName,Int32 id = -1)
        {
            WaiterCode = waiterCode;
            WaiterName = waiterName;
            ID = id;
        }
        #endregion
    }
}
