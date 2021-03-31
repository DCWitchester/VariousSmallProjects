using Microsoft.AspNetCore.Components;
using POSTable.WaiterApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static POSTable.ObjectStructures.Enumerators.Enumerators;

namespace POSTable.WaiterApp.Pages
{
    public partial class WaiterCommand
    {
        #region Parameters
        [CascadingParameter]
        public WaiterController WaiterController { get; set; }
        #endregion

        #region Functionality
        /// <summary>
        /// this function will reset the selection for all the items
        /// </summary>
        protected void ResetSelection()
        {
            WaiterController.WaiterMenu.MenuItems.ForEach(element =>
            {
                element.IsSelected = false;
                element.ProductQuantity = 0;
            });
        }

        /// <summary>
        /// the main function for the validation of the command
        /// </summary>
        protected void ReturnToValidation()
        {
            WaiterController.PageState = PageState.itemMenu;
        }

        protected async void CreateSale()
        {
            String document = WaiterController.CreateSale();
            await http.GetAsync(WebMethods.SetSales + document);
            ResetSelection();
            WaiterController.PageState = PageState.tableMenu;
        }
        #endregion
    }
}
