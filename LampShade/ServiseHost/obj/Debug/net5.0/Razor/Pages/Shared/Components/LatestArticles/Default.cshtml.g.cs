#pragma checksum "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\LatestArticles\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ca09578034f19b29cdff65d67195c0b507f8f2e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiseHost.Pages.Shared.Components.LatestArticles.Pages_Shared_Components_LatestArticles_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/LatestArticles/Default.cshtml")]
namespace ServiseHost.Pages.Shared.Components.LatestArticles
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ca09578034f19b29cdff65d67195c0b507f8f2e", @"/Pages/Shared/Components/LatestArticles/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32b31e4953312edff885fdeee05233f992f4e845", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_LatestArticles_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_01_LampshadeQuery.Contract.Article.ArticleQueryeModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ArticleDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("blog-post-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"{

<div class=""blog-post-slider-area"">
    <div class=""container"">

        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  blog post slider border wrapper  =======-->
                <div class=""blog-post-slider-border-wrapper section-space--inner"">
                    <div class=""row"">
                        <div class=""col-lg-12"">
                            <!--=======  section title  =======-->
                            <div class=""section-title-wrapper text-center section-space--half"">
                                <h2 class=""section-title"">آخرین بلاگ ها</h2>
                                <p class=""section-subtitle"">
                                    Mirum est notare quam littera gothica, quam nunc putamus
                                    parum claram anteposuerit litterarum formas.
                                </p>
                            </div>
                            <!--=======  End of section title  =======-->
                        </div>
");
            WriteLiteral(@"                        <div class=""col-lg-12"">
                            <!--=======  blog post slider wrapper  =======-->
                            <div class=""blog-post-slider-wrapper"">
                                <div class=""ht-slick-slider"" data-slick-setting='{
                                    ""slidesToShow"": 3,
                                    ""slidesToScroll"": 1,
                                    ""arrows"": false,
                                    ""autoplay"": true,
                                    ""autoplaySpeed"": 1000,
                                    ""speed"": 1000,
                                    ""infinite"": true,
                                    ""rtl"": true
                                }' data-slick-responsive='[
                                    {""breakpoint"":1501, ""settings"": {""slidesToShow"": 3} },
                                    {""breakpoint"":1199, ""settings"": {""slidesToShow"": 3} },
                                    {""breakpoint"":991, ""settings"": {""slides");
            WriteLiteral(@"ToShow"": 2} },
                                    {""breakpoint"":767, ""settings"": {""slidesToShow"": 1} },
                                    {""breakpoint"":575, ""settings"": {""slidesToShow"": 1} },
                                    {""breakpoint"":479, ""settings"": {""slidesToShow"": 1} }
                                ]'>



");
#nullable restore
#line 49 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\LatestArticles\Default.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div class=""col"">
                                            <!--=======  single slider post  =======-->
                                            <div class=""single-slider-post"">
                                                <div class=""single-slider-post__image"">
                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ca09578034f19b29cdff65d67195c0b507f8f2e7389", async() => {
                WriteLiteral("\n                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6ca09578034f19b29cdff65d67195c0b507f8f2e7698", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3148, "~/ProductPicture/", 3148, 17, true);
#nullable restore
#line 56 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\LatestArticles\Default.cshtml"
AddHtmlAttributeValue("", 3165, item.Picture, 3165, 13, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 57 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\LatestArticles\Default.cshtml"
AddHtmlAttributeValue("", 3264, item.PictureAlt, 3264, 16, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 57 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\LatestArticles\Default.cshtml"
AddHtmlAttributeValue("", 3289, item.PictureTitle, 3289, 18, false);

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
                WriteLiteral("\n                                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\LatestArticles\Default.cshtml"
                                                                                    WriteLiteral(item.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                                    <div class=\"single-slider-post__date-sticker\">\n                                                        <span class=\"month\">");
#nullable restore
#line 60 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\LatestArticles\Default.cshtml"
                                                                       Write(item.PublishDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                                    </div>
                                                </div>
                                                <div class=""single-slider-post__content"">
                                                    <h3 class=""title"">
                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ca09578034f19b29cdff65d67195c0b507f8f2e13319", async() => {
                WriteLiteral("\n                                                          ");
#nullable restore
#line 66 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\LatestArticles\Default.cshtml"
                                                     Write(item.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\LatestArticles\Default.cshtml"
                                                                                        WriteLiteral(item.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                                    </h3>\n");
            WriteLiteral("                                                    <p class=\"short-desc\">\n                                                       ");
#nullable restore
#line 71 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\LatestArticles\Default.cshtml"
                                                  Write(item.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                                    </p>\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ca09578034f19b29cdff65d67195c0b507f8f2e16646", async() => {
                WriteLiteral("\n                                                        ادامه مطلب\n                                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\LatestArticles\Default.cshtml"
                                                                                    WriteLiteral(item.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                                </div>\n                                            </div>\n                                        </div>\n");
#nullable restore
#line 79 "C:\Users\hp\Desktop\c#\asp\پروژه\FinalProject\Code\LampShade\ServiseHost\Pages\Shared\Components\LatestArticles\Default.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </div>\n                            </div>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_01_LampshadeQuery.Contract.Article.ArticleQueryeModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
