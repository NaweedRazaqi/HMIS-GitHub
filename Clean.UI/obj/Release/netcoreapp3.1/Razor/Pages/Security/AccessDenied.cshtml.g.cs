#pragma checksum "C:\Users\Administrator\Desktop\Haj MIS\HMIS\Clean.UI\Pages\Security\AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3c2768393a321dd6650b7cae466597f793c6fa9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Clean.UI.Pages.Security.Pages_Security_AccessDenied), @"mvc.1.0.razor-page", @"/Pages/Security/AccessDenied.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3c2768393a321dd6650b7cae466597f793c6fa9", @"/Pages/Security/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4e588d119d3749322bd1c215836697b37532af0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Security_AccessDenied : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Administrator\Desktop\Haj MIS\HMIS\Clean.UI\Pages\Security\AccessDenied.cshtml"
  
    ViewData["Title"] = "AccessDenied";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Administrator\Desktop\Haj MIS\HMIS\Clean.UI\Pages\Security\AccessDenied.cshtml"
  
    ViewData["Title"] = "محدودیت دسترسی";
    Layout = "~/Pages/Shared/_MasterLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""panel panel-flat"" >
        <div class=""row"">
            <div class=""col-md-offset-3 col-md-5"">
                <h1>
                    حق دسترسی به این صفحه محدود میباشد
                </h1>
            </div>
        </div>
    </div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clean.UI.Pages.Security.AccessDeniedModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Clean.UI.Pages.Security.AccessDeniedModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Clean.UI.Pages.Security.AccessDeniedModel>)PageContext?.ViewData;
        public Clean.UI.Pages.Security.AccessDeniedModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
