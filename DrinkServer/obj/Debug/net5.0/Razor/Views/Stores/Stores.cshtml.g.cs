#pragma checksum "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12712f4b2b6313ddb755bd2a1d09269437efaaa7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Stores_Stores), @"mvc.1.0.view", @"/Views/Stores/Stores.cshtml")]
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
#line 1 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\_ViewImports.cshtml"
using DrinkServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\_ViewImports.cshtml"
using DrinkServer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\_ViewImports.cshtml"
using DrinkServer.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\_ViewImports.cshtml"
using DrinkServer.Views.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\_ViewImports.cshtml"
using DrinkServer.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
using DrinkServer.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12712f4b2b6313ddb755bd2a1d09269437efaaa7", @"/Views/Stores/Stores.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc466a9d93a6df77398a5b8f6b6c315928263867", @"/Views/_ViewImports.cshtml")]
    public class Views_Stores_Stores : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Store>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Stores_Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Stores_Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
  
    ViewData["Title"] = "Index";
    var s = ViewBag.x as ListViewModel;
    int page = int.Parse(ViewData["nowpage"].ToString());
    int pages = int.Parse(ViewData["pages"].ToString());
    int range = 4;
    int add = page + range - pages <= 0 ? 0 : page + range - pages;
    int pbegin = page - range - add >= 1 ? page - range - add : 1;
    int pend = pbegin + 8 <= pages ? pbegin + 8 : pages;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"

        <table class=""indexTable"">
            <caption>Stores</caption>
            <thead>
                <tr>
                    <th scope=""col"" width=""20%"">Region</th>
                    <th scope=""col"" width=""80%"">Name</th>
                </tr>
            </thead>
            <tbody class=""bg-white"">
");
#nullable restore
#line 26 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 30 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Location.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12712f4b2b6313ddb755bd2a1d09269437efaaa76446", async() => {
#nullable restore
#line 33 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                                                                              Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
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
#line 33 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
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
            WriteLiteral("\r\n                        </td>\r\n\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 38 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n        <nav>\r\n            <ul class=\"pagination pagination-sm\">\r\n");
#nullable restore
#line 44 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                 if (page == 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item disabled\"><a class=\"page-link\" disabled=\"disabled\">Previous</a></li>\r\n");
#nullable restore
#line 47 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                }
                else
                {
                    string url = $"/Stores/Stores?page={page - 1}";

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item active\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1739, "\"", 1750, 1);
#nullable restore
#line 51 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
WriteAttributeValue("", 1746, url, 1746, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Previous</a></li>\r\n");
#nullable restore
#line 52 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 55 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                 for (int i = pbegin; i <= pend; i++)
                {
                    string url = $"/Stores/Stores?page={i}";
                    if (i == page)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item\"><a class=\"page-link\" style=\"color:red\"");
            BeginWriteAttribute("href", " href=\"", 2073, "\"", 2084, 1);
#nullable restore
#line 60 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
WriteAttributeValue("", 2080, url, 2080, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 60 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                                                                                            Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 61 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"

                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2239, "\"", 2250, 1);
#nullable restore
#line 65 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
WriteAttributeValue("", 2246, url, 2246, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 65 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                                                                          Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 66 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 70 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                 if (page == pages)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\"><a class=\"page-link\" disabled=\"disabled\">Next</a></li>\r\n");
#nullable restore
#line 73 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                }
                else
                {
                    string url = $"/Stores/Stores?page={page + 1}";

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2656, "\"", 2667, 1);
#nullable restore
#line 77 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
WriteAttributeValue("", 2663, url, 2663, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Next</a></li>\r\n");
#nullable restore
#line 78 "C:\Users\m1218\Desktop\飲料\DrinkServer\DrinkServer\Views\Stores\Stores.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n\r\n        </nav>\r\n\r\n        <div class=\"form-group row mt-5\">\r\n            <div class=\"col\">\r\n");
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12712f4b2b6313ddb755bd2a1d09269437efaaa714426", async() => {
                WriteLiteral("New Store");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Store>> Html { get; private set; }
    }
}
#pragma warning restore 1591
