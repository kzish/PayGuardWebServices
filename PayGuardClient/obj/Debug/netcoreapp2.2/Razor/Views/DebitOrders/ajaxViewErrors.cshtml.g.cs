#pragma checksum "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a98f5e5e9d021c503c00680b424b9c79248c4724"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a98f5e5e9d021c503c00680b424b9c79248c4724", @"/Views/DebitOrders/ajaxViewErrors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_DebitOrders_ajaxViewErrors : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
  
    var errors = (List<PayGuard.Models.MAccountDebitInstructionsFailed>)ViewBag.errors;

#line default
#line hidden
            BeginContext(96, 9, true);
            WriteLiteral("<style>\r\n");
            EndContext();
            BeginContext(162, 133, true);
            WriteLiteral("    .custom-select\r\n    {\r\n        height:30px!important;\r\n        width:50px!important;\r\n        margin-left:5px!important;\r\n    }\r\n");
            EndContext();
            BeginContext(339, 432, true);
            WriteLiteral(@"    .dt-buttons
    {
        margin-left:4px!important;
    }
</style>

<table id=""dt_"" class=""table tblsm"">
    <thead>
        <tr>
            <th>Date</th>
            <th>ClientBankCode</th>
            <th>ClientAccountNumber</th>
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
            BeginContext(821, 29, true);
            WriteLiteral("        <tr>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 850, "\"", 891, 1);
#line 35 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 858, item.Date.ToString("d-MMM-yyyy"), 858, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(892, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(894, 32, false);
#line 35 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                                     Write(item.Date.ToString("d-MMM-yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(926, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 948, "\"", 976, 1);
#line 36 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 956, item.ClientBankCode, 956, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(977, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(979, 19, false);
#line 36 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                        Write(item.ClientBankCode);

#line default
#line hidden
            EndContext();
            BeginContext(998, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1020, "\"", 1053, 1);
#line 37 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 1028, item.ClientAccountNumber, 1028, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1054, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1056, 24, false);
#line 37 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                             Write(item.ClientAccountNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1080, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1102, "\"", 1130, 1);
#line 38 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 1110, item.SenderBankCode, 1110, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1131, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1133, 19, false);
#line 38 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                        Write(item.SenderBankCode);

#line default
#line hidden
            EndContext();
            BeginContext(1152, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1174, "\"", 1207, 1);
#line 39 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 1182, item.SenderAccountNumber, 1182, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1208, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1210, 24, false);
#line 39 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                             Write(item.SenderAccountNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1234, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1256, "\"", 1276, 1);
#line 40 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 1264, item.Amount, 1264, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1277, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1279, 11, false);
#line 40 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                Write(item.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(1290, 22, true);
            WriteLiteral("</td>\r\n            <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1312, "\"", 1335, 1);
#line 41 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
WriteAttributeValue("", 1320, item.Reference, 1320, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1336, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1338, 14, false);
#line 41 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
                                   Write(item.Reference);

#line default
#line hidden
            EndContext();
            BeginContext(1352, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 43 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardClient\Views\DebitOrders\ajaxViewErrors.cshtml"
        }

#line default
#line hidden
            BeginContext(1385, 289, true);
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
