#pragma checksum "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "715e7748f3182db22dadfa5da22277263986f486"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clients_ajaxAllClients), @"mvc.1.0.view", @"/Views/Clients/ajaxAllClients.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Clients/ajaxAllClients.cshtml", typeof(AspNetCore.Views_Clients_ajaxAllClients))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"715e7748f3182db22dadfa5da22277263986f486", @"/Views/Clients/ajaxAllClients.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_Clients_ajaxAllClients : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:blue;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Clients/DeleteClient"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
  
    var clients = (List<PayGuardAdmin.Models.MClient>)ViewBag.clients;

#line default
#line hidden
            BeginContext(79, 9, true);
            WriteLiteral("<style>\r\n");
            EndContext();
            BeginContext(145, 133, true);
            WriteLiteral("    .custom-select\r\n    {\r\n        height:30px!important;\r\n        width:50px!important;\r\n        margin-left:5px!important;\r\n    }\r\n");
            EndContext();
            BeginContext(322, 516, true);
            WriteLiteral(@"    .dt-buttons
    {
        margin-left:4px!important;
    }
</style>



<table id=""dt"" class=""table tblsm"">
    <thead>
        <tr>
            <th>ClientOrganizationName</th>
            <th>ContactPerson</th>
            <th>ContactMobile</th>
            <th>ContactEmail</th>
            <th>BankCode</th>
            <th>BankAccountName</th>
            <th>BankAccountNumber</th>
            <th>BankBranchCode</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 36 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
         foreach (var item in clients)
        {

#line default
#line hidden
            BeginContext(889, 37, true);
            WriteLiteral("            <tr>\r\n                <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 926, "\"", 962, 1);
#line 39 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
WriteAttributeValue("", 934, item.ClientOrganizationName, 934, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(963, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(965, 27, false);
#line 39 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
                                                    Write(item.ClientOrganizationName);

#line default
#line hidden
            EndContext();
            BeginContext(992, 26, true);
            WriteLiteral("</td>\r\n                <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1018, "\"", 1045, 1);
#line 40 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
WriteAttributeValue("", 1026, item.ContactPerson, 1026, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1046, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1048, 18, false);
#line 40 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
                                           Write(item.ContactPerson);

#line default
#line hidden
            EndContext();
            BeginContext(1066, 26, true);
            WriteLiteral("</td>\r\n                <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1092, "\"", 1119, 1);
#line 41 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
WriteAttributeValue("", 1100, item.ContactMobile, 1100, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1120, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1122, 18, false);
#line 41 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
                                           Write(item.ContactMobile);

#line default
#line hidden
            EndContext();
            BeginContext(1140, 26, true);
            WriteLiteral("</td>\r\n                <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1166, "\"", 1192, 1);
#line 42 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
WriteAttributeValue("", 1174, item.ContactEmail, 1174, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1193, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1195, 17, false);
#line 42 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
                                          Write(item.ContactEmail);

#line default
#line hidden
            EndContext();
            BeginContext(1212, 26, true);
            WriteLiteral("</td>\r\n                <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1238, "\"", 1261, 1);
#line 43 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
WriteAttributeValue("", 1246, item.EBankCode, 1246, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1262, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1264, 14, false);
#line 43 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
                                       Write(item.EBankCode);

#line default
#line hidden
            EndContext();
            BeginContext(1278, 26, true);
            WriteLiteral("</td>\r\n                <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1304, "\"", 1333, 1);
#line 44 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
WriteAttributeValue("", 1312, item.BankAccountName, 1312, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1334, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1336, 20, false);
#line 44 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
                                             Write(item.BankAccountName);

#line default
#line hidden
            EndContext();
            BeginContext(1356, 26, true);
            WriteLiteral("</td>\r\n                <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1382, "\"", 1413, 1);
#line 45 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
WriteAttributeValue("", 1390, item.BankAccountNumber, 1390, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1414, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1416, 22, false);
#line 45 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
                                               Write(item.BankAccountNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1438, 26, true);
            WriteLiteral("</td>\r\n                <td");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1464, "\"", 1492, 1);
#line 46 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
WriteAttributeValue("", 1472, item.BankBranchCode, 1472, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1493, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1495, 19, false);
#line 46 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
                                            Write(item.BankBranchCode);

#line default
#line hidden
            EndContext();
            BeginContext(1514, 97, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    <a href=\"javascript:void(0);\" style=\"color:red;\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1611, "\"", 1657, 3);
            WriteAttributeValue("", 1621, "confirm_delete(\'", 1621, 16, true);
#line 48 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
WriteAttributeValue("", 1637, item.AspNetUserId, 1637, 18, false);

#line default
#line hidden
            WriteAttributeValue("", 1655, "\')", 1655, 2, true);
            EndWriteAttribute();
            BeginContext(1658, 104, true);
            WriteLiteral(">\r\n                        Delete\r\n                    </a>\r\n                    |\r\n                    ");
            EndContext();
            BeginContext(1762, 126, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "715e7748f3182db22dadfa5da22277263986f48613627", async() => {
                BeginContext(1832, 52, true);
                WriteLiteral("\r\n                        Open\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1771, "~/Clients/EditClient/", 1771, 21, true);
#line 52 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
AddHtmlAttributeValue("", 1792, item.AspNetUserId, 1792, 18, false);

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
            BeginContext(1888, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 57 "C:\Users\Softrite\Documents\Visual Studio 2019\projects\PayGuard\PayGuardAdmin\Views\Clients\ajaxAllClients.cshtml"
        }

#line default
#line hidden
            BeginContext(1943, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
            BeginContext(1969, 140, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "715e7748f3182db22dadfa5da22277263986f48615871", async() => {
                BeginContext(2038, 64, true);
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
            BeginContext(2109, 705, true);
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
