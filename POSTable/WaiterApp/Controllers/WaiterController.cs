using POSTable.ObjectStructures;
using POSTable.ObjectStructures.Enumerators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace POSTable.WaiterApp.Controllers
{
    public class WaiterController
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the waiter property for the controller
        /// </summary>
        protected Waiter waiter { get; set; } = new();

        /// <summary>
        /// the tables list property for the controller
        /// </summary>
        protected List<Table> tables { get; set; } = new();

        /// <summary>
        /// the selected table for the controller
        /// </summary>
        protected Table selectedTable { get; set; } = new();

        /// <summary>
        /// the base waiter menu property for the controller
        /// </summary>
        protected WaiterMenu waiterMenu { get; set; } = new();

        /// <summary>
        /// the base page state property
        /// </summary>
        protected Enumerators.PageState pageState { get; set; } = Enumerators.PageState.none;
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Callers
        /// <summary>
        /// the caller for the waiter property
        /// </summary>
        public Waiter Waiter
        {
            get => waiter;
            set => waiter = value;
        }

        /// <summary>
        /// the caller for the list as an ObservableCollection
        /// </summary>
        public ObservableCollection<Table> ObservableTables
        {
            get => new(tables);
        }

        /// <summary>
        /// the caller for the tables list property
        /// </summary>
        public List<Table> Tables 
        { 
            get => tables; 
            set => tables = value; 
        }

        /// <summary>
        /// the caller for the waiter menu property
        /// </summary>
        public WaiterMenu WaiterMenu
        {
            get => waiterMenu;
            set => waiterMenu = value;
        }

        /// <summary>
        /// the caller for the page state property
        /// </summary>
        public Enumerators.PageState PageState
        {
            get => pageState;
            set => ChangePageState(value);
        }

        /// <summary>
        /// this function will select the selected Table by the given ID
        /// </summary>
        /// <param name="tableId">the given ID</param>
        public void SelectTable(Int32 tableId) => selectedTable = tables.Where(element => element.ID == tableId).FirstOrDefault();
        #endregion

        /// <summary>
        /// the onChange Action Caller => will contain the invocable action on the page refresh
        /// </summary>
        public event Action OnChange;

        /// <summary>
        /// this function will invoke the OnChange Event for the form
        /// </summary>
        protected void NotifyStateChanged() => OnChange?.Invoke();

        /// <summary>
        /// this function will be called by the 
        /// </summary>
        /// <param name="pageState">the new page state</param>
        protected void ChangePageState(Enumerators.PageState pageState)
        {
            this.pageState = pageState;
            NotifyStateChanged();
        }
    }
}
