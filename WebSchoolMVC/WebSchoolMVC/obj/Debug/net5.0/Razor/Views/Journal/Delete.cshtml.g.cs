#pragma checksum "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3cbf5385bf6eb0776583a3d62a0695805b6a6d75"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Journal_Delete), @"mvc.1.0.view", @"/Views/Journal/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cbf5385bf6eb0776583a3d62a0695805b6a6d75", @"/Views/Journal/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cccb6c69b932f1f523bcd9c847b5f621de8e2f5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Journal_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebSchoolMVC.Domain.Entity.Journal>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("NoteData"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Journal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"modal fade\" id=\"DeleteNote\">\r\n    <div class=\"modal-dialog\">\r\n        <div class=\"modal-content\">\r\n            <div class=\"modal-header\">\r\n                <h5 class=\"modal-title\">Delete note (NID: ");
#nullable restore
#line 7 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\Delete.cshtml"
                                                     Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h5>
                <button type=""button"" class=""btn-close"" onclick=""closePartialClick(this)"" aria-label=""Close"">
                    <span area-hidden=""true""></span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3cbf5385bf6eb0776583a3d62a0695805b6a6d755917", async() => {
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3cbf5385bf6eb0776583a3d62a0695805b6a6d756195", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 14 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 14 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\Delete.cshtml"
                                                 WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    <div class=""form-group"">
                        <div class=""card border-primary"">
                            <div class=""card-header text-center fs-4"">
                                <label class=""card-title"">
                                    Student`s info
                                </label>
                            </div>
                            <div class=""card-body"">
                                <p class=""card-text"">SID: ");
#nullable restore
#line 23 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\Delete.cshtml"
                                                     Write(Model.Student.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"card-text\">Fullname: ");
#nullable restore
#line 24 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\Delete.cshtml"
                                                          Write(Model.Student.Fullname);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                            </div>
                        </div>
                    </div>
                    <div class=""form-group"">
                        <div class=""card-header text-center fs-4"">
                                <label class=""card-title"">
                                    Subject`s info
                                </label>
                            </div>
                        <div class=""card border-primary"">
                            <div class=""card-body"">
                                <p class=""card-text"">SID: ");
#nullable restore
#line 36 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\Delete.cshtml"
                                                     Write(Model.Subject.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"card-text\">Title: ");
#nullable restore
#line 37 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\Delete.cshtml"
                                                       Write(Model.Subject.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                            </div>
                        </div>
                    </div>
                    <div class=""form-group"">
                        <div class=""card-header text-center fs-4"">
                                <label class=""card-title"">
                                    Note`s info
                                </label>
                            </div>
                        <div class=""card border-primary"">
                            <div class=""card-body"">
                                <p class=""card-text"">Mark: ");
#nullable restore
#line 49 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\Delete.cshtml"
                                                      Write(Model.Mark);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"card-text\">Marking date: ");
#nullable restore
#line 50 "C:\Users\ALEXBIR\source\repos\WebSchoolMVC\WebSchoolMVC\Views\Journal\Delete.cshtml"
                                                              Write(Model.MarkingDate.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"" style=""justify-content:center"">
                <button onclick=""removeClick(this)"" type=""button"" class=""btn btn-danger""><i class=""bi bi-cassette""></i> Proceed</button>
                <button onclick=""closePartialClick(this)"" type=""button"" class=""btn btn-success""><i class=""bi bi-x-circle""></i> Discard</button>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebSchoolMVC.Domain.Entity.Journal> Html { get; private set; }
    }
}
#pragma warning restore 1591
