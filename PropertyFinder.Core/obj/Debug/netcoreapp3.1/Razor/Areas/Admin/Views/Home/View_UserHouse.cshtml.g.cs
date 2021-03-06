#pragma checksum "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23b024004c50257b774c8701822c230195f46673"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_View_UserHouse), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/View_UserHouse.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\_ViewImports.cshtml"
using PropertyFinder.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\_ViewImports.cshtml"
using PropertyFinder.Core.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23b024004c50257b774c8701822c230195f46673", @"/Areas/Admin/Views/Home/View_UserHouse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e27b6f71110eec42e37e0d76dfc7158bcec6cd6b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_View_UserHouse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PropertyFinder.Data.ViewModel.HouseDisplayViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteHouse", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml"
  
    ViewData["Title"] = "Admin Site";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div>\r\n    ");
#nullable restore
#line 10 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
</div>

<div class=""divList"">

    <h3>House Info</h3>

    <table class=""table"">
        <thead>
            <tr>
                <th style=""width:10%"">
                    Name
                </th>
                <th style=""width:20%"">
                    Description
                </th>
                <th style=""width:15%"">
                    Address
                </th>
                <th style=""width:15%"">
                    Cost(??)
                </th>
                <th style=""width:20%"">
                    Available Date
                </th>
                <th style=""width:15%"">
                    House Type
                </th>
                <th style=""width:5%"">

                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 44 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td style=\"width:10%\">");
#nullable restore
#line 47 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml"
                                     Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"width:20%\">");
#nullable restore
#line 48 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml"
                                     Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"width:15%\">");
#nullable restore
#line 49 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml"
                                     Write(item.AddressInfoName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"width:15%\">");
#nullable restore
#line 50 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml"
                                     Write(item.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"width:20%\">");
#nullable restore
#line 51 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml"
                                     Write(item.AvailableDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"width:15%\">");
#nullable restore
#line 52 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml"
                                     Write(item.HouseTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"width:5%\">\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23b024004c50257b774c8701822c230195f466738324", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1677, "\"", 1693, 1);
#nullable restore
#line 56 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml"
WriteAttributeValue("", 1685, item.Id, 1685, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"id\" />\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1757, "\"", 1784, 1);
#nullable restore
#line 57 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml"
WriteAttributeValue("", 1765, ViewData["UserId"], 1765, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"userid\" />\r\n                            <input type=\"submit\" id=\"userhouse\" class=\"btn btn-danger btn-sm\" value=\"Delete House\">\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 62 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Areas\Admin\Views\Home\View_UserHouse.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PropertyFinder.Data.ViewModel.HouseDisplayViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
