#pragma checksum "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1b5be524c6d21869fe4265244467a714e3d439a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat_Create), @"mvc.1.0.view", @"/Views/Chat/Create.cshtml")]
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
#line 1 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\_ViewImports.cshtml"
using SimpleMessenger;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\_ViewImports.cshtml"
using SimpleMessenger.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1b5be524c6d21869fe4265244467a714e3d439a", @"/Views/Chat/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c6583efbd5618cf08b08b83cd757ca5008cc90d", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SimpleMessenger.Shared.Account>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\Create.cshtml"
  
    ViewData["Title"] = "New chat";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\" style=\"margin-top:30px; justify-content:center\">\r\n    <div class=\"col-lg-7\">\r\n        <div class=\"card\" style=\"min-height:500px; max-height:501px; overflow-y:scroll; text-align:center\">\r\n");
#nullable restore
#line 10 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\Create.cshtml"
             foreach (var i in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card\" style=\"padding:5px 5px 5px 5px; margin:10px 10px 10px 10px\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c1b5be524c6d21869fe4265244467a714e3d439a4713", async() => {
                WriteLiteral("\r\n                        <div class=\"row\">\r\n                            <div class=\"col-lg-12 text-left\">\r\n                                <input name=\"toUserId\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 683, "\"", 696, 1);
#nullable restore
#line 16 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\Create.cshtml"
WriteAttributeValue("", 691, i.Id, 691, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                <label class=\"font-weight-bold\">");
#nullable restore
#line 17 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\Create.cshtml"
                                                           Write(i.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</label>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-lg-12 text-right"">
                                <button type=""submit"" class=""btn btn-primary""><i class=""bi bi-send-plus""></i> To chat</button>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 27 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\Create.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SimpleMessenger.Shared.Account>> Html { get; private set; }
    }
}
#pragma warning restore 1591
