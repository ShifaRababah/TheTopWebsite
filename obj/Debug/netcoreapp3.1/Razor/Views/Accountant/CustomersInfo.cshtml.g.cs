#pragma checksum "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Accountant\CustomersInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "954d8ea21aa264453911be2b227aa20dd1b5861e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Accountant_CustomersInfo), @"mvc.1.0.view", @"/Views/Accountant/CustomersInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"954d8ea21aa264453911be2b227aa20dd1b5861e", @"/Views/Accountant/CustomersInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0033c8a9a3c1208f9b51f992daceb3fd3bd5460a", @"/Views/_ViewImports.cshtml")]
    public class Views_Accountant_CustomersInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Customer>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Accountant\CustomersInfo.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutAccountant.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Accountant\CustomersInfo.cshtml"
  
    ViewData["Title"] = "CustomersInfo";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"<div class=""col-md-12"">
    <div class=""card"">
        <div class=""card-header card-header-primary"">
            <h4 class=""card-title "">Information about Customers</h4>
            <p class=""card-category""> Here is a Customers contact information</p>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table"">
                    <thead class="" text-primary"">
                        <tr>
                            <th>
                                Name
                            </th>
                            <th>
                                Email
                            </th>
                            <th>
                                Phone Number
                            </th>
                           
                        </tr>
                    </thead>
                   
                    <tbody>

");
#nullable restore
#line 38 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Accountant\CustomersInfo.cshtml"
                         foreach (var item in Model)
                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 43 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Accountant\CustomersInfo.cshtml"
                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 46 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Accountant\CustomersInfo.cshtml"
                               Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
#nullable restore
#line 50 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Accountant\CustomersInfo.cshtml"
                               Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                               \r\n                            </tr>\r\n");
#nullable restore
#line 54 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Accountant\CustomersInfo.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    \r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Customer>> Html { get; private set; }
    }
}
#pragma warning restore 1591
