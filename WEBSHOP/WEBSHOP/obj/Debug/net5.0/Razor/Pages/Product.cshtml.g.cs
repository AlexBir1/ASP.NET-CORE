#pragma checksum "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6952023eb8cdc457cef9623cb894848f140ddb9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WEBSHOP.Pages.Pages_Product), @"mvc.1.0.razor-page", @"/Pages/Product.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6952023eb8cdc457cef9623cb894848f140ddb9", @"/Pages/Product.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9d5a70938a8685575bf3ce4407bc1d1773a0dc0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Product : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Imgs/1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("300"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("300"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Bin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div id=\"MainDiv\">\r\n    <div class=\"text-center\">\r\n        <label id=\"MainLabel\" class=\"font-weight-normal fs-1\">\r\n            Product`s catalog\r\n");
#nullable restore
#line 10 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
             if (User.IsInRole(UserStatus.Admin.ToString()))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <i class=\"bi bi-plus-circle link-success\" data-createpartial=\"");
#nullable restore
#line 12 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                                                                         Write(Url.PageLink("/Product","DataToCreatePartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></i>\r\n");
#nullable restore
#line 13 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </label>\r\n    </div>\r\n    <br />\r\n    <br />\r\n\r\n    <div id=\"prodList\" class=\"row\" style=\"justify-content:center\">\r\n");
#nullable restore
#line 20 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
         foreach (var prod in Model.ProductList)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("id", " id=\"", 623, "\"", 647, 2);
            WriteAttributeValue("", 628, "ProdToSell_", 628, 11, true);
#nullable restore
#line 22 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
WriteAttributeValue("", 639, prod.Id, 639, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"col-lg-4\" style=\"height:600px\">\r\n                <div class=\"card\">\r\n                    <div class=\"card-header text-center\">\r\n                        <label class=\"card-title fs-3\">");
#nullable restore
#line 25 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                                                  Write(prod.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    </div>\r\n                    <div class=\"card-img text-center\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e6952023eb8cdc457cef9623cb894848f140ddb99852", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                    <div class=""card-body"">
                        <div class=""col"">
                            <div class=""row"">
                                <div class=""col text-center"">
                                    <label class=""card-text"">Cost:</label>
                                    <label class=""card-text"">");
#nullable restore
#line 35 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                                                        Write(prod.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                                </div>
                            </div>
                            <div class=""row text-center"">
                                <div class=""col"">
                                    <label class=""card-text"">Quantity:</label>
                                    <label class=""card-text"">");
