#pragma checksum "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\PaymentMethod.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80c580c6d1114c07318a5164084ff6482f930ad6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WEBSHOP.Pages.Pages_PaymentMethod), @"mvc.1.0.razor-page", @"/Pages/PaymentMethod.cshtml")]
namespace WEBSHOP.Pages
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
#line 2 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\_ViewImports.cshtml"
using WEBSHOP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\_ViewImports.cshtml"
using WEBSHOP.Domain;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\_ViewImports.cshtml"
using WEBSHOP.Domain.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\_ViewImports.cshtml"
using WEBSHOP.Domain.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\_ViewImports.cshtml"
using WEBSHOP.Domain.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80c580c6d1114c07318a5164084ff6482f930ad6", @"/Pages/PaymentMethod.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9d5a70938a8685575bf3ce4407bc1d1773a0dc0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_PaymentMethod : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/PaymentMethod", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div id=\"MainDiv\">\r\n<div class=\"text-center\">\r\n        <label id=\"MainLabel\" class=\"font-weight-normal fs-1\">\r\n            Payment methods <i class=\"bi bi-plus-circle link-success\" data-createpartial=\"");
#nullable restore
#line 9 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\PaymentMethod.cshtml"
                                                                                     Write(Url.Page("PaymentMethod","ToCreate"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></i>\r\n        </label>\r\n    </div>\r\n    <br />\r\n    <br />\r\n    <div id=\"pmList\" class=\"row\" style=\"justify-content:center\">\r\n");
#nullable restore
#line 15 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\PaymentMethod.cshtml"
         foreach (var item in Model.paymentMethodsList)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-4\">\r\n                <div class=\"card\">\r\n                    <div class=\"card-header\">\r\n                        <label class=\"card-text fs-3\">\r\n                            Payment method №");
#nullable restore
#line 21 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\PaymentMethod.cshtml"
                                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </label>\r\n                    </div>\r\n                    <div class=\"card-body\">\r\n                        <div class=\"card-group\">\r\n                            Number: ");
#nullable restore
#line 26 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\PaymentMethod.cshtml"
                               Write(item.CardNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"card-group\">\r\n                            Will expire: ");
#nullable restore
#line 29 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\PaymentMethod.cshtml"
                                    Write(item.CardExpirationMonth);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 29 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\PaymentMethod.cshtml"
                                                              Write(item.CardExpirationYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"card-group\">\r\n                            CVV code: ");
#nullable restore
#line 32 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\PaymentMethod.cshtml"
                                 Write(item.CardCVV);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"card-footer\">\r\n                        <div class=\"row\">\r\n                            <div class=\"col\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80c580c6d1114c07318a5164084ff6482f930ad67913", async() => {
                WriteLiteral("\r\n                                        <i class=\"bi bi-trash3\"></i> Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\PaymentMethod.cshtml"
                                                                                                                             WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            WriteLiteral("/PaymentMethod?Id=");
#nullable restore
#line 39 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\PaymentMethod.cshtml"
                                                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("&handler=ToDelete");
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-delConfPart", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 46 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\PaymentMethod.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).on('click', '.bi-plus-circle', function (e) {
        $('#MainDiv').append('<div id=""ModalHere""></div>');
        var ModalCreateElement = $('#ModalHere');
        var url = $(this).data('createpartial');
        $.get(url).done(function (data) {
            ModalCreateElement.html(data);
            ModalCreateElement.find('.modal').modal('show');
        })

        ModalCreateElement.on('click', 'button[data-bs-dismiss *= ""modal""]', function (e) {
            ModalCreateElement.find('.modal').modal('hide');
            $('#MainDiv').find('#ModalHere').remove();
        });

        ModalCreateElement.on('click', '#CreateBtn', function (e) {
            var dataToSend = ModalCreateElement.find('#PMCreateForm').serialize();
            var crtUrl = ModalCreateElement.find('#PMCreateForm').attr('action');
            $.ajax({
                type: ""POST"",
                url: crtUrl,
                data: dataToSend
            }).done(function (e) {
 ");
                WriteLiteral(@"               var newBody = $('.modal-body', e);
                ModalCreateElement.find('.modal-body').replaceWith(newBody);
                var isValid = newBody.find('[name=""IsValid""]').val() == 'True';
                if (isValid) {
                    $.get('PaymentMethod').done(function (e) {
                        var newbody = $('#pmList', e);
                        $(document).find('#pmList').replaceWith(newbody);
                        ModalCreateElement.find('.modal').modal('hide');
                        $('#ModalHere').remove();
                    })
                }
            })
        })
    })
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEBSHOP.Pages.PaymentMethodModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WEBSHOP.Pages.PaymentMethodModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WEBSHOP.Pages.PaymentMethodModel>)PageContext?.ViewData;
        public WEBSHOP.Pages.PaymentMethodModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
