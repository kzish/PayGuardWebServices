#pragma checksum "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9260b1ac5c8f6a336dfbea9718e9196647e66b3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clients_EditClient), @"mvc.1.0.view", @"/Views/Clients/EditClient.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Clients/EditClient.cshtml", typeof(AspNetCore.Views_Clients_EditClient))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9260b1ac5c8f6a336dfbea9718e9196647e66b3a", @"/Views/Clients/EditClient.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_Clients_EditClient : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Clients/EditClient"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
  
    Layout = "~/Views/Shared/_LayoutMain.cshtml";
    var banks = (List<PayGuardAdmin.Models.MBank>)ViewBag.banks;
    var client = (PayGuardAdmin.Models.MClient)ViewBag.client;
    var asp_net_user = (PayGuardAdmin.Models.AspNetUsers)ViewBag.user;

#line default
#line hidden
            BeginContext(260, 99, true);
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n\r\n            ");
            EndContext();
            BeginContext(359, 4834, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9260b1ac5c8f6a336dfbea9718e9196647e66b3a4580", async() => {
                BeginContext(440, 98, true);
                WriteLiteral("\r\n\r\n                <h2>Edit Client</h2>\r\n                <input type=\"hidden\" name=\"AspNetUserId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 538, "\"", 566, 1);
#line 16 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
WriteAttributeValue("", 546, client.AspNetUserId, 546, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(567, 221, true);
                WriteLiteral("/>\r\n                <div class=\"row\">\r\n\r\n                    <div class=\"col-md-3\">\r\n                        <div class=\"form-group\">\r\n                            <input type=\"email\" class=\"form-control\" name=\"LoginEmail\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 788, "\"", 815, 1);
#line 21 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
WriteAttributeValue("", 796, asp_net_user.Email, 796, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(816, 838, true);
                WriteLiteral(@" disabled>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>Login Email</small>
                        </div>
                    </div>

                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""LoginPassword"" value=""******"" disabled>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>Login Password</small>
                        </div>
                    </div>

                </div>

                <div class=""row"">

                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""ClientOrganizationName""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1654, "\"", 1692, 1);
#line 39 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
WriteAttributeValue("", 1662, client.ClientOrganizationName, 1662, 30, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1693, 385, true);
                WriteLiteral(@" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>ClientOrganizationName</small>
                        </div>
                    </div>

                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""ContactPerson""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2078, "\"", 2107, 1);
#line 46 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
WriteAttributeValue("", 2086, client.ContactPerson, 2086, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2108, 376, true);
                WriteLiteral(@" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>ContactPerson</small>
                        </div>
                    </div>

                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""ContactMobile""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2484, "\"", 2513, 1);
#line 53 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
WriteAttributeValue("", 2492, client.ContactMobile, 2492, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2514, 376, true);
                WriteLiteral(@" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>ContactMobile</small>
                        </div>
                    </div>

                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""email"" class=""form-control"" name=""ContactEmail""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2890, "\"", 2918, 1);
#line 60 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
WriteAttributeValue("", 2898, client.ContactEmail, 2898, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2919, 432, true);
                WriteLiteral(@" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>ContactEmail</small>
                        </div>
                    </div>

                </div>

                <div class=""row"">
                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <select class=""form-control .chosen"" name=""EBankCode"">
");
                EndContext();
#line 71 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
                                 foreach (var bank in banks)
                                {

#line default
#line hidden
                BeginContext(3448, 43, true);
                WriteLiteral("                                    <option");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3491, "\"", 3507, 1);
#line 73 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
WriteAttributeValue("", 3499, bank.Id, 3499, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("selected", " selected=\"", 3508, "\"", 3547, 1);
#line 73 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
WriteAttributeValue("", 3519, bank.Id==client.EBankCode, 3519, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3548, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(3550, 13, false);
#line 73 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
                                                                                                Write(bank.BankName);

#line default
#line hidden
                EndContext();
                BeginContext(3563, 11, true);
                WriteLiteral("</option>\r\n");
                EndContext();
#line 74 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
                                }

#line default
#line hidden
                BeginContext(3609, 403, true);
                WriteLiteral(@"                            </select>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>EBankCode</small>
                        </div>
                    </div>


                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""BankAccountName""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4012, "\"", 4043, 1);
#line 83 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
WriteAttributeValue("", 4020, client.BankAccountName, 4020, 23, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4044, 384, true);
                WriteLiteral(@" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>BankAccountName</small>
                        </div>
                    </div>


                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""BankAccountNumber""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4428, "\"", 4461, 1);
#line 91 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
WriteAttributeValue("", 4436, client.BankAccountNumber, 4436, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4462, 383, true);
                WriteLiteral(@" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>BankAccountNumber</small>
                        </div>
                    </div>


                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""BankBranchCode""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4845, "\"", 4875, 1);
#line 99 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\EditClient.cshtml"
WriteAttributeValue("", 4853, client.BankBranchCode, 4853, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4876, 310, true);
                WriteLiteral(@" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>BankBranchCode</small>
                        </div>
                    </div>

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
            BeginContext(5193, 44, true);
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
