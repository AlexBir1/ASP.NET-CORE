#pragma checksum "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ba5bdd88927d5af14e792053de2040849e6d2eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WEBSHOP.Pages.Pages_Orders), @"mvc.1.0.razor-page", @"/Pages/Orders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ba5bdd88927d5af14e792053de2040849e6d2eb", @"/Pages/Orders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9d5a70938a8685575bf3ce4407bc1d1773a0dc0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Orders : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "ShowOrderProdList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Orders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "ToStatusEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Orders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n<div id=\"MainDiv\">\r\n<div class=\"text-center\">\r\n    <label class=\"form-text fs-1\">Orders</label>\r\n</div>\r\n    <div id=\"orderList\" class=\"row\" style=\"justify-content:center; overflow-y:scroll; height:700px\">\r\n");
#nullable restore
#line 10 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
         foreach(var item in Model.orders)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-4\" style=\"height:330px\">\r\n                <div");
            BeginWriteAttribute("id", " id=\"", 384, "\"", 397, 1);
#nullable restore
#line 13 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
WriteAttributeValue("", 389, item.Id, 389, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card\">\r\n                    <div class=\"card-header\">\r\n                        <label class=\"card-title\">Order №");
#nullable restore
#line 15 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
                                                    Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    </div>\r\n                    <div class=\"card-body\">\r\n                        <div class=\"card-group\">\r\n                            <label class=\"card-text\">Cost: ");
#nullable restore
#line 19 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
                                                      Write(item.FullCost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                        </div>\r\n                        <div class=\"card-group\">\r\n                            <label class=\"card-text\">Status: ");
#nullable restore
#line 22 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
                                                        Write(item.Status.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"card-body\">\r\n                        <div class=\"card-group\">\r\n                            <label class=\"card-text text-dark\">Created by: ");
#nullable restore
#line 27 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
                                                                      Write(item.Owner.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                        </div>\r\n                        <div class=\"card-group\">\r\n                            <label class=\"card-text text-dark\">Creator`s phone: ");
#nullable restore
#line 30 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
                                                                           Write(item.Owner.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                        </div>
                    </div>
                    <div class=""card-footer"">
                        <div class=""row"" style=""justify-content:center"">
                            <div class=""col"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ba5bdd88927d5af14e792053de2040849e6d2eb10084", async() => {
                WriteLiteral("<i class=\"bi bi-bag\"></i> Product list");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1639, "ShowOrderProdList_", 1639, 18, true);
#nullable restore
#line 36 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
AddHtmlAttributeValue("", 1657, item.Id, 1657, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-OrderId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
                                                                                                                                                                                  WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["OrderId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-OrderId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["OrderId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n");
#nullable restore
#line 38 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
                             if (User.IsInRole("Admin") || User.IsInRole("Employee"))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ba5bdd88927d5af14e792053de2040849e6d2eb13773", async() => {
                WriteLiteral("<i class=\"bi bi-bag\"></i> Change status");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2097, "StatusChange_", 2097, 13, true);
#nullable restore
#line 41 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
AddHtmlAttributeValue("", 2110, item.Id, 2110, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Page = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
                                                                                                                                                                      WriteLiteral(item.Id);

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
            WriteLiteral("\r\n                                </div>\r\n                                <div class=\"col\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ba5bdd88927d5af14e792053de2040849e6d2eb17134", async() => {
                WriteLiteral("\r\n                                        <i class=\"bi bi-trash3\"></i> Delete\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Page = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 44 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
                                                                                                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            WriteLiteral("/Orders?Id=");
#nullable restore
#line 45 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
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
            WriteLiteral("\r\n                                </div>\r\n");
#nullable restore
#line 49 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 54 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Orders.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).on('click','button[id *= ""ShowOrderProdList_""]',function(){
            $('#MainDiv').append('<div id=""ModalHere""></div>');
            var ModalElement = $('#ModalHere');
            var url = $(this).attr('formaction');
            $.get(url).done(function (data) {
                ModalElement.html(data);
                ModalElement.find('.modal').modal('show');
            })
            ModalElement.on('click', 'button[data-bs-dismiss *= ""modal""]', function(e){
                ModalElement.find('.modal').modal('hide');
                ModalElement.html(null);
                ModalElement.remove();
            })
            ModalElement.on('click', '.btn-danger', function(e){
                var actionUrl = $(this).attr('formaction');
                var orderId = $(this).parents('.col-lg-6').attr('id');
                $.get(actionUrl).done(function(e){
                    $.get(""/Product?OrderId=""+ orderId +""&handler=ShowOrderProdList"").done(function");
                WriteLiteral(@"(e){
                        var newbody = $('#orderProdList', e);
                        $(document).find('#orderProdList').replaceWith(newbody);
                    })
                    })
            })
        })

        $(document).on('click','button[id *= ""StatusChange_""]',function (e) {
        $('#MainDiv').append('<div id=""ModalHere""></div>');
        var ModalCreateElement = $('#ModalHere');
        var url = $(this).attr('formaction');
            $.get(url).done(function (data) {
                ModalCreateElement.html(data);
                ModalCreateElement.find('.modal').modal('show');
            })
        ModalCreateElement.on('click', 'button[data-bs-dismiss *= ""modal""]', function (e) {
            ModalCreateElement.find('.modal').modal('hide');
            $('#MainDiv').find('#ModalHere').remove();
        });

        ModalCreateElement.on('click', '#SaveStatusBtn', function (e) {
            var dataToSend = ModalCreateElement.find('#OrderStatusChangeForm').se");
                WriteLiteral(@"rialize();
            var crtUrl = ModalCreateElement.find('#OrderStatusChangeForm').attr('action');
            $.ajax({
                type: ""POST"",
                url: crtUrl,
                data: dataToSend
            }).done(function (e) {
                    $.get('Orders').done(function (e) {
                        var newbody = $('#orderList', e);
                        $(document).find('#orderList').replaceWith(newbody);
                        ModalCreateElement.find('.modal').modal('hide');
                        $('#ModalHere').remove();

                    })
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEBSHOP.Pages.OrdersModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WEBSHOP.Pages.OrdersModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WEBSHOP.Pages.OrdersModel>)PageContext?.ViewData;
        public WEBSHOP.Pages.OrdersModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591