#nullable restore
#line 41 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                                                        Write(prod.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""card-footer"">
                        <div class=""row text-center"" style=""justify-content:center"">
                            <div class=""col"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6952023eb8cdc457cef9623cb894848f140ddb912647", async() => {
                WriteLiteral("\r\n                                    <button type=\"submit\" class=\"btn btn-outline-success\"><i class=\"bi bi-box-arrow-in-up-right\"></i> To cart</button>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Page = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-prod_id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                                                                                                     WriteLiteral(prod.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["prod_id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-prod_id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["prod_id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n");
#nullable restore
#line 53 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                             if (User.IsInRole("Admin") || User.IsInRole("Employee"))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col\">\r\n                                    <button type=\"button\"");
            BeginWriteAttribute("id", " id=\"", 2651, "\"", 2679, 2);
            WriteAttributeValue("", 2656, "AddToOrderById_", 2656, 15, true);
#nullable restore
#line 56 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
WriteAttributeValue("", 2671, prod.Id, 2671, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-secondary\" data-productid=\"");
#nullable restore
#line 56 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                                                                                                                                    Write(prod.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-url=\"");
#nullable restore
#line 56 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                                                                                                                                                        Write(Url.Page("Orders","ShowOrders"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">To order</button>\r\n                                </div>\r\n");
#nullable restore
#line 58 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                             if (User.IsInRole("Admin"))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col\">\r\n                                    <button type=\"button\" class=\"btn btn-outline-warning\" data-url=\"");
#nullable restore
#line 62 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                                                                                               Write(Url.Page("Product","DataToEditPartial",new ProductViewModel
                        {
                            Id = prod.Id,
                            Title = prod.Title,
                            Cost = prod.Cost,
                            Quantity = prod.Quantity,
                            ProductManufactorer = prod.ProductManufactorer,
                            ProductUnit = prod.ProductUnit,
                            ProductType = prod.ProductType
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                                        <i class=""bi bi-pencil-square""></i> Edit
                                    </button>
                                </div>
                                <div class=""col"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6952023eb8cdc457cef9623cb894848f140ddb919095", async() => {
                WriteLiteral("\r\n                                        <i class=\"bi bi-trash3\"></i> Delete\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Page = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                                                                                                                                        WriteLiteral(prod.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            WriteLiteral("/Product?Id=");
#nullable restore
#line 77 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                                                             Write(prod.Id);

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
#line 81 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 86 "C:\Users\ALEXBIR\source\repos\WEBSHOP\WEBSHOP\Pages\Product.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>
        $(document).on('click', 'button[id *= ""AddToOrderById_""]',function(e){
            var productId = $(this).data('productid');
            var partialLink = $(this).data('url');
            var orderId = '0';
            var actionUrl = '0';
            $('#MainDiv').append('<div id=""ModalHere""></div>');
            var ModalElement = $('#ModalHere');
            $.get(partialLink).done(function (data) {
                ModalElement.html(data);
                ModalElement.find('.modal').modal('show');
            })

            ModalElement.on('click','button[data-bs-dismiss *= ""modal""]',function(e){
                ModalElement.find('.modal').modal('hide');
                ModalElement.html(null);
                ModalElement.remove();
            })

            ModalElement.on('click','button[id *= ""SelectOrder_""]',function(e){
                orderId = $(this).data('orderid');
                actionUrl = `/Orders?OrderId=${orderId}&ProductId=${productId}&handler=Ad");
                WriteLiteral(@"dProductInOrder`;
                $.get(actionUrl).done(function(e){
                    ModalElement.find('.modal').modal('hide');
                    ModalElement.html(null);
                    ModalElement.remove();
                })
            })
        })

            $(document).on('click','.btn-outline-warning',function (e) {
            $('#MainDiv').append('<div id=""ModalHere""></div>');
            var ModalEditElement = $('#ModalHere');
            var url = $(this).data('url');
            $.get(url).done(function (data) {
                ModalEditElement.html(data);
                ModalEditElement.find('.modal').modal('show');
            })


        $(document).on('click','button[data-bs-dismiss *= ""modal""]',function(e){
                ModalEditElement.find('.modal').modal('hide');
                ModalEditElement.html(null);
                ModalEditElement.remove();
            })

        ModalEditElement.on('click','#SaveBtn', function(e) {
            var act");
                WriteLiteral(@"ionUrl = ModalEditElement.find('#ProdEditForm').attr('action');
            var data = ModalEditElement.find('#ProdEditForm').serialize();
            ModalEditElement.off('click', '#SaveBtn');
            $.ajax({
                type: 'post',
                url: actionUrl,
                data: data,
            }).done(function(e){
                        var newBody = $('.modal-body', e);
                    ModalEditElement.find('.modal-body').replaceWith(newBody);
                    var isValid = newBody.find('[name=""IsValid""]').val() == 'True';
                    if (isValid) {
                        $.get('/Product').done(function(e){
                            var newbody = $('#typeList', e);
                            $(document).find('#typeList').replaceWith(newbody);
                            ModalEditElement.find('.modal').modal('hide');
                            $('#MainDiv').find('#ModalHere').remove();
                        })
                    }
              ");
                WriteLiteral(@"      })
              })
        })
        $(document).on('click', '.bi-plus-circle', function (e) {
        $('#MainDiv').append('<div id=""ModalHere""></div>');
        var ModalCreateElement = $('#ModalHere');
        var url = $(this).data('createpartial');
        $.get(url).done(function (data) {
            ModalCreateElement.html(data);
            ModalCreateElement.find('.modal').modal('show');
        })
        ModalCreateElement.on('click', '#CancelBtn', function (e) {
            ModalCreateElement.find('.modal').modal('hide');
            $('#MainDiv').find('#ModalHere').remove();
        });

        ModalCreateElement.on('click', '#CreateBtn', function (e) {
            var dataToSend = ModalCreateElement.find('#ProdCreateForm').serialize();
            var crtUrl = ModalCreateElement.find('#ProdCreateForm').attr('action');
            $.ajax({
                type: ""POST"",
                url: crtUrl,
                data: dataToSend
            }).done(function (e) {
                WriteLiteral(@"
                var newBody = $('.modal-body', e);
                ModalCreateElement.find('.modal-body').replaceWith(newBody);
                var isValid = newBody.find('[name=""IsValid""]').val() == 'True';
                if (isValid) {
                    $.get('Product').done(function (e) {
                        var newbody = $('#prodList', e);
                        $(document).find('#prodList').replaceWith(newbody);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEBSHOP.Pages.ProductModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WEBSHOP.Pages.ProductModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WEBSHOP.Pages.ProductModel>)PageContext?.ViewData;
        public WEBSHOP.Pages.ProductModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591