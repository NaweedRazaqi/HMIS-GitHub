#pragma checksum "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Candidate\Passport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5e32642c7eab8b04a22f63ac118998ca26d6bdf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Clean.UI.Pages.Candidate.Pages_Candidate_Passport), @"mvc.1.0.razor-page", @"/Pages/Candidate/Passport.cshtml")]
namespace Clean.UI.Pages.Candidate
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
#line 5 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Candidate\Passport.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{handler?}/{id?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5e32642c7eab8b04a22f63ac118998ca26d6bdf", @"/Pages/Candidate/Passport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4e588d119d3749322bd1c215836697b37532af0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Candidate_Passport : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("uxipassporttypeid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "uxiPassportTypeID", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("number"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("lang", new global::Microsoft.AspNetCore.Html.HtmlString("en"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("select"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("dv_Candidate_Passport"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form sub-form page-component"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("prefix", new global::Microsoft.AspNetCore.Html.HtmlString("uxi"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("parent", new global::Microsoft.AspNetCore.Html.HtmlString("dv_Candidate_Candidate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("parentcol", new global::Microsoft.AspNetCore.Html.HtmlString("CandidateID"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Candidate\Passport.cshtml"
  
    ViewData["Title"] = "Passport";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"panel panel-flat\" style=\"direction: rtl;\">\r\n    <div class=\"panel-heading\">\r\n        <h1 class=\"panel-title\">مشخصات پاسپورت و تذکره</h1>\r\n    </div>\r\n    <div class=\"panel-body\" style=\"padding-bottom:5px;\">\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5e32642c7eab8b04a22f63ac118998ca26d6bdf7965", async() => {
                WriteLiteral(@"
            <fieldset class=""content-group"">
                <legend class=""text-bold"">لطفاً مشخصات پاسپورت یا ناظم را وارد نمایید</legend>
                <div class=""row"">
                    <div class=""col-md-3 col-sm-12 col-xs-12 "">
                        <div class=""form-group has-feedback has-feedback-left"">
                            <label class=""text-bold"">
                                ");
#nullable restore
#line 25 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Candidate\Passport.cshtml"
                           Write(_localizer["نوعیت پاسپورت؟"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </label>\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5e32642c7eab8b04a22f63ac118998ca26d6bdf8959", async() => {
                    WriteLiteral("\r\n                                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5e32642c7eab8b04a22f63ac118998ca26d6bdf9259", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 27 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\Candidate\Passport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.ListOfPassportType;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </div>
                    </div>
                    <div class=""col-md-3 col-sm-12 col-xs-12 "">
                        <div class=""form-group has-feedback has-feedback-left"">
                            <label class=""text-bold"">
                                شماره پاسپورت
                                <span class=""text-danger"">&nbsp;*</span>
                            </label>
                            <input id=""uxipassportno"" name=""uxiPassportNo"" type=""number"" class=""form-control search"" />
                            <div class=""form-control-feedback"">
                                <i class=""icon-search4 text-size-base""></i>
                            </div>
                        </div>
                    </div>
                    <div class=""col-md-3 col-sm-12 col-xs-12 "">
                        <div class=""form-group has-feedback has-feedback-left"">
                            <label class=""text-bold"">
                                تاریخ صدور");
                WriteLiteral(@"
                            </label>
                            <div class=""input-group"">
                                <span class=""input-group-addon""><i class=""icon-calendar3""></i></span>
                                <input type=""text"" id=""uxiissuedate1"" name=""uxiIssueDate1"" class=""form-control Shamsi"" sibling=""uxiissuedate"" placeholder=""تارخ صدور به شمسی "" />
                                <input type=""hidden"" id=""uxiissuedate"" name=""uxiIssueDate"" class=""form-control Miladi"" sibling=""uxiissuedate1"" placeholder=""تارخ تولد شمسی "" />
                            </div>
                        </div>
                    </div>
                    <div class=""col-md-3 col-sm-12 col-xs-12 "">
                        <div class=""form-group has-feedback has-feedback-left"">
                            <label class=""text-bold"">
                                تاریخ انقضا

                            </label>
                            <div class=""input-group"">
                                <");
                WriteLiteral(@"span class=""input-group-addon""><i class=""icon-calendar3""></i></span>
                                <input type=""text"" id=""uxiexpairydate1"" name=""uxiExpairyDate1"" class=""form-control Shamsi"" sibling=""uxiexpairydate"" placeholder=""تارخ انقضا به شمسی "" />
                                <input type=""hidden"" id=""uxiexpairydate"" name=""uxiExpairyDate"" class=""form-control Miladi"" sibling=""uxiexpairydate1"" placeholder=""تارخ تولد شمسی "" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-md-9 col-sm-12 col-xs-12 "">
                        <div class=""form-group has-feedback has-feedback-left"">
                            <label class=""text-bold"">
                                ملاحظات
                            </label>
                            <textarea id=""uxiremarks"" name=""uxiRemarks"" type=""text"" class=""form-control"" lang=""en""></textarea>
                      ");
                WriteLiteral(@"  </div>
                    </div>
                </div>
            </fieldset>
            <hr />
            <div class=""row div-form-control"">
                <div class=""col-md-12"">
                    <div class=""form-group actions"">
                        <button type=""button"" class=""btn btn-primary"" action=""save""><i class=""icon-floppy-disk position-left""></i>ثبت معلومات</button>
                        <button type=""button"" class=""btn btn-primary"" action=""search""><i class=""icon-new-tab position-left""></i>جستجو</button>
                        <button type=""button"" class=""btn btn-primary"" action=""new""><i class=""icon-new-tab position-left""></i>صفحه جدید </button>
                    </div>
                </div>
            </div>
            <div class=""form-grid"">
                <table style=""direction: rtl;"" bindonclick=""true"">
                    <thead>
                        <tr>
                            <th colname=""CandidateName"">نام کاندید</th>
                       ");
                WriteLiteral(@"     <th colname=""PTypeText"">نوعیت پاسپورت</th>
                            <th colname=""PassportNo"">نمبر پاسپورت</th>
                            <th colname=""IssueDateShamsi"">تاریخ صدور</th>
                            <th colname=""ExpairyDateShamsi"">تاریخ انقضا</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clean.UI.Pages.Candidate.PassportModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Clean.UI.Pages.Candidate.PassportModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Clean.UI.Pages.Candidate.PassportModel>)PageContext?.ViewData;
        public Clean.UI.Pages.Candidate.PassportModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
