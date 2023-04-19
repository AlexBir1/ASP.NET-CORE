#pragma checksum "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\GetAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd894d39bd3ab9e93722df5c8b41ef821ee8276b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Journal_GetAll), @"mvc.1.0.view", @"/Views/Journal/GetAll.cshtml")]
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
#line 1 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\_ViewImports.cshtml"
using WebSchoolMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\_ViewImports.cshtml"
using WebSchoolMVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\_ViewImports.cshtml"
using WebSchoolMVC.Domain.Enum;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd894d39bd3ab9e93722df5c8b41ef821ee8276b", @"/Views/Journal/GetAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cccb6c69b932f1f523bcd9c847b5f621de8e2f5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Journal_GetAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WebSchoolMVC.Domain.Entity.Journal>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetById", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<div id=""mainDiv"">
    <div class=""text-lg-center fs-1"" style=""margin-bottom:70px"">
        Journal page 
    </div>
    <div class=""row bg-secondary"" style=""max-height:500px; justify-content:center; overflow-y:scroll; background-color: rgb(230, 230, 230)"">
");
#nullable restore
#line 8 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\GetAll.cshtml"
         foreach (var x in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("id", " id=\"", 376, "\"", 391, 2);
            WriteAttributeValue("", 381, "Note_", 381, 5, true);
#nullable restore
#line 10 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\GetAll.cshtml"
WriteAttributeValue("", 386, x.Id, 386, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"col-lg-4\" style=\"margin-bottom:15px\">\r\n                <div class=\"card\">\r\n                    <div class=\"card-header\">\r\n                        <label class=\"card-title fs-3\">\r\n                            Note №");
#nullable restore
#line 14 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\GetAll.cshtml"
                             Write(x.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </label>\r\n                    </div>\r\n                    <div class=\"card-body\">\r\n                        <div class=\"card-group\">\r\n                            Mark: ");
#nullable restore
#line 19 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\GetAll.cshtml"
                             Write(x.Mark);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"card-group\">\r\n                            Marking date: ");
#nullable restore
#line 22 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\GetAll.cshtml"
                                     Write(x.MarkingDate.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"card-group\">\r\n                            Student: ");
#nullable restore
#line 25 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\GetAll.cshtml"
                                Write(x.Student.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"card-group\">\r\n                            Subject: ");
#nullable restore
#line 28 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\GetAll.cshtml"
                                Write(x.Subject.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"card-footer\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd894d39bd3ab9e93722df5c8b41ef821ee8276b7171", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\GetAll.cshtml"
                                                                          WriteLiteral(x.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 36 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\GetAll.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WebSchoolMVC.Domain.Entity.Journal>> Html { get; private set; }
    }
}
#pragma warning restore 1591
