#pragma checksum "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\ReportsToExcel\Report.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c944f556d2690ef608716e6db799e27f5d8cfa2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Clean.UI.Pages.ReportsToExcel.Pages_ReportsToExcel_Report), @"mvc.1.0.razor-page", @"/Pages/ReportsToExcel/Report.cshtml")]
namespace Clean.UI.Pages.ReportsToExcel
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{handler?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c944f556d2690ef608716e6db799e27f5d8cfa2", @"/Pages/ReportsToExcel/Report.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4e588d119d3749322bd1c215836697b37532af0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ReportsToExcel_Report : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/print.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/css/page.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/core/libraries/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/plugins/barcode/jquery-barcode.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("direction:ltr;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\HMIS\Haj MIS\HMIS\Clean.UI\Pages\ReportsToExcel\Report.cshtml"
  
    ViewData["Title"] = "Report";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c944f556d2690ef608716e6db799e27f5d8cfa25758", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Excel_Reports</title>\r\n   \r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3c944f556d2690ef608716e6db799e27f5d8cfa26128", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3c944f556d2690ef608716e6db799e27f5d8cfa27310", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        <style>
            .signholder {
                border: 2px solid #808080;
                margin-top: 100px;
                height: 0px;
                width: 300px;
                margin: 0px 0px;
                margin-top: -10px;
                padding-top: 50px;
                padding-bottom: 50px;
                border-top: none;
                border-right: none;
                border-left: none;
            }

            ");
                WriteLiteral(@"@media print {

                .rtl .div-form {
                    float: none !important;
                    right: auto !important;
                    left: auto !important;
                    position: relative;
                    top: auto !important;
                    width: 100%;
                    margin: 0;
                    box-shadow: none !important;
                }

                #FirstTable {
                    position: relative;
                    margin-right: 10px;
                    margin-top: -20px;
                }

                .table {
                    border-spacing: 0;
                    border-collapse: collapse;
                    width: 99%;
                    margin-top: 10px;
                    top: -21px;
                }

                #secondcopy {
                    position: relative;
                    padding-top: -5px;
                    margin: auto;
                    bottom: -22px;
                    ");
                WriteLiteral(@"top: -89px;
                }


                #thirdcopy {
                    position: relative;
                    margin: auto;
                    padding-bottom: 10px;
                    top: -159px;
                }

                hr {
                    display: none;
                }
            }

            .div-row, .div-row label {
                font-size: 16px;
            }

                .div-row label {
                    font-size: 14px;
                    font-weight: bold;
                }

            .form-title {
                border-width: 2px;
                font-size: 11px;
                padding-bottom: 15px;
                color: #222;
                border-bottom: 3px solid #222;
                margin-right: 10px;
                margin-top: 5px;
                margin-bottom: 0px;
            }

            .col-50 {
                width: 49% !important;
                float: right;
            }

            .bor");
                WriteLiteral(@"der-right {
                border-right: 1px solid #eee;
            }

            margin-right-2 {
                margin-right: 2px;
            }

            .div-row .eng {
                width: 49% !important;
                min-width: 0px;
                font-size: 14px !important;
                font-family: sans-serif;
                float: left !important;
                direction: ltr;
            }

            .eng label, .eng label {
                float: left !important;
                direction: ltr;
                width: auto !important;
            }

            .div-photo {
                margin-top: 10px;
            }

            .div-photo {
                background: #fff;
                box-shadow: none;
            }

            .div-mainform .title {
                border-bottom: none !important;
            }

                .div-mainform .title .div-logo img {
                    height: 130px;
                    width: auto");
                WriteLiteral(@";
                }

                .div-mainform .title .div-logo {
                    left: 45px;
                    position: absolute;
                }

            .pull-right {
                float: right;
            }

            .div-mainform .title .div-bottom .div-truck div span {
                font-size: 12px;
            }

            h1 {
                font-size: 11px;
                font-weight: bold;
                margin-top: 5px;
                margin-bottom: 5px;
                color: #000;
                align-content: center;
            }

            h2 {
                font-size: 24px;
                font-weight: bold;
                margin-top: 5px;
                margin-bottom: 5px;
                color: #000;
                text-align: center
            }

            h3 {
                font-size: 18px;
                font-weight: bold;
                margin-top: 5px;
                margin-bottom: 5px;
              ");
                WriteLiteral(@"  color: darkcyan;
                text-align: center;
            }

            .div-logo-right {
                position: absolute;
                right: 45px;
            }

            .div-logo {
                top: 20px;
            }

            .div-logo-right {
                position: absolute;
                left: 45px;
            }

            .title {
                height: 150px !important;
                position: relative;
            }

                .title .div-text {
                    width: 50%;
                    position: relative;
                    margin-right: auto;
                    margin-left: auto;
                    text-align: center;
                }

            .div-queue {
                height: 80px;
                position: absolute;
                width: 30%;
                top: 150px;
                right: 34%;
            }

            .col-25 {
                width: 25%;
                float: right;");
                WriteLiteral(@"
            }

            .col-30 {
                width: 30%;
                float: right;
            }

            .col-40 {
                width: 40%;
                float: right;
            }

            .col-20 {
                width: 20%;
                float: right;
            }

            .col-100 {
                width: 100%;
                float: right;
            }

            .col-80 {
                width: 80%;
                float: right;
            }

            .top-10 {
                margin-top: 10px;
            }

            .section-title {
                margin-top: 5px;
                border-top: 3px solid #777;
                padding-top: 10px;
                padding-bottom: 10px;
                border-bottom: 3px solid #777;
                font-size: 11px;
            }

            table {
                border-spacing: 0;
                border-collapse: collapse;
                width: 100%;
              ");
                WriteLiteral(@"  margin-top: 10px;
                position: relative;
                top: -21px;
            }

            .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
                padding: 8px;
                line-height: 1.42857143;
                vertical-align: top;
                border-top: 1px solid #222
            }

            .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
                vertical-align: middle;
            }

            .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
                border: 1px solid #ddd;
                border-top-color: rgb(221, 221, 221);
                border-top-sty");
                WriteLiteral(@"le: solid;
                border-top-width: 1px;
            }

            td, th {
                font-size: 16px !important;
                padding: 5px;
            }

            body {
                background: #737373;
            }

            .table > tbody {
            }

            .code {
                font-size: 18px;
                font-weight: bold;
                margin-top: 5px;
                margin-bottom: 5px;
                color: darkcyan;
                text-align: center;
            }
        </style>
        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c944f556d2690ef608716e6db799e27f5d8cfa216986", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c944f556d2690ef608716e6db799e27f5d8cfa218090", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c944f556d2690ef608716e6db799e27f5d8cfa219894", async() => {
                WriteLiteral("\r\n    <hr />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clean.UI.Pages.ReportsToExcel.Report> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Clean.UI.Pages.ReportsToExcel.Report> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Clean.UI.Pages.ReportsToExcel.Report>)PageContext?.ViewData;
        public Clean.UI.Pages.ReportsToExcel.Report Model => ViewData.Model;
    }
}
#pragma warning restore 1591