#pragma checksum "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Settings\Country\Country.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "467f4d3e031a24e0debf44d05dc970b9a0f08e3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Clean.UI.Pages.Settings.Country.Pages_Settings_Country_Country), @"mvc.1.0.razor-page", @"/Pages/Settings/Country/Country.cshtml")]
namespace Clean.UI.Pages.Settings.Country
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
#line 1 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\_ViewImports.cshtml"
using Clean.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Settings\Country\Country.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{handler?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"467f4d3e031a24e0debf44d05dc970b9a0f08e3c", @"/Pages/Settings/Country/Country.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4e588d119d3749322bd1c215836697b37532af0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Settings_Country_Country : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("dv_Settings_Country_Country"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form main-form page-component"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("prefix", new global::Microsoft.AspNetCore.Html.HtmlString("or"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Settings\Country\Country.cshtml"
  
    ViewData["Title"] = "Country";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Settings\Country\Country.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"panel panel-flat\" >\r\n        <div class=\"panel-heading\">\r\n            <h1 class=\"panel-title\">");
#nullable restore
#line 12 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Settings\Country\Country.cshtml"
                               Write(_localizer["ثبت کشورها"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        </div>\r\n        <div class=\"panel-body\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "467f4d3e031a24e0debf44d05dc970b9a0f08e3c5659", async() => {
                WriteLiteral("\r\n                <fieldset class=\"content-group\">\r\n                    <legend class=\"text-bold\">");
#nullable restore
#line 17 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Settings\Country\Country.cshtml"
                                         Write(_localizer["ثبت و ویرایش کشورها"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</legend>
                    <div class=""col-md-12 "">
                        <div class=""row"">
                            <div class=""col-md-4 "">
                                <div class=""form-group has-feedback has-feedback-left"">
                                    <label class=""text-bold"">
                                        ");
#nullable restore
#line 23 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Settings\Country\Country.cshtml"
                                   Write(_localizer["کود"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                        <span class=""text-danger"">&nbsp;*</span>
                                    </label>
                                    <input type=""text"" id=""orcode"" name=""orCode"" class=""form-control search"" required />
                                </div>
                            </div>
                            <div class=""col-md-4 "">
                                <div class=""form-group"">
                                    <label class=""text-bold"">
                                        ");
#nullable restore
#line 32 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Settings\Country\Country.cshtml"
                                   Write(_localizer["نام کشور"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                        <span class=""text-danger"">&nbsp;*</span>
                                    </label>
                                    <input type=""text"" id=""ortitlelocal"" name=""orTitleLocal"" class=""form-control"" required />
                                </div>
                            </div>
                            <div class=""col-md-4 "">
                                <div class=""form-group"">
                                    <label class=""text-bold"">
                                        ");
#nullable restore
#line 41 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Settings\Country\Country.cshtml"
                                   Write(_localizer["نام کشور (انگلیسی)"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                        <span class=""text-danger"">&nbsp;*</span>
                                    </label>
                                    <input type=""text"" id=""ortitle"" name=""orTitle"" class=""form-control"" required />
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <hr />
                <div class=""row div-form-control main-form-details"">
                    <div class=""col-md-12"">
                        <div class=""form-group actions"">
                            <button type=""button"" class=""btn btn-primary"" action=""save""><i class=""icon-floppy-disk position-left""></i>ثبت معلومات</button>
                            <button type=""button"" class=""btn btn-primary"" action=""search""><i class=""icon-search4 position-left""></i>جستجو </button>
                            <button type=""button"" class=""btn btn-primary"" action=""new""><i class=""icon-new-tab ");
                WriteLiteral("position-left\"></i>صفحه جدید </button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-grid main-form-details\"");
                BeginWriteAttribute("style", " style=\"", 3374, "\"", 3382, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                    <table  bindonclick=\"true\">\r\n                        <thead>\r\n                            <tr>\r\n                                <th colname=\"code\">");
#nullable restore
#line 64 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Settings\Country\Country.cshtml"
                                              Write(_localizer["کود"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                                <th colname=\"titlelocal\">");
#nullable restore
#line 65 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Settings\Country\Country.cshtml"
                                                    Write(_localizer["نام"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                                <th colname=\"title\">");
#nullable restore
#line 66 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Settings\Country\Country.cshtml"
                                               Write(_localizer["نام"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody></tbody>\r\n                    </table>\r\n                </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n\r\n     </div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer _localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clean.UI.Pages.Settings.Country.CountryModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Clean.UI.Pages.Settings.Country.CountryModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Clean.UI.Pages.Settings.Country.CountryModel>)PageContext?.ViewData;
        public Clean.UI.Pages.Settings.Country.CountryModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
