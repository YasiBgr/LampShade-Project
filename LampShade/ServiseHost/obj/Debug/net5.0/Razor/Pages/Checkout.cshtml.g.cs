#pragma checksum "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "011a1a556dd47869a771a2178430955c21480e6d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiseHost.Pages.Pages_Checkout), @"mvc.1.0.razor-page", @"/Pages/Checkout.cshtml")]
namespace ServiseHost.Pages
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
#line 2 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
using _0_FramBase.Application;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
using ShopManagmentAplication.Contracts;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"011a1a556dd47869a771a2178430955c21480e6d", @"/Pages/Checkout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32b31e4953312edff885fdeee05233f992f4e845", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Checkout : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Pay", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("checkout-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""breadcrumb-area section-space--half"">
    <div class=""container wide"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""breadcrumb-wrapper breadcrumb-bg"">
                    <div class=""breadcrumb-content"">
                        <h2 class=""breadcrumb-content__title"">تایید سبد خرید / پرداخت</h2>
                        <ul class=""breadcrumb-content__page-map"">
                            <li>
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "011a1a556dd47869a771a2178430955c21480e6d5862", async() => {
                WriteLiteral("صفحه اصلی");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </li>
                            <li class=""active"">تایید سبد خرید / پرداخت</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""page-content-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""page-wrapper"">
                    <div class=""page-content-wrapper"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "011a1a556dd47869a771a2178430955c21480e6d7534", async() => {
                WriteLiteral(@"
                            <div class=""cart-table table-responsive"">
                                <table class=""table"">
                                    <thead>
                                        <tr>
                                            <th class=""pro-thumbnail"">عکس</th>
                                            <th class=""pro-thumbnail"">محصول</th>
                                            <th class=""pro-title"">قیمت واحد</th>
                                            <th class=""pro-price"">تعداد</th>
                                            <th class=""pro-quantity"">مبلغ کل بدون تخفیف</th>
                                            <th class=""pro-subtotal"">درصد تخفیف</th>
                                            <th class=""pro-subtotal"">مبلغ کل تخفیف</th>
                                            <th class=""pro-remove"">مبلغ پس از تخفیف</th>
                                        </tr>
                                    </thead>
                               ");
                WriteLiteral("     <tbody>\r\n");
#nullable restore
#line 51 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                         foreach (var item in Model.Cart.Items)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <tr>\r\n                                                <td class=\"pro-thumbnail\">\r\n                                                    <a>\r\n                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "011a1a556dd47869a771a2178430955c21480e6d9466", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2595, "~/ProductPictures/", 2595, 18, true);
#nullable restore
#line 56 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
AddHtmlAttributeValue("", 2613, item.Picture, 2613, 13, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 57 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
AddHtmlAttributeValue("", 2713, item.Name, 2713, 10, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                    </a>\r\n                                                </td>\r\n                                                <td class=\"pro-title\">\r\n                                                    <a>");
#nullable restore
#line 61 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                                                </td>\r\n                                                <td class=\"pro-price\">\r\n                                                    <span>");
#nullable restore
#line 64 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                     Write(item.UnitPrice.ToMoney());

#line default
#line hidden
#nullable disable
                WriteLiteral(" تومان</span>\r\n                                                </td>\r\n                                                <td class=\"pro-price\">\r\n                                                    <span>");
#nullable restore
#line 67 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                     Write(item.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral(" عدد</span>\r\n                                                </td>\r\n                                                <td class=\"pro-subtotal\">\r\n                                                    <span>");
#nullable restore
#line 70 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                     Write(item.TotalItemPrice.ToMoney());

#line default
#line hidden
#nullable disable
                WriteLiteral(" تومان</span>\r\n                                                </td>\r\n                                                <td class=\"pro-subtotal\">\r\n                                                    <span>");
#nullable restore
#line 73 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                     Write(item.DiscountRate);

#line default
#line hidden
#nullable disable
                WriteLiteral(" %</span>\r\n                                                </td>\r\n                                                <td class=\"pro-subtotal\">\r\n                                                    <span>");
#nullable restore
#line 76 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                     Write(item.DiscountAmount.ToMoney());

#line default
#line hidden
#nullable disable
                WriteLiteral(" تومان</span>\r\n                                                </td>\r\n                                                <td class=\"pro-subtotal\">\r\n                                                    <span>");
#nullable restore
#line 79 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                     Write(item.ItemPayAmount.ToMoney());

#line default
#line hidden
#nullable disable
                WriteLiteral(" تومان</span>\r\n                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 82 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>

                            <div class=""row"">
                                <div class=""col-lg-6 col-12 d-flex"">
                                    <div class=""checkout-payment-method"">
                                        <h4>نحوه پرداخت</h4>
");
#nullable restore
#line 91 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                         foreach (var method in PaymentMethod.GetList())
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div class=\"single-method\">\r\n                                                <input type=\"radio\"");
                BeginWriteAttribute("id", " id=\"", 5134, "\"", 5157, 2);
                WriteAttributeValue("", 5139, "payment_", 5139, 8, true);
#nullable restore
#line 94 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
WriteAttributeValue("", 5147, method.Id, 5147, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"paymentMethod\"");
                BeginWriteAttribute("value", " \r\n                                                 value=\"", 5179, "\"", 5248, 1);
#nullable restore
#line 95 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
WriteAttributeValue("", 5238, method.Id, 5238, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" ");
#nullable restore
#line 95 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                                Write(PaymentMethod.GetList().First().Id == method.Id ? "checked" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                                                <label");
                BeginWriteAttribute("for", " for=\"", 5374, "\"", 5398, 2);
                WriteAttributeValue("", 5380, "payment_", 5380, 8, true);
#nullable restore
#line 96 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
WriteAttributeValue("", 5388, method.Id, 5388, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 96 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                                           Write(method.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                                <p data-method=\"");
#nullable restore
#line 97 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                           Write(method.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"");
                BeginWriteAttribute("style", " style=\"", 5497, "\"", 5632, 2);
                WriteAttributeValue("", 5505, "display:", 5505, 8, true);
#nullable restore
#line 97 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
WriteAttributeValue("", 5513, PaymentMethod.GetList()
                                                .First().Id == method.Id ? "block" : "none", 5513, 119, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 98 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                                                         Write(method.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                            </div>\r\n");
#nullable restore
#line 100 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    </div>
                                </div>
                                <div class=""col-lg-6 col-12 d-flex"">
                                    <div class=""cart-summary"">
                                        <div class=""cart-summary-wrap"">
                                            <h4>خلاصه وضعیت فاکتور</h4>
                                            <p>مبلغ نهایی <span>");
#nullable restore
#line 107 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                           Write(Model.Cart.TotalAmount.ToMoney());

#line default
#line hidden
#nullable disable
                WriteLiteral(" تومان</span></p>\r\n                                            <p>مبلغ تخفیف <span>");
#nullable restore
#line 108 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                           Write(Model.Cart.DiscountAmount.ToMoney());

#line default
#line hidden
#nullable disable
                WriteLiteral(" تومان</span></p>\r\n                                            <h2>مبلغ قابل پرداخت <span>");
#nullable restore
#line 109 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Checkout.cshtml"
                                                                  Write(Model.Cart.PayAmount.ToMoney());

#line default
#line hidden
#nullable disable
                WriteLiteral(" تومان</span></h2>\r\n                                        </div>\r\n                                        <div class=\"cart-summary-button\">\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "011a1a556dd47869a771a2178430955c21480e6d21860", async() => {
                    WriteLiteral("پرداخت");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiseHost.Pages.CheckoutModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiseHost.Pages.CheckoutModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiseHost.Pages.CheckoutModel>)PageContext?.ViewData;
        public ServiseHost.Pages.CheckoutModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
