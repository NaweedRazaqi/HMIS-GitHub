#pragma checksum "C:\Users\Administrator\Desktop\Haj MIS\HMIS\Clean.UI\Pages\Security\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "265129dbb7f9ee2a165d83d75cce802251eb2966"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Clean.UI.Pages.Security.Pages_Security_Register), @"mvc.1.0.razor-page", @"/Pages/Security/Register.cshtml")]
namespace Clean.UI.Pages.Security
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
#line 1 "C:\Users\Administrator\Desktop\Haj MIS\HMIS\Clean.UI\Pages\_ViewImports.cshtml"
using Clean.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{handler?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"265129dbb7f9ee2a165d83d75cce802251eb2966", @"/Pages/Security/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4e588d119d3749322bd1c215836697b37532af0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Security_Register : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("uxorganizationid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "uxOrganizationID", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("select search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("dv_Security_Register"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form main-form page-component"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("prefix", new global::Microsoft.AspNetCore.Html.HtmlString("ux"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\Administrator\Desktop\Haj MIS\HMIS\Clean.UI\Pages\Security\Register.cshtml"
  
    Layout = "~/Pages/Shared/_MasterLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Administrator\Desktop\Haj MIS\HMIS\Clean.UI\Pages\Security\Register.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"panel panel-flat\" >\r\n        <div class=\"panel-heading\">\r\n            <h1 class=\"panel-title\">تنظیمات کاربری</h1>\r\n        </div>\r\n        <div class=\"panel-body\">\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "265129dbb7f9ee2a165d83d75cce802251eb29666550", async() => {
                WriteLiteral("\r\n                <fieldset class=\"content-group\">\r\n                    <input type=\"hidden\" id=\"uxcurrentuser\" name=\"cpUserName\"");
                BeginWriteAttribute("value", " value=\"", 572, "\"", 598, 1);
#nullable restore
#line 16 "C:\Users\Administrator\Desktop\Haj MIS\HMIS\Clean.UI\Pages\Security\Register.cshtml"
WriteAttributeValue("", 580, Model.CurrentUser, 580, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />

                    <legend>جهت ثبت کاربر های سیستم و تعین حقوق و نقش ها از این صفحه استفاده نمائید</legend>
                    <div class=""row"">
                        <div class=""col-md-6 col-sm-12 col-xs-12 "">
                            <div class=""form-group"">
                                <label class=""text-bold"">
                                    نام
                                    <span class=""text-danger"">&nbsp;*</span>
                                </label>
                                <input type=""text"" id=""uxfirstname"" name=""uxFirstName"" class=""form-control"" required>
                            </div>
                        </div>
                        <div class=""col-md-6 col-sm-12 col-xs-12 "">
                            <div class=""form-group"">
                                <label class=""text-bold"">
                                    تخلص
                                </label>
                                <input type=""text"" id=""uxlastname"" name=");
                WriteLiteral(@"""uxLastName"" class=""form-control"">
                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-6 col-sm-12 col-xs-12 "">
                            <div class=""form-group"">
                                <label class=""text-bold"">
                                    نام پدر
                                    <span class=""text-danger"">&nbsp;*</span>
                                </label>
                                <input type=""text"" id=""uxfathername"" name=""uxFatherName"" class=""form-control"" required>
                            </div>
                        </div>
                        <div class=""col-md-6 col-sm-12 col-xs-12 "">
                            <div class=""form-group has-feedback has-feedback-left"">
                                <label class=""text-bold"">
                                    ارگان
                                    <span class=""text-danger""");
                WriteLiteral(">&nbsp;*</span>\r\n                                </label>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "265129dbb7f9ee2a165d83d75cce802251eb29669601", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "265129dbb7f9ee2a165d83d75cce802251eb29669905", async() => {
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
                    WriteLiteral("\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 54 "C:\Users\Administrator\Desktop\Haj MIS\HMIS\Clean.UI\Pages\Security\Register.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Model.ListOfOrganization;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
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
                    </div>
                    <div class=""row"">
                        <div class=""col-md-6 col-sm-12 col-xs-12 "">
                            <div class=""form-group has-feedback has-feedback-left"">
                                <label class=""text-bold"">
                                    ایمیل آدرس
                                </label>
                                <input id=""uxemail"" name=""uxEmail"" class=""form-control"" />
                                <div class=""form-control-feedback"">
                                    <i class=""icon-mail5 text-size-base"">
                                    </i>
                                </div>
                            </div>
                        </div>

                        <div class=""col-md-6 col-sm-12 col-xs-12 "">
                            <div class=""form-group has-feedback has-feedback-left"">
                                <label cla");
                WriteLiteral(@"ss=""text-bold"">
                                    نام کاربری
                                    <span class=""text-danger"">&nbsp;*</span>
                                </label>

                                <input id=""uxusername"" name=""uxUserName"" class=""form-control search"" required />
                            </div>
                        </div>
                    </div>

                    <div class=""row"">
");
                WriteLiteral(@"                        <div class=""col-md-6 col-sm-12 col-xs-12 "">
                            <div class=""form-group has-feedback has-feedback-left"">
                                <label class=""text-bold"">فعال | ‌غیر فعال</label>
                                <input type=""checkbox"" class=""checkbox"" id=""uxactive"" name=""uxActive"" />
                            </div>
                        </div>
                    </div>
                </fieldset>
                <hr />
                <div class=""row div-form-control"">
                    <div class=""col-md-12"">
                        <div class=""form-group actions"">

                            <button type=""button"" action=""save"" class=""btn btn-primary""><i class=""icon-floppy-disk position-left""></i>ثبت کاربر</button>
                            <button type=""button"" action=""new"" class=""btn btn-primary""><i class=""icon-new-tab position-left""></i>جدید</button>
                            <button type=""button"" action=""search"" class=""btn ");
                WriteLiteral(@"btn-primary""><i class=""icon-search4 position-left""></i>جستجو به اساس ارگان و نام کاربری</button>
                            <button id=""btnResetPassword"" type=""button"" class=""btn btn-primary""><i class=""icon-reset position-left""></i>تنظیم مجدد رمز عبور</button>

                        </div>
                    </div>
                </div>

                <div class=""form-grid main-form-details"">
                    <table  bindonclick=""true"">
                        <thead>
                            <tr>
                                <th colname=""firstname"">نام</th>
                                <th colname=""lastname"">تخلص</th>
                                <th colname=""username"">نام کاربری</th>
                                <th colname=""email"">آدرس الکترونیکی</th>
                            </tr>
                        </thead>
                    </table>
                </div>

            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"page-sidebar page-component\" type=\"actionmenu\">\r\n            <ul class=\"navigation navigation-alt navigation-accordion\">\r\n\r\n                ");
#nullable restore
#line 138 "C:\Users\Administrator\Desktop\Haj MIS\HMIS\Clean.UI\Pages\Security\Register.cshtml"
           Write(Html.Raw(@Model.SubScreens));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </ul>\r\n        </div>\r\n    </div>\r\n");
            DefineSection("PageScripts", async() => {
                WriteLiteral(@"
            <script>
                $(document).ready(function () {
                    $('#btnResetPassword').on('click', function () {

                        let path = '/Security/Register/ResetPassword';
                        let data = {};
                        data.id = $('#' + $('#dv_Security_Register').attr('prefix') + 'id').val();
                        data.username = $('#' + $('#dv_Security_Register').attr('prefix') + 'username').val();

                        if (!$.isEmptyObject(data.id)) {
                            let conf = confirm(""آیا مطئن هستید که رمز عبور کاربر انتخاب شده تغییر کند؟"");
                            if (conf) {
                                clean.data.post({
                                    async: false, url: path, data: clean.data.json.write(data), datatype: 'json',
                                    success: function (result) {
                                        if (result.status > 0) {

                                            cle");
                WriteLiteral(@"an.widget.success(result.text, result.description, 300000);
                                        }
                                        else {
                                            clean.widget.warn(result.text, result.description, 60000);
                                        }
                                    }
                                });
                            }
                        }
                        else {
                            clean.widget.warn('کوشش خلاف اصول', 'لطفا ابتدا کاربر را انتخاب نموده سپس گزرواژه آن را تغییر دهید.')
                        }
                    });
                });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clean.UI.Pages.Security.RegisterModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Clean.UI.Pages.Security.RegisterModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Clean.UI.Pages.Security.RegisterModel>)PageContext?.ViewData;
        public Clean.UI.Pages.Security.RegisterModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
