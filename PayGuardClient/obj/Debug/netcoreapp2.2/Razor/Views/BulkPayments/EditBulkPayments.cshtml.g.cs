#pragma checksum "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3d7ded277e966e263a748f5e155534973ae4fb4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BulkPayments_EditBulkPayments), @"mvc.1.0.view", @"/Views/BulkPayments/EditBulkPayments.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/BulkPayments/EditBulkPayments.cshtml", typeof(AspNetCore.Views_BulkPayments_EditBulkPayments))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3d7ded277e966e263a748f5e155534973ae4fb4", @"/Views/BulkPayments/EditBulkPayments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_BulkPayments_EditBulkPayments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Raw/BulkPay.csv"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("download", new global::Microsoft.AspNetCore.Html.HtmlString("BulkPay.csv"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/BulkPayments/EditBulkPayments"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:80%;margin:auto;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/_loading.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayments.cshtml"
  
    Layout = "~/Views/Shared/_LayoutMain.cshtml";
    var bulk_payment = (PayGuardClient.Models.MBulkPayments)ViewBag.bulk_payment;

#line default
#line hidden
            BeginContext(141, 99, true);
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n\r\n            ");
            EndContext();
            BeginContext(240, 1652, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3d7ded277e966e263a748f5e155534973ae4fb45996", async() => {
                BeginContext(362, 81, true);
                WriteLiteral("\r\n                <h2>Edit BulkPayment</h2>\r\n                <input type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 443, "\"", 467, 1);
#line 13 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayments.cshtml"
WriteAttributeValue("", 451, bulk_payment.Id, 451, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(468, 142, true);
                WriteLiteral(" name=\"Id\" />\r\n                <div class=\"form-group\">\r\n                    <input type=\"text\" class=\"form-control\" name=\"reference\" required");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 610, "\"", 641, 1);
#line 15 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayments.cshtml"
WriteAttributeValue("", 618, bulk_payment.Reference, 618, 23, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(642, 636, true);
                WriteLiteral(@">
                    <small class=""form-text text-muted""><span style=""color:red;"">*</span>Reference</small>
                </div>
                <div class=""form-group"">
                    <input type=""file"" class=""form-control"" name=""file"" accept="".csv"" />
                    <small class=""form-text text-muted"">Bulk File <span style=""color:red;"">Uploading a file will overwrite existing records</span></small>
                </div>
                <button type=""submit"" class=""btn btn-primary"">Upload</button>
                <small class=""form-text text-muted""><span style=""color:red;"">1 - Download BulkPay File</span> ");
                EndContext();
                BeginContext(1278, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f3d7ded277e966e263a748f5e155534973ae4fb48208", async() => {
                    BeginContext(1329, 11, true);
                    WriteLiteral("BulkPay.csv");
                    EndContext();
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
                EndContext();
                BeginContext(1344, 488, true);
                WriteLiteral(@"</small>
                <small class=""form-text text-muted""><span style=""color:red;"">2 - Enter beneficiaries</span></small>
                <small class=""form-text text-muted""><span style=""color:red;"">3 - Upload BulkPay file</span></small>

                <br />
                <br />
                <br />
                <a href=""javascript:void(0);"" onclick=""OpenBanksModal(); return false;"">Click here to show <b>Bank Codes</b></a>
                <br />
                ");
                EndContext();
                BeginContext(1833, 14, false);
#line 32 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayments.cshtml"
           Write(ViewBag.errors);

#line default
#line hidden
                EndContext();
                BeginContext(1847, 38, true);
                WriteLiteral("\r\n                <br />\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1892, 232, true);
            WriteLiteral("\r\n\r\n\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n\r\n            <div style=\"width:80%;margin:auto;\" id=\"recipients\">\r\n                <center id=\"loader_recipient\">\r\n                    ");
            EndContext();
            BeginContext(2124, 39, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f3d7ded277e966e263a748f5e155534973ae4fb412036", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2163, 110, true);
            WriteLiteral("\r\n                </center>\r\n            </div>\r\n           \r\n        </div>\r\n    </div>\r\n\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            BeginContext(2286, 741, true);
            WriteLiteral(@"<div class=""modal fade"" id=""all_banks_modal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Bank Codes</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-md-12"" id=""data"">

                        <center id=""loader"">
                            ");
            EndContext();
            BeginContext(3027, 39, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f3d7ded277e966e263a748f5e155534973ae4fb414229", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3066, 214, true);
            WriteLiteral("\r\n                        </center>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n<script>\r\n    $.ajax({\r\n        method:\'get\',\r\n        url: \"");
            EndContext();
            BeginContext(3282, 42, false);
#line 90 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayments.cshtml"
          Write(Url.Content("~/BulkPayments/ajaxallBanks"));

#line default
#line hidden
            EndContext();
            BeginContext(3325, 325, true);
            WriteLiteral(@""",
        success: function (data) {
            $(""#loader"").hide();
            $(""#data"").html(data);
        },
        error: function () {
            alert('Failed to load banks');
            $(""#loader"").hide();
        },
    });
</script>

<script>
    $.ajax({
        method:'get',
        url: """);
            EndContext();
            BeginContext(3652, 59, false);
#line 105 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayments.cshtml"
          Write(Url.Content("~/BulkPayments/ajaxAllBulkPaymentRecipients/"));

#line default
#line hidden
            EndContext();
            BeginContext(3713, 15, false);
#line 105 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\EditBulkPayments.cshtml"
                                                                       Write(bulk_payment.Id);

#line default
#line hidden
            EndContext();
            BeginContext(3728, 408, true);
            WriteLiteral(@""",
        success: function (data) {
            $(""#loader_recipients"").hide();
            $(""#recipients"").html(data);
        },
        error: function () {
            alert('Failed to load recipients');
            $(""#loader_recipients"").hide();
        },
    });
</script>


<script>
    function OpenBanksModal() {
        $(""#all_banks_modal"").modal(""show"");
    }
</script>

");
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
