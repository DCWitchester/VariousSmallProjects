#pragma checksum "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90851a057c1307ceb83590233deeceb8ee554f57"
// <auto-generated/>
#pragma warning disable 1591
namespace POSTable.WaiterApp.Pages
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
    public partial class WaiterCommand : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1 style=\"font-family: \'Brush Script MT\' \">Meniu</h1>\r\n<br>\r\n\r\n");
            __builder.OpenElement(1, "h2");
            __builder.AddAttribute(2, "style", "font-family: \'Brush Script MT\' ");
            __builder.AddContent(3, "Masa ");
            __builder.AddContent(4, 
#nullable restore
#line 12 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
                                                  WaiterController.SelectedTable.ID.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n<br>\r\n\r\n");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "style", "width:100%; margin-bottom:20px");
#nullable restore
#line 16 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
     foreach (var element in WaiterController.WaiterMenu.SaleItems)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "style", "display:flex");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "style", "width:50%; font-weight: bold; float:left; text-align: left");
            __builder.AddContent(12, 
#nullable restore
#line 20 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
                 element.ProductName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n            ");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "style", "width:10%; font-weight: bold; float:left; text-align: left");
            __builder.AddContent(16, 
#nullable restore
#line 23 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
                 element.ProductQuantity

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(17, " BUC\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n            ");
            __builder.AddMarkupContent(19, "<div style=\"width:5%; font-weight: bold; float:left;\">\r\n                X\r\n            </div>\r\n            ");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "style", "width:10%; font-weight: bold; float:left; text-align: right");
            __builder.AddContent(22, 
#nullable restore
#line 29 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
                  element.ProductPrice.ToString("0.00")

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n            ");
            __builder.AddMarkupContent(24, "<div style=\"width:5%; font-weight: bold; float:left;\">\r\n                =\r\n            </div>\r\n            ");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "style", "width:20%; font-weight: bold; float:right; text-align: right");
            __builder.AddContent(27, 
#nullable restore
#line 35 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
                  (element.ProductQuantity * element.ProductPrice).ToString("0.00")

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(28, " ");
            __builder.AddContent(29, 
#nullable restore
#line 35 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
                                                                                      Miscellaneous.SetCurrency()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n            <br>");
            __builder.CloseElement();
#nullable restore
#line 39 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(31, "div");
            __builder.AddAttribute(32, "style", " width:100%; font-weight: bold; border-top: 2px solid black; float:right; text-align: right; margin-top:25px; margin-bottom:40px");
            __builder.AddMarkupContent(33, "\r\n        Total : ");
            __builder.AddContent(34, 
#nullable restore
#line 41 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
                  WaiterController.WaiterMenu.SaleItems.Sum(x => x.ProductQuantity * x.ProductPrice).ToString("0.00")

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(35, " ");
            __builder.AddContent(36, 
#nullable restore
#line 41 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
                                                                                                                        Miscellaneous.SetCurrency()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n<br>\r\n");
            __builder.OpenElement(38, "button");
            __builder.AddAttribute(39, "class", "btn btn-mentor");
            __builder.AddAttribute(40, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 45 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
                                         CreateSale

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(41, "Finalizare Comanda");
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n\r\n");
            __builder.OpenElement(43, "button");
            __builder.AddAttribute(44, "class", "btn btn-mentor");
            __builder.AddAttribute(45, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 47 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
                                         ResetSelection

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(46, "Resetare Comanda");
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n");
            __builder.OpenElement(48, "button");
            __builder.AddAttribute(49, "class", "btn btn-mentor");
            __builder.AddAttribute(50, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 48 "F:\VariousProjects\VariousSmallProjects\POSTable\WaiterApp\Pages\WaiterCommand.razor"
                                         ReturnToValidation

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(51, "Inapoi la selectie");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager myNavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
