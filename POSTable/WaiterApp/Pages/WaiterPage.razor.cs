using Microsoft.AspNetCore.Components;
using POSTable.WaiterApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTable.WaiterApp.Pages
{
    public partial class WaiterPage 
    {
        #region Properties
        readonly WaiterController PageController = new();
        #endregion

        #region Functionality
        /// <summary>
        /// this function will be raised on the initialization of the page
        /// </summary>
        protected override void OnInitialized()
        {
            PageController.OnChange += StateHasChanged;
            PageController.PageState = ObjectStructures.Enumerators.Enumerators.PageState.waitingForLogin;
        }   
        #endregion
    }
}
