#pragma checksum "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\CreateClient.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e02ffa9c176da3bb048267d99710867627986dc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clients_CreateClient), @"mvc.1.0.view", @"/Views/Clients/CreateClient.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Clients/CreateClient.cshtml", typeof(AspNetCore.Views_Clients_CreateClient))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e02ffa9c176da3bb048267d99710867627986dc8", @"/Views/Clients/CreateClient.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_Clients_CreateClient : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Clients/CreateClient"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\CreateClient.cshtml"
  
    Layout = "~/Views/Shared/_LayoutMain.cshtml";
    var banks = (List<PayGuardAdmin.Models.MBank>)ViewBag.banks;

#line default
#line hidden
            BeginContext(124, 99, true);
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n\r\n            ");
            EndContext();
            BeginContext(223, 4462, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e02ffa9c176da3bb048267d99710867627986dc84462", async() => {
                BeginContext(306, 2675, true);
                WriteLiteral(@"

                <h2>Create Client</h2>

                <div class=""row"">

                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""email"" class=""form-control"" name=""LoginEmail"" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>Login Email</small>
                        </div>
                    </div>

                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""LoginPassword"" required value=""Softrite#99"">
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>Login Password</small>
                        </div>
                    </div>

                </div>

                <div class=""row"">

                    <div class=""col-md-3"">
                        <div class=""form-group"">
               ");
                WriteLiteral(@"             <input type=""text"" class=""form-control"" name=""ClientOrganizationName"" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>ClientOrganizationName</small>
                        </div>
                    </div>

                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""ContactPerson"" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>ContactPerson</small>
                        </div>
                    </div>

                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""ContactMobile"" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>ContactMobile</small>
                        </div>
                 ");
                WriteLiteral(@"   </div>

                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""email"" class=""form-control"" name=""ContactEmail"" required>
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
#line 69 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\CreateClient.cshtml"
                                 foreach(var bank in banks)
                                {

#line default
#line hidden
                BeginContext(3077, 43, true);
                WriteLiteral("                                    <option");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3120, "\"", 3136, 1);
#line 71 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\CreateClient.cshtml"
WriteAttributeValue("", 3128, bank.Id, 3128, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3137, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(3139, 13, false);
#line 71 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\CreateClient.cshtml"
                                                        Write(bank.BankName);

#line default
#line hidden
                EndContext();
                BeginContext(3152, 11, true);
                WriteLiteral("</option>\r\n");
                EndContext();
#line 72 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\CreateClient.cshtml"
                                }

#line default
#line hidden
                BeginContext(3198, 1480, true);
                WriteLiteral(@"                            </select>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>EBankCode</small>
                        </div>
                    </div>


                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""BankAccountName"" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>BankAccountName</small>
                        </div>
                    </div>


                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""BankAccountNumber"" required>
                            <small class=""form-text text-muted""><span style=""color:red;"">*</span>BankAccountNumber</small>
                        </div>
                    </div>


                    <div class=""col-m");
                WriteLiteral(@"d-3"">
                        <div class=""form-group"">
                            <input type=""text"" class=""form-control"" name=""BankBranchCode"" required>
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
            BeginContext(4685, 44, true);
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