#pragma checksum "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c886443b03d73ee4de5e23c2e151624c6fa532c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employees_SalaryReportAcc), @"mvc.1.0.view", @"/Views/Employees/SalaryReportAcc.cshtml")]
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
#line 1 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\_ViewImports.cshtml"
using TheTopWebsite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\_ViewImports.cshtml"
using TheTopWebsite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c886443b03d73ee4de5e23c2e151624c6fa532c", @"/Views/Employees/SalaryReportAcc.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0033c8a9a3c1208f9b51f992daceb3fd3bd5460a", @"/Views/_ViewImports.cshtml")]
    public class Views_Employees_SalaryReportAcc : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TheTopWebsite.Models.Employee>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutAccountant.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    function save() {
        window.print();
    }
</script>
<button class=""btn btn-primary pull-right"" style=""background-color: #9c27b0; color: white;"" onclick=""save()"">Save As Pdf</button>
<br />
<br />
<br />

<div class=""col-md-12"">
    <div class=""card"">
        <div class=""card-header card-header-primary"">
            <h4 class=""card-title "">Salary Reports</h4>
            <p class=""card-category""> Here is a Salary Reports for Employees </p>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table"">
                    <thead class="" text-primary"">
                        <tr>
                            <th>
                                ");
#nullable restore
#line 31 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 34 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 37 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                           Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 40 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                           Write(Html.DisplayNameFor(model => model.Salary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 43 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                           Write(Html.DisplayNameFor(model => model.Position));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n\r\n\r\n                        </tr>\r\n                    </thead>\r\n\r\n                    <tbody>\r\n\r\n");
#nullable restore
#line 52 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                         foreach (var item in Model)
                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 57 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 60 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 63 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                               Write(Html.DisplayFor(modelItem => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 66 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Salary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 69 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Position));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 73 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n\r\n                </table>\r\n                <hr />\r\n                <br />\r\n                <div style=\"text-align:center; color:darkorchid; font-size:20px;\">\r\n                    Sum Of Salary = ");
#nullable restore
#line 80 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Employees\SalaryReportAcc.cshtml"
                               Write(ViewBag.SumSalary);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TheTopWebsite.Models.Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
