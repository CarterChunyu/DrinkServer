#pragma checksum "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47ba2e8b9a4fba609d630fe6173fa78945371a67"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WarehouseCreateViewModels_Warehouses), @"mvc.1.0.view", @"/Views/WarehouseCreateViewModels/Warehouses.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\_ViewImports.cshtml"
using DrinkServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\_ViewImports.cshtml"
using DrinkServer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\_ViewImports.cshtml"
using DrinkServer.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\_ViewImports.cshtml"
using DrinkServer.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\_ViewImports.cshtml"
using DrinkServer.Views.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47ba2e8b9a4fba609d630fe6173fa78945371a67", @"/Views/WarehouseCreateViewModels/Warehouses.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f0017d0e3689f8454c5bb17cd1de4ce125c5387", @"/Views/_ViewImports.cshtml")]
    public class Views_WarehouseCreateViewModels_Warehouses : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Warehouse>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Warehouses_Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Warehouses_Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
  
    int page = int.Parse(ViewData["nowpage"].ToString());
    int pages = int.Parse(ViewData["pages"].ToString());
    int range = 3;
    int add = page + range - pages <= 0 ? 0 : page + range - pages;
    int pbegin = page - range - add >= 1 ? page - range - add : 1;
    int pend = pbegin + 8 <= pages ? pbegin + 8 : pages;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <table class=""indexTable"">
            <caption>Warehouses</caption>
            <thead>
                <tr>
                    <th scope=""col"" width=""100%"">Name</th>
                </tr>
            </thead>
            <tbody class=""bg-white"">
");
#nullable restore
#line 20 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "47ba2e8b9a4fba609d630fe6173fa78945371a676348", async() => {
                WriteLiteral("<strong>");
#nullable restore
#line 25 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                                                                                          Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                                                                 WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 28 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n\r\n        <nav>\r\n            <ul class=\"pagination pagination-sm\">\r\n");
#nullable restore
#line 35 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                 if (page == 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item disabled\"><a class=\"page-link\" disabled=\"disabled\">Previous</a></li>\r\n");
#nullable restore
#line 38 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                }
                else
                {
                    string url = $"/WarehouseCreateViewModels/Warehouses?page={page - 1}";

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item active\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1483, "\"", 1494, 1);
#nullable restore
#line 42 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
WriteAttributeValue("", 1490, url, 1490, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Previous</a></li>\r\n");
#nullable restore
#line 43 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 46 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                 for (int i = pbegin; i <= pend; i++)
                {
                    string url = $"/WarehouseCreateViewModels/Warehouses?page={i}";
                    if (i == page)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item\"><a class=\"page-link\" style=\"color:red\"");
            BeginWriteAttribute("href", " href=\"", 1840, "\"", 1851, 1);
#nullable restore
#line 51 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
WriteAttributeValue("", 1847, url, 1847, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 51 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                                                                                            Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 52 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"

                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2006, "\"", 2017, 1);
#nullable restore
#line 56 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
WriteAttributeValue("", 2013, url, 2013, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 56 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                                                                          Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 57 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 61 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                 if (page == pages)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\"><a class=\"page-link\" disabled=\"disabled\">Next</a></li>\r\n");
#nullable restore
#line 64 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                }
                else
                {
                    string url = $"/WarehouseCreateViewModels/Warehouses?page={page + 1}";

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2446, "\"", 2457, 1);
#nullable restore
#line 68 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
WriteAttributeValue("", 2453, url, 2453, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Next</a></li>\r\n");
#nullable restore
#line 69 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\WarehouseCreateViewModels\Warehouses.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n\r\n        </nav>\r\n\r\n        <div class=\"form-group row mt-5\">\r\n            <div class=\"col\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "47ba2e8b9a4fba609d630fe6173fa78945371a6715041", async() => {
                WriteLiteral("New Warehouse");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Warehouse>> Html { get; private set; }
    }
}
#pragma warning restore 1591
