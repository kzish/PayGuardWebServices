#pragma checksum "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\ajaxAllBulkPayments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f22ca8dd588db62c293a8764f00071381ea98dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BulkPayments_ajaxAllBulkPayments), @"mvc.1.0.view", @"/Views/BulkPayments/ajaxAllBulkPayments.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/BulkPayments/ajaxAllBulkPayments.cshtml", typeof(AspNetCore.Views_BulkPayments_ajaxAllBulkPayments))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f22ca8dd588db62c293a8764f00071381ea98dc", @"/Views/BulkPayments/ajaxAllBulkPayments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_BulkPayments_ajaxAllBulkPayments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:blue;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Banks/DeleteBank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("delete_form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\ajaxAllBulkPayments.cshtml"
  
    var bulk_payments = (List<PayGuardClient.Models.MBulkPayments>)ViewBag.bulk_payments;

#line default
#line hidden
            BeginContext(98, 9, true);
            WriteLiteral("<style>\r\n");
            EndContext();
            BeginContext(164, 133, true);
            WriteLiteral("    .custom-select\r\n    {\r\n        height:30px!important;\r\n        width:50px!important;\r\n        margin-left:5px!important;\r\n    }\r\n");
            EndContext();
            BeginContext(341, 314, true);
            WriteLiteral(@"    .dt-buttons
    {
        margin-left:4px!important;
    }
</style>



<table id=""dt"" class=""table tblsm"">
    <thead>
        <tr>
            <th>Date</th>
            <th>Reference</th>
            <th>Last Submitted</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 31 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\ajaxAllBulkPayments.cshtml"
         foreach (var item in bulk_payments)
        {

#line default
#line hidden
            BeginContext(712, 29, true);
            WriteLiteral("        <tr>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 741, "\"", 782, 1);
#line 34 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\ajaxAllBulkPayments.cshtml"
WriteAttributeValue("", 749, item.Date.ToString("d MMM yyyy"), 749, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(783, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(785, 32, false);
#line 34 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\ajaxAllBulkPayments.cshtml"
                                                     Write(item.Date.ToString("d MMM yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(817, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 839, "\"", 862, 1);
#line 35 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\ajaxAllBulkPayments.cshtml"
WriteAttributeValue("", 847, item.Reference, 847, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(863, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(865, 14, false);
#line 35 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\ajaxAllBulkPayments.cshtml"
                                   Write(item.Reference);

#line default
#line hidden
            EndContext();
            BeginContext(879, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 901, "\"", 956, 1);
#line 36 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\ajaxAllBulkPayments.cshtml"
WriteAttributeValue("", 909, item.DateLastSubmitted?.ToString("d MMM yyyy"), 909, 47, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(957, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(959, 46, false);
#line 36 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\ajaxAllBulkPayments.cshtml"
                                                                   Write(item.DateLastSubmitted?.ToString("d MMM yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1005, 89, true);
            WriteLiteral("</td>\r\n            <td>\r\n                <a href=\"javascript:void(0);\" style=\"color:red;\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1094, "\"", 1130, 3);
            WriteAttributeValue("", 1104, "confirm_delete(\'", 1104, 16, true);
#line 38 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\ajaxAllBulkPayments.cshtml"
WriteAttributeValue("", 1120, item.Id, 1120, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 1128, "\')", 1128, 2, true);
            EndWriteAttribute();
            BeginContext(1131, 88, true);
            WriteLiteral(">\r\n                    Submit\r\n                </a>\r\n                |\r\n                ");
            EndContext();
            BeginContext(1219, 104, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f22ca8dd588db62c293a8764f00071381ea98dc9280", async() => {
                BeginContext(1275, 44, true);
                WriteLiteral("\r\n                    Open\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1228, "~/Banks/EditBank/", 1228, 17, true);
#line 42 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\ajaxAllBulkPayments.cshtml"
AddHtmlAttributeValue("", 1245, item.Id, 1245, 8, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1323, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 47 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\BulkPayments\ajaxAllBulkPayments.cshtml"
        }

#line default
#line hidden
            BeginContext(1370, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
            BeginContext(1396, 136, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f22ca8dd588db62c293a8764f00071381ea98dc11514", async() => {
                BeginContext(1461, 64, true);
                WriteLiteral("\r\n    <input type=\"hidden\" value=\"\" name=\"id\" id=\"delete_id\"/>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1532, 705, true);
            WriteLiteral(@"

<script>

    $('#dt').DataTable({
        select: true,
        responsive: true,
        dom: 'lBfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });


    function confirm_delete(id) {
        $.confirm({
            title: 'Information',
            type: ""red"",
            content: 'Delete this Record?',
            buttons: {
                Yes: function () {
                    $(""#delete_id"").val(id);
                    $(""#delete_form"").submit();
                },
                No: function () {
                },

            }
        });

    }

</script>");
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