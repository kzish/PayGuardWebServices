#pragma checksum "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7453b5b16228012d4120f7d096f2cd1154a5d619"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BulkPayments_EditBulkPayment), @"mvc.1.0.view", @"/Views/BulkPayments/EditBulkPayment.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/BulkPayments/EditBulkPayment.cshtml", typeof(AspNetCore.Views_BulkPayments_EditBulkPayment))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7453b5b16228012d4120f7d096f2cd1154a5d619", @"/Views/BulkPayments/EditBulkPayment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_BulkPayments_EditBulkPayment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Banks/EditBank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:80%;margin:auto;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 1 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayment.cshtml"
  
    Layout = "~/Views/Shared/_LayoutMain.cshtml";
    var bank = (PayGuardClient.Models.MBank)ViewBag.bank;

#line default
#line hidden
            BeginContext(117, 99, true);
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n\r\n            ");
            EndContext();
            BeginContext(216, 1585, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7453b5b16228012d4120f7d096f2cd1154a5d6194515", async() => {
                BeginContext(293, 76, true);
                WriteLiteral("\r\n\r\n                <h2>Edit Bank</h2>\r\n                <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 369, "\"", 385, 1);
#line 14 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayment.cshtml"
WriteAttributeValue("", 377, bank.Id, 377, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(386, 132, true);
                WriteLiteral(" name=\"Id\" />\r\n                <div class=\"form-group\">\r\n                    <input type=\"text\" class=\"form-control\" name=\"BankName\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 518, "\"", 540, 1);
#line 16 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayment.cshtml"
WriteAttributeValue("", 526, bank.BankName, 526, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(541, 263, true);
                WriteLiteral(@" required>
                    <small class=""form-text text-muted""><span style=""color:red;"">*</span>BankName</small>
                </div>

                <div class=""form-group"">
                    <input type=""text"" class=""form-control"" name=""SwiftCode""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 804, "\"", 827, 1);
#line 21 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayment.cshtml"
WriteAttributeValue("", 812, bank.SwiftCode, 812, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(828, 263, true);
                WriteLiteral(@" required>
                    <small class=""form-text text-muted""><span style=""color:red;"">*</span>SwiftCode</small>
                </div>

                <div class=""form-group"">
                    <input type=""text"" class=""form-control"" name=""EndPoint""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1091, "\"", 1113, 1);
#line 26 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayment.cshtml"
WriteAttributeValue("", 1099, bank.EndPoint, 1099, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1114, 294, true);
                WriteLiteral(@" required>
                    <small class=""form-text text-muted""><span style=""color:red;"">*</span>EndPoint</small>
                </div>
                <div class=""form-group"">
                    <select class=""form-control"" name=""Online"">
                        <option value=""true""");
                EndContext();
                BeginWriteAttribute("selected", " selected=\"", 1408, "\"", 1433, 1);
#line 31 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayment.cshtml"
WriteAttributeValue("", 1419, bank.Online, 1419, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1434, 63, true);
                WriteLiteral(">Online</option>\r\n                        <option value=\"false\"");
                EndContext();
                BeginWriteAttribute("selected", " selected=\"", 1497, "\"", 1523, 1);
#line 32 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayment.cshtml"
WriteAttributeValue("", 1508, !bank.Online, 1508, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1524, 270, true);
                WriteLiteral(@">Offline</option>
                    </select>
                    <small class=""form-text text-muted""><span style=""color:red;"">*</span>Online</small>
                </div>

                <button type=""submit"" class=""btn btn-primary"">Save</button>
            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1801, 44, true);
            WriteLiteral("\r\n\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591