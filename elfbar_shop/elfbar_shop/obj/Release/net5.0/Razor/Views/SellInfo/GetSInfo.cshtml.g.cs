#pragma checksum "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "acfc8aaa8023a414d97e45049f14708a5f05e342"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SellInfo_GetSInfo), @"mvc.1.0.view", @"/Views/SellInfo/GetSInfo.cshtml")]
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
#line 1 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\_ViewImports.cshtml"
using elfbar_shop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\_ViewImports.cshtml"
using elfbar_shop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acfc8aaa8023a414d97e45049f14708a5f05e342", @"/Views/SellInfo/GetSInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e83ebd4f60f5534f521485fa3528aa45ea25533", @"/Views/_ViewImports.cshtml")]
    public class Views_SellInfo_GetSInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<elfbar_shop.Models.Sell_InfoViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SetRBalance", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml"
 if (User.Identity.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""text-center"">
        <br />
        <h2>КАСА</h2>
        <br />
    </div>
    <div class=""card text-center"">
        <div class=""card-header"">
            БАТРАЧИМ ЯК МОЖЕМ, А ГРОШЕЙ ВСЕ НЕМА, ПІДМАНУЛА ПІДВЕЛА
        </div>
        <div class=""card-body"">
            <br />
            <div class=""card-text"">
");
#nullable restore
#line 17 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml"
                 if (Model.curbalance < Model.reqbalance)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4 class=\"text-warning\">БАЛАНС ЗГІДНО ПРОДАЖ => ");
#nullable restore
#line 19 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml"
                                                                    Write(Model?.curbalance);

#line default
#line hidden
#nullable disable
            WriteLiteral(" грн</h4>\r\n");
#nullable restore
#line 20 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml"
                }
                else if (Model.curbalance == Model.reqbalance)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4 class=\"text-warning\">БАЛАНС ЗГІДНО ПРОДАЖ => ");
#nullable restore
#line 23 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml"
                                                                    Write(Model?.curbalance);

#line default
#line hidden
#nullable disable
            WriteLiteral(" грн</h4>\r\n");
#nullable restore
#line 24 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml"
                }
                else if (Model.curbalance > Model.reqbalance)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4 class=\"text-success\">БАЛАНС ЗГІДНО ПРОДАЖ => ");
#nullable restore
#line 27 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml"
                                                                    Write(Model?.curbalance);

#line default
#line hidden
#nullable disable
            WriteLiteral(" грн</h4>\r\n");
#nullable restore
#line 28 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h4>БАЛАНС ЗГІДНО ПРОДАЖ => ");
#nullable restore
#line 31 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml"
                                               Write(Model?.curbalance);

#line default
#line hidden
#nullable disable
            WriteLiteral(" грн</h4>\r\n");
#nullable restore
#line 32 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <br />\r\n            <div class=\"card-text\">\r\n                <h4 class=\"text-warning\">МІНІМАЛЬНО-ПОТРІБНИЙ БАЛАНС (");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "acfc8aaa8023a414d97e45049f14708a5f05e3427003", async() => {
                WriteLiteral("ВИРАХУВАТИ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(") => ");
#nullable restore
#line 36 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml"
                                                                                                                Write(Model?.reqbalance);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" грн</h4> 
            </div>
            <br />
        </div>
        <div class=""card-footer"">
            ПРОБ'ЄМО ПОТОЛОК БІТКА СВОЇМ БАЛІКОМ <br />
            P.S. МІНІМАЛЬНИЙ БАЛІК СЧІТАЄМ ТІЛЬКИ ПІСЛЯ НОВИХ ПОСТАВОК, НЕ ТИКНІТЬ СЛУЧАЙНО
        </div>
    </div>
");
#nullable restore
#line 45 "C:\Users\ALEXBIR\source\repos\elfbar_shop\elfbar_shop\Views\SellInfo\GetSInfo.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<elfbar_shop.Models.Sell_InfoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
