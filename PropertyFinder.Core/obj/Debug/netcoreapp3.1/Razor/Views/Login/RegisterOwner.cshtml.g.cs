#pragma checksum "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6bd279924c96d58a1d89accc5b67010631989f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_RegisterOwner), @"mvc.1.0.view", @"/Views/Login/RegisterOwner.cshtml")]
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
#line 1 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\_ViewImports.cshtml"
using PropertyFinder.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\_ViewImports.cshtml"
using PropertyFinder.Core.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6bd279924c96d58a1d89accc5b67010631989f5", @"/Views/Login/RegisterOwner.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e27b6f71110eec42e37e0d76dfc7158bcec6cd6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_RegisterOwner : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PropertyFinder.Data.ViewModel.UserViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/house-js/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
   ViewBag.Title = "Register"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>SignUp</h2>\n\n\n");
#nullable restore
#line 8 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-horizontal\">\n                    <hr />\n                    ");
#nullable restore
#line 13 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
               Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n                    <div class=\"form-group\">\n                        ");
#nullable restore
#line 16 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                   Write(Html.LabelFor(model => model.Firstname, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        <div class=\"col-md-10\">\n                            ");
#nullable restore
#line 18 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                       Write(Html.EditorFor(model => model.Firstname, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            ");
#nullable restore
#line 19 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                       Write(Html.ValidationMessageFor(model => model.Firstname, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </div>\n                    </div>\n\n                    <div class=\"form-group\">\n                        ");
#nullable restore
#line 24 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                   Write(Html.LabelFor(model => model.Lastname, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        <div class=\"col-md-10\">\n                            ");
#nullable restore
#line 26 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                       Write(Html.EditorFor(model => model.Lastname, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            ");
#nullable restore
#line 27 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                       Write(Html.ValidationMessageFor(model => model.Lastname, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </div>\n                    </div>\n\n                    <div class=\"form-group\">\n                        ");
#nullable restore
#line 32 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                   Write(Html.LabelFor(model => model.Contact, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        <div class=\"col-md-10\">\n                            ");
#nullable restore
#line 34 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                       Write(Html.EditorFor(model => model.Contact, new { htmlAttributes = new { @type = "number", @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            ");
#nullable restore
#line 35 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                       Write(Html.ValidationMessageFor(model => model.Contact, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </div>\n                    </div>\n\n                    <div class=\"form-group\">\n                        ");
#nullable restore
#line 40 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                   Write(Html.LabelFor(model => model.Email, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        <div class=\"col-md-10\">\n                            ");
#nullable restore
#line 42 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                       Write(Html.EditorFor(model => model.Email, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            ");
#nullable restore
#line 43 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                       Write(Html.ValidationMessageFor(model => model.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </div>\n                    </div>\n\n                    <div class=\"form-group\">\n                        ");
#nullable restore
#line 48 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                   Write(Html.LabelFor(model => model.Password, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        <div class=\"col-md-10\">\n                            ");
#nullable restore
#line 50 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                       Write(Html.EditorFor(model => model.Password, new { htmlAttributes = new { @type = "password", @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            ");
#nullable restore
#line 51 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                       Write(Html.ValidationMessageFor(model => model.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </div>\n                    </div>\n\n                    <div class=\"form-group\">\n                        ");
#nullable restore
#line 56 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                   Write(Html.LabelFor(model => model.ConfirmPassword, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        <div class=\"col-md-10\">\n                            ");
#nullable restore
#line 58 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                       Write(Html.EditorFor(model => model.ConfirmPassword, new { htmlAttributes = new { @type = "password", @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            ");
#nullable restore
#line 59 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
                       Write(Html.ValidationMessageFor(model => model.ConfirmPassword, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>

                    <div class=""form-group"">
                        <div class=""col-md-offset-2 col-md-10"">
                            <input type=""submit"" value=""Save"" class=""btn btn-default bg-success"" />
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 69 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""modal fade"" id=""popupModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""aModalLabel""
     aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""aModalLabel"">Message</h4>
            </div>
            <div class=""modal-body"">
                ");
#nullable restore
#line 80 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
           Write(ViewBag.Result);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n            <div class=\"modal-footer\">\n                <button type=\"button\" class=\"btn btn-success\" data-dismiss=\"modal\">OK</button>\n            </div>\n        </div>\n    </div>\n</div>\n\n<div>\n    ");
#nullable restore
#line 90 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
Write(Html.ActionLink("Back to List", "Login"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</div>\n\n");
#nullable restore
#line 93 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
   if (ViewBag.Result != null)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6bd279924c96d58a1d89accc5b67010631989f515215", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        <script type=\"text/javascript\">\n            $(function ()\n        {\n            $(\"#popupModal\").modal(\'show\');\n    });\n        </script>\n");
#nullable restore
#line 103 "C:\Users\Kaushtup Bista\Desktop\my projects\masters project\PropertyFinder.Core\PropertyFinder.Core\Views\Login\RegisterOwner.cshtml"
 } 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PropertyFinder.Data.ViewModel.UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
