#pragma checksum "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\ProductCategory\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87ade20246259d76a245b680fe19dee0c6007c5e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiseHost.Pages.Shared.Components.ProductCategory.Pages_Shared_Components_ProductCategory_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/ProductCategory/Default.cshtml")]
namespace ServiseHost.Pages.Shared.Components.ProductCategory
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
#line 1 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\_ViewImports.cshtml"
using ServiseHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87ade20246259d76a245b680fe19dee0c6007c5e", @"/Pages/Shared/Components/ProductCategory/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ab3186a834ddf082204c2c210e065a1976df3fe", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_ProductCategory_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_01_LampshadeQuery.Contract.ProductCategory.ProductCategoryQueryModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<!--====================  category area ====================-->
<div class=""category-area section-space"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""category-wrapper"">
                    <div class=""row row-10 masonry-category-layout"">

");
#nullable restore
#line 10 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\ProductCategory\Default.cshtml"
                         foreach (var item in Model)
                        {



#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""col-lg-4 col-sm-6 grid-item"">
                                <div class=""single-category-item"">
                                    <div class=""single-category-item__image"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "87ade20246259d76a245b680fe19dee0c6007c5e4448", async() => {
                WriteLiteral("\r\n                                            <img");
                BeginWriteAttribute("src", " src=\"", 829, "\"", 848, 1);
#nullable restore
#line 18 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\ProductCategory\Default.cshtml"
WriteAttributeValue("", 835, item.Picture, 835, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-fluid\"");
                BeginWriteAttribute("alt", " alt=\"", 867, "\"", 889, 1);
#nullable restore
#line 18 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\ProductCategory\Default.cshtml"
WriteAttributeValue("", 873, item.PictureAlt, 873, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("title", " title=\"", 890, "\"", 916, 1);
#nullable restore
#line 18 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\ProductCategory\Default.cshtml"
WriteAttributeValue("", 898, item.PictureTitle, 898, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        ");
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
            WriteLiteral("\r\n                                    </div>\r\n                                    <div class=\"single-category-item__content\">\r\n                                        <h3 class=\"title\">");
#nullable restore
#line 22 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\ProductCategory\Default.cshtml"
                                                     Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                        <a href=""shop-left-sidebar.html"">
                                            <i class=""ion-android-arrow-dropleft-circle""></i> خرید
                                        </a>
                                    </div>
                                </div>
                            </div>
");
#nullable restore
#line 29 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\ProductCategory\Default.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!--====================  End of category area  ====================-->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_01_LampshadeQuery.Contract.ProductCategory.ProductCategoryQueryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
