#pragma checksum "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13a9e18d16d761a5313269183322ab4b45725ef5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Process2), @"mvc.1.0.view", @"/Views/Orders/Process2.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13a9e18d16d761a5313269183322ab4b45725ef5", @"/Views/Orders/Process2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f0017d0e3689f8454c5bb17cd1de4ce125c5387", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Process2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MaterialCategory>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/boder.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-link me-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Orders/Process"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bgBody"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
  
    Layout = null;
    int OrderId = ViewBag.OrderId;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n<!doctype html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13a9e18d16d761a5313269183322ab4b45725ef59794", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "13a9e18d16d761a5313269183322ab4b45725ef510186", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "13a9e18d16d761a5313269183322ab4b45725ef511365", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <title>Process Order</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13a9e18d16d761a5313269183322ab4b45725ef513284", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13a9e18d16d761a5313269183322ab4b45725ef513547", async() => {
                    WriteLiteral("\r\n        <nav class=\"navbar navbar-expand-md navbar-dark mb-4 bgNav\">\r\n            <div class=\"container-fluid\">\r\n                <a class=\"navbar-brand\" href=\"#\">SNR</a>\r\n            </div>\r\n        </nav>\r\n\r\n        <input type=\"hidden\" name=\"OrderId\"");
                    BeginWriteAttribute("value", " value=\"", 759, "\"", 775, 1);
