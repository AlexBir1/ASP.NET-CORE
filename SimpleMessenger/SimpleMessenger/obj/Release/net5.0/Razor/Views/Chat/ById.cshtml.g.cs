#pragma checksum "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\ById.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8454172c0af208d3b43244fd8b596e3686460afb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat_ById), @"mvc.1.0.view", @"/Views/Chat/ById.cshtml")]
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
#nullable restore
#line 1 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\ById.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8454172c0af208d3b43244fd8b596e3686460afb", @"/Views/Chat/ById.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c6583efbd5618cf08b08b83cd757ca5008cc90d", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat_ById : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SimpleMessenger.Shared.Chat>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\" style=\"margin-top:10px\">\r\n<input type=\"hidden\" id=\"userNameVal\"");
            BeginWriteAttribute("value", " value=\"", 155, "\"", 200, 1);
#nullable restore
#line 5 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\ById.cshtml"
WriteAttributeValue("", 163, User.FindFirstValue(ClaimTypes.Name), 163, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <div");
            BeginWriteAttribute("id", " id=\"", 214, "\"", 228, 1);
#nullable restore
#line 6 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\ById.cshtml"
WriteAttributeValue("", 219, Model.Id, 219, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""row"" style=""justify-content:center"">
        <div class=""col-lg-6"">
            <div class=""card"">
                <div id=""headPanel"" class=""card"" style=""min-height:50px; margin-bottom:5px"">

                </div>
                <div id=""msgsContent"" class=""card"" style=""min-height:400px; max-height:401px; margin-bottom:5px; overflow-y:scroll"">
");
#nullable restore
#line 13 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\ById.cshtml"
                     if (Model.Messages is not null)
                    {
                        foreach (var msg in Model.Messages)
                        {
                            if (msg.Account_Nickname == User.FindFirstValue(ClaimTypes.Name))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div style=""display:block; margin-left:auto; margin-right:5px"">
                                    <div class=""card"" style=""margin-left: 10px; margin-top: 10px; max-width: 150px; border: 1px solid blue; padding: 4px 4px 4px 4px"">
                                        ");
#nullable restore
#line 21 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\ById.cshtml"
                                   Write(msg.MessageText);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 24 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\ById.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div style=""display:block; margin-left:5px; margin-right:auto"">
                                    <div class=""card"" style=""margin-left: 10px; margin-top: 10px; max-width: 150px; border: 1px solid black; padding: 4px 4px 4px 4px"">
                                        ");
#nullable restore
#line 29 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\ById.cshtml"
                                   Write(msg.Account_Nickname);

#line default
#line hidden
#nullable disable
            WriteLiteral(": ");
#nullable restore
#line 29 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\ById.cshtml"
                                                          Write(msg.MessageText);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 32 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\ById.cshtml"
                            }

                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
                <div class=""card"" style=""min-height:50px; margin-top:5px"">
                    <div class=""row"">
                        <div class=""col-lg-9"">
                            <textarea id=""txtMessage"" class=""form-control"" rows=""2"" cols=""30"" placeholder=""Type your message""></textarea>
                        </div>
                        <div class=""col-lg-3"">
                            <button class=""btn btn-primary""");
            BeginWriteAttribute("onclick", " onclick=\"", 2366, "\"", 2439, 5);
            WriteAttributeValue("", 2376, "sendBtnHit(\'", 2376, 12, true);
#nullable restore
#line 43 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\ById.cshtml"
WriteAttributeValue("", 2388, Model.Id, 2388, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2397, "\',\'", 2397, 3, true);
#nullable restore
#line 43 "C:\Users\ALEXBIR\source\repos\SimpleMessenger\SimpleMessenger\Views\Chat\ById.cshtml"
WriteAttributeValue("", 2400, User.FindFirstValue(ClaimTypes.Name), 2400, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2437, "\')", 2437, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                Send\r\n                            </button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SimpleMessenger.Shared.Chat> Html { get; private set; }
    }
}
#pragma warning restore 1591