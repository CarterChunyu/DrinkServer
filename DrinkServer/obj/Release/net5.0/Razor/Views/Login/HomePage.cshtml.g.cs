#pragma checksum "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Login\HomePage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbf464a4e0159f03c910c687bd96d1accd70a2f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_HomePage), @"mvc.1.0.view", @"/Views/Login/HomePage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbf464a4e0159f03c910c687bd96d1accd70a2f8", @"/Views/Login/HomePage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f0017d0e3689f8454c5bb17cd1de4ce125c5387", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_HomePage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<label>Hello</label> <label>");
#nullable restore
#line 4 "C:\Users\Administrator\OneDrive\桌面\DrinkServer\DrinkServer\Views\Login\HomePage.cshtml"
                       Write(Model.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591