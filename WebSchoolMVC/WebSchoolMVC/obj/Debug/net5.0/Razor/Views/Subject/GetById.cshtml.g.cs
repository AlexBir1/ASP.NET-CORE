#pragma checksum "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60998241c44b60bcaedcae9a69e5b8c0768892a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Subject_GetById), @"mvc.1.0.view", @"/Views/Subject/GetById.cshtml")]
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
#nullable restore
#line 1 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60998241c44b60bcaedcae9a69e5b8c0768892a3", @"/Views/Subject/GetById.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cccb6c69b932f1f523bcd9c847b5f621de8e2f5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Subject_GetById : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebSchoolMVC.Domain.Entity.Subject>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddTeacher", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveTeacher", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("openPartialClick(this)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("link-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Teacher", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetById", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div id=\"mainDiv\">\r\n    <div class=\"text-lg-center fs-1\" style=\"margin-bottom:60px\">\r\n        Subjects <i id=\"stCreate\" class=\"bi bi-plus-circle link-success\" data-url=\"");
#nullable restore
#line 6 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                                                                              Write(Url.Action("Create","Subject"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" onclick=""openPartialClick(this)"" style=""cursor:pointer""></i>
    </div>
    <div id=""subjectList"" class=""row"" style=""justify-content:center"">
        <div class=""col-lg-7"">
            <div class=""card"">
                <div class=""card-header"" position=""relative"">
                    <div class=""dropdown"" style=""position:absolute; top:20px; right:20px; "">
                        <a class=""btn btn-outline-primary"" data-bs-toggle=""dropdown"" href=""#"" role=""button"" aria-haspopup=""true"" aria-expanded=""false""><i class=""bi bi-list-ul"" style=""font-size:24px""></i></a>
                        <div class=""dropdown-menu"">
");
#nullable restore
#line 15 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                             if (User.IsInRole(UserStatus.Teacher.ToString()) && !Model.Teachers.Any(x => x.Id == int.Parse(User.FindFirst(ClaimTypes.Sid).Value)))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60998241c44b60bcaedcae9a69e5b8c0768892a38141", async() => {
                WriteLiteral("<i class=\"bi bi-person-plus\"></i> Begin teaching");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Subject_Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                                                                                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Subject_Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Subject_Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Subject_Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 17 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                                                                                                                            WriteLiteral(int.Parse(User.FindFirst(ClaimTypes.Sid).Value));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Teacher_Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Teacher_Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Teacher_Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                <div class=\"dropdown-divider\"></div>\r\n");
#nullable restore
#line 19 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                            }
                            else if (User.IsInRole(UserStatus.Teacher.ToString()) && Model.Teachers.Any(x => x.Id == int.Parse(User.FindFirst(ClaimTypes.Sid).Value)))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60998241c44b60bcaedcae9a69e5b8c0768892a311891", async() => {
                WriteLiteral("<i class=\"bi bi-person-dash\"></i> End teaching");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Subject_Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                                                                                              WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Subject_Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Subject_Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Subject_Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                                                                                                                               WriteLiteral(int.Parse(User.FindFirst(ClaimTypes.Sid).Value));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Teacher_Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Teacher_Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Teacher_Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                <div class=\"dropdown-divider\"></div>\r\n");
#nullable restore
#line 24 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60998241c44b60bcaedcae9a69e5b8c0768892a315443", async() => {
                WriteLiteral("<i class=\"bi bi-pencil-square\"></i> Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                                                                                                                 WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60998241c44b60bcaedcae9a69e5b8c0768892a317940", async() => {
                WriteLiteral("<i class=\"bi bi-trash3-fill\"></i> Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                                                                                                                 WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <label class=\"card-title fs-3\">\r\n                        ");
#nullable restore
#line 30 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                   Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </label>\r\n                    <br />\r\n                    <label class=\"card-subtitle\">\r\n                        SUBJECT ID: ");
#nullable restore
#line 34 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                               Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </label>
                </div>
                <div class=""card-body"">
                    <p class=""card-title fs-4"">Teachers</p>
                    <div class=""row"" style=""justify-content:center; overflow-y:scroll; max-height:300px"">
");
#nullable restore
#line 40 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                         foreach (var x in Model.Teachers)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""col-lg-6"" style=""margin-bottom:25px"">
                                <div class=""card"">
                                    <div class=""card-header"">
                                        <label class=""card-title fs-3"" style=""margin-bottom:6px"">
                                            ");
#nullable restore
#line 46 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                                       Write(x.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </label>\r\n                                        <label class=\"card-subtitle\">\r\n                                            TEACHER ID: ");
#nullable restore
#line 49 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                                                   Write(x.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </label>
                                    </div>
                                    <div class=""card-body"">
                                        <div class=""card-group"">
                                            <label class=""card-text"">Phone: ");
#nullable restore
#line 54 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                                                                       Write(x.MobileNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                                        </div>\r\n                                        <div class=\"card-group\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60998241c44b60bcaedcae9a69e5b8c0768892a323581", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
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
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n\r\n                            </div>\r\n");
#nullable restore
#line 63 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Subject\GetById.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n\r\n                </div>\r\n                <div class=\"card-footer\" style=\"display:flex; justify-content: center\">\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebSchoolMVC.Domain.Entity.Subject> Html { get; private set; }
    }
}
#pragma warning restore 1591