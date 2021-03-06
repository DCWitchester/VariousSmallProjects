// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace POSTable.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\VariousProjects\VariousSmallProjects\POSTable\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\VariousProjects\VariousSmallProjects\POSTable\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\VariousProjects\VariousSmallProjects\POSTable\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\VariousProjects\VariousSmallProjects\POSTable\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\VariousProjects\VariousSmallProjects\POSTable\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\VariousProjects\VariousSmallProjects\POSTable\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\VariousProjects\VariousSmallProjects\POSTable\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\VariousProjects\VariousSmallProjects\POSTable\_Imports.razor"
using POSTable;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\VariousProjects\VariousSmallProjects\POSTable\_Imports.razor"
using POSTable.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/tableopen")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/tableopen/{table:int}")]
    public partial class TableOpen : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "F:\VariousProjects\VariousSmallProjects\POSTable\Pages\TableOpen.razor"
       
    //the Main Table Parameter set for the form
    [Parameter]
    public Int32 table { get; set; }

    /// <summary>
    /// the EndSale function will navigate to the EndMessage
    /// </summary>
    /// <param name="e">the Click Event</param>
    void EndSale(MouseEventArgs e)
    {
        myNavigationManager.NavigateTo("/endmessage");
    }

    /// <summary>
    /// the StartSale function will navigate to the Main Sale Page
    /// </summary>
    /// <param name="e">the Click Event</param>
    void StartSale(MouseEventArgs e)
    {
        myNavigationManager.NavigateTo("/tablemenu/" + table + "/true");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager myNavigationManager { get; set; }
    }
}
#pragma warning restore 1591