#nullable restore
#line 28 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
WriteAttributeValue("", 767, OrderId, 767, 8, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@" />
        <main role=""main"" class=""container mb-5"">

            <h3 class=""mb-3"">Process Order # 156</h3>

            <div class=""details"">

                <div class=""row"">
                    <dl class=""col-md-4 col-sm-12"">
                        <dt>From</dt>
                        <dd>");
#nullable restore
#line 38 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                       Write(ViewBag.formToInfo.Split(',')[1]);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</dd>\r\n                    </dl>\r\n                    <dl class=\"col-md-4 col-sm-12\">\r\n                        <dt>To</dt>\r\n                        <dd>");
#nullable restore
#line 42 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                       Write(ViewBag.formToInfo.Split(',')[2]);

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"</dd>
                    </dl>
                    <dl class=""col-md-4 col-sm-12"">
                        <dt>Order Date</dt>
                        <dd>
                            2021-11-07 1:07 pm
                            <br>by Name(userId)
                        </dd>
                    </dl>
                </div>
                <input type=""hidden"" name=""formToInfo""");
                    BeginWriteAttribute("value", " value=\"", 1696, "\"", 1723, 1);
#nullable restore
#line 52 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
WriteAttributeValue("", 1704, ViewBag.formToInfo, 1704, 19, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"QTYInfo\" id=\"qtyinfo\"");
                    BeginWriteAttribute("value", " value=\"", 1793, "\"", 1825, 1);
#nullable restore
#line 53 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
WriteAttributeValue("", 1801, ViewBag.ForSaveQTYInfos, 1801, 24, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@" />

            </div>


            <div class=""ordersProcess"">
                <div class=""opRow"">
                    <label class=""opTH opThWHStatus"" for=""SelectStatus"">Status</label>
                    <div class=""opTD opTdWHStatus"">
                        <select class=""form-select form-select-sm my-1"" id=""SelectStatus"" aria-label=""Select Status"" name=""Staus"">
                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13a9e18d16d761a5313269183322ab4b45725ef517227", async() => {
                        WriteLiteral("New");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13a9e18d16d761a5313269183322ab4b45725ef518631", async() => {
                        WriteLiteral("Processing");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13a9e18d16d761a5313269183322ab4b45725ef519951", async() => {
                        WriteLiteral("Fulfilled");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13a9e18d16d761a5313269183322ab4b45725ef521270", async() => {
                        WriteLiteral("Cancelled");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_7.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral(@"
                        </select>
                    </div>
                </div>
                <div class=""opRow"">
                    <label class=""opTH opThWHDD"" for=""DeliveryDate"">Delivery Date</label>
                    <div class=""opTD opTdWHDD""><input type=""date"" class=""form-control form-control-sm my-1"" id=""DeliveryDate"" name=""DeliveryDate""></div>
                </div>
                Only users that can process this warehouse will see these private notes.
                <div class=""opRow"">
                    <div class=""opTH opThWHPrivateNote"">
                        <label");
                    BeginWriteAttribute("class", " class=\"", 3087, "\"", 3095, 0);
                    EndWriteAttribute();
                    WriteLiteral(@" for=""PrivateNote"">Private Note</label>
                        <div class=""opHelpText"">Only users that can process this warehouse will see these notes.</div>
                    </div>
                    <div class=""opTD opTdWHPrivateNote"">
                        <textarea class=""form-control form-control-sm"" id=""PrivateNotes"" rows=""5"" name=""Notes""></textarea>
                    </div>
                </div>
            </div>


");
#nullable restore
#line 87 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
             foreach (var category in Model)
            {
                if (ViewBag.SelectCategies.Contains(category.Name))
                {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                    <div class=\"ocCaption\">");
#nullable restore
#line 91 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                                      Write(category.Name);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</div>\r\n");
                    WriteLiteral(@"                    <div class=""ordersContainer"">
                        <div class=""ocRowTH"">
                            <div class=""ocTH"">&nbsp;</div>
                            <div class=""ocTH"">SKU</div>
                            <div class=""ocTH"">Name</div>
                            <div class=""ocTH text-center"">Last Order</div>
                            <div class=""ocTH text-center"">QTY</div>
                        </div>

");
#nullable restore
#line 102 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                         foreach (var material in category.Materials)
                        {
                            if (ViewBag.QTYInfos.ContainsKey(material.Id.ToString()))
                            {
                                string x = ViewBag.QTYInfos[material.Id.ToString()];
                                if (x.Contains(","))
                                {
                                    foreach (var item in x.Split(","))
                                    {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                        <div class=\"ocRowTD\">\r\n                                            <div class=\"ocTD occTN\"><img");
                    BeginWriteAttribute("src", " src=\"", 4848, "\"", 4879, 2);
                    WriteAttributeValue("", 4854, "/Images/", 4854, 8, true);
#nullable restore
#line 112 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
WriteAttributeValue("", 4862, material.Picture, 4862, 17, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"rounded occTNimg\"");
                    BeginWriteAttribute("alt", " alt=\"", 4905, "\"", 4911, 0);
                    EndWriteAttribute();
                    WriteLiteral("></div>\r\n                                            <div class=\"ocTD ocTdSKU\">");
#nullable restore
#line 113 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                                                                 Write(material.Sku);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</div>\r\n                                            <div class=\"ocTD ocTdName\">\r\n                                                ");
#nullable restore
#line 115 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                                           Write(material.EnglishName);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                                <br>");
#nullable restore
#line 116 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                                               Write(material.ChineseName);

#line default
#line hidden
#nullable disable
                    WriteLiteral(@"
                                            </div>
                                            <div class=""ocTD ocTdLastQTY"">5</div>
                                            <div class=""ocTD ocTdQTY"">
                                                ");
#nullable restore
#line 120 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                                           Write(item);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 123 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                                    }
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                    <div class=\"ocRowTD\">\r\n                                        <div class=\"ocTD occTN\"><img");
                    BeginWriteAttribute("src", " src=\"", 5867, "\"", 5898, 2);
                    WriteAttributeValue("", 5873, "/Images/", 5873, 8, true);
#nullable restore
#line 128 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
WriteAttributeValue("", 5881, material.Picture, 5881, 17, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"rounded occTNimg\"");
                    BeginWriteAttribute("alt", " alt=\"", 5924, "\"", 5930, 0);
                    EndWriteAttribute();
                    WriteLiteral("></div>\r\n                                        <div class=\"ocTD ocTdSKU\">");
#nullable restore
#line 129 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                                                             Write(material.Sku);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</div>\r\n                                        <div class=\"ocTD ocTdName\">\r\n                                            ");
#nullable restore
#line 131 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                                       Write(material.EnglishName);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                            <br>");
#nullable restore
#line 132 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                                           Write(material.ChineseName);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                        </div>\r\n                                        <div class=\"ocTD ocTdLastQTY\">5</div>\r\n                                        <div class=\"ocTD ocTdQTY\">\r\n                                            ");
#nullable restore
#line 136 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                                       Write(x);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 139 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"

                                }



                            }
                        }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                    </div>\r\n");
#nullable restore
#line 147 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Orders\Process2.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n\r\n            <div class=\"form-group row mt-5\">\r\n                <div class=\"col\">\r\n                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13a9e18d16d761a5313269183322ab4b45725ef531875", async() => {
                        WriteLiteral("Cancel");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                    <button type=\"submit\" class=\"btn btn-primary\">Save</button>\r\n                </div>\r\n            </div>\r\n\r\n        </main>\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_12.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13a9e18d16d761a5313269183322ab4b45725ef534839", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MaterialCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591