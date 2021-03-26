using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using POSTable.ObjectStructures;
using POSTable.WaiterApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSTable.WaiterApp.Pages
{
    public partial class WaiterLogin
    {
        #region Properties
        WaiterLoginController PageController { get; set; }

        [CascadingParameter]
        public WaiterController WaiterController { get; set; }

#pragma warning disable IDE1006 // Naming Styles
        EditContext editContext { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        [Parameter]
        public Waiter Waiter
        {
            get => PageController.Waiter;
            set => PageController = new WaiterLoginController(ref value);
        }

        /// <summary>
        /// this function will be raised by the validation of the error
        /// </summary>
        /// <param name="isValid">the validity of the form</param>
        public void ValidateLogin()
        {
            WaiterController.Waiter = this.Waiter;
            if(editContext.Validate()) WaiterController.PageState = ObjectStructures.Enumerators.Enumerators.PageState.tableMenu;
        }

        /// <summary>
        /// this function will be raised on the initialization of the page
        /// </summary>
        protected override void OnInitialized()
        {
            PageController.ValidateController += ValidateLogin;
            editContext = new EditContext(PageController);
            base.OnInitialized();
        }

        /// <summary>
        /// this function will be raised after each rendering of the page
        /// </summary>
        /// <param name="firstRender">the initial rendering</param>
        /// <returns>the active Task</returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //we can't access the base html objects from c# so we need JavaScripts(Damn the elders of the Internet)
                await JSRuntime.InvokeVoidAsync("focusElement", "tbWaiterCode");
            }
        }
    }
}
