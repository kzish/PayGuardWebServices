#pragma checksum "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04666fbd2a2e5a4d6a22925d9afd0a851d305d81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DebitOrders_ajaxViewErrors), @"mvc.1.0.view", @"/Views/DebitOrders/ajaxViewErrors.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DebitOrders/ajaxViewErrors.cshtml", typeof(AspNetCore.Views_DebitOrders_ajaxViewErrors))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04666fbd2a2e5a4d6a22925d9afd0a851d305d81", @"/Views/DebitOrders/ajaxViewErrors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_DebitOrders_ajaxViewErrors : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
  
    var errors = (List<PayGuard.Models.MAccountCreditInstructionsFailed>)ViewBag.errors;

#line default
#line hidden
            BeginContext(97, 9, true);
            WriteLiteral("<style>\r\n");
            EndContext();
            BeginContext(163, 133, true);
            WriteLiteral("    .custom-select\r\n    {\r\n        height:30px!important;\r\n        width:50px!important;\r\n        margin-left:5px!important;\r\n    }\r\n");
            EndContext();
            BeginContext(340, 438, true);
            WriteLiteral(@"    .dt-buttons
    {
        margin-left:4px!important;
    }
</style>

<table id=""dt_"" class=""table tblsm"">
    <thead>
        <tr>
            <th>Date</th>
            <th>RecipientBankCode</th>
            <th>RecipientAccountNumber</th>
            <th>SenderBankCode</th>
            <th>SenderAccountNumber</th>
            <th>Amount</th>
            <th>Reference</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 32 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
         foreach (var item in errors)
        {

#line default
#line hidden
            BeginContext(828, 29, true);
            WriteLiteral("        <tr>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 857, "\"", 898, 1);
#line 35 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 865, item.Date.ToString("d-MMM-yyyy"), 865, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(899, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(901, 32, false);
#line 35 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                                     Write(item.Date.ToString("d-MMM-yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(933, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 955, "\"", 986, 1);
#line 36 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 963, item.RecipientBankCode, 963, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(987, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(989, 22, false);
#line 36 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                           Write(item.RecipientBankCode);

#line default
#line hidden
            EndContext();
            BeginContext(1011, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1033, "\"", 1069, 1);
#line 37 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 1041, item.RecipientAccountNumber, 1041, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1070, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1072, 27, false);
#line 37 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                                Write(item.RecipientAccountNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1099, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1121, "\"", 1149, 1);
#line 38 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 1129, item.SenderBankCode, 1129, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1150, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1152, 19, false);
#line 38 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                        Write(item.SenderBankCode);

#line default
#line hidden
            EndContext();
            BeginContext(1171, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1193, "\"", 1226, 1);
#line 39 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 1201, item.SenderAccountNumber, 1201, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1227, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1229, 24, false);
#line 39 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                             Write(item.SenderAccountNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1253, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1275, "\"", 1295, 1);
#line 40 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 1283, item.Amount, 1283, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1296, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1298, 11, false);
#line 40 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                Write(item.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(1309, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1331, "\"", 1354, 1);
#line 41 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 1339, item.Reference, 1339, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1355, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1357, 14, false);
#line 41 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                   Write(item.Reference);

#line default
#line hidden
            EndContext();
            BeginContext(1371, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 43 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
        }

#line default
#line hidden
            BeginContext(1404, 289, true);
            WriteLiteral(@"    </tbody>
</table>

<script>
    $('#dt_').DataTable({
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
