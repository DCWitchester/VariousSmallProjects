using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTable.ObjectStructures
{
    public class Table
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the id property for the table
        /// </summary>
        protected Int32 id { get; set; } = new Int32();
        /// <summary>
        /// the status property for the table
        /// </summary>
        protected Enumerators.Enumerators.Status status { get; set; } = Enumerators.Enumerators.Status.none;
        /// <summary>
        /// the active waiter for the table
        /// </summary>
        protected Waiter activeWaiter { get; set; } = new Waiter();
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
        /// the caller for the status property
        /// </summary>
        public Enumerators.Enumerators.Status Status
        {
            get => status;
            protected set => status = value;
        }
        /// <summary>
        /// the caller for the activeWaiter property
        /// </summary>
        public Waiter ActiveWaiter
        {
            get => activeWaiter;
            set => activeWaiter = value;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// the base constructor without parameters
        /// </summary>
        public Table() { }

        /// <summary>
        /// the base constructor with all optional parameters
        /// </summary>
        /// <param name="id">the base id for the object</param>
        /// <param name="status">the base status for the object</param>
        /// <param name="waiter">the waiter reference for the object</param>
        public Table(Int32 id = -1, Enumerators.Enumerators.Status status = Enumerators.Enumerators.Status.none, Waiter waiter = null) 
        {
            ID = id;
            Status = status;
            if(waiter != null) ActiveWaiter = waiter;
        }
        #endregion
    }
}
