#pragma checksum "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d189b3e021d91cd0fe605099cef78e279f491d1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Index___Copy), @"mvc.1.0.view", @"/Views/Orders/Index - Copy.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d189b3e021d91cd0fe605099cef78e279f491d1f", @"/Views/Orders/Index - Copy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0033c8a9a3c1208f9b51f992daceb3fd3bd5460a", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Index___Copy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TheTopWebsite.Models.Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateDate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"



<div class=""col-md-12"">
    <div class=""card"">
        <div class=""card-header card-header-primary"">
            <h4 class=""card-title "">Sells Reports</h4>
            <p class=""card-category""> Here is a Profits Reports for Sells </p>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d189b3e021d91cd0fe605099cef78e279f491d1f4569", async() => {
                WriteLiteral("\r\n                <input type=\"date\" name=\"Start\" />\r\n                <input type=\"date\" name=\"End\" />\r\n                <input type=\"submit\" />\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table"">
                    <thead class="" text-primary"">
                        <tr>
                            <th>
                                ");
#nullable restore
#line 29 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml"
                           Write(Html.DisplayNameFor(model => model.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 32 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml"
                           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 35 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml"
                           Write(Html.DisplayNameFor(model => model.Profit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 38 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml"
                           Write(Html.DisplayNameFor(model => model.Customer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n\r\n                        </tr>\r\n                    </thead>\r\n\r\n                    <tbody>\r\n\r\n");
#nullable restore
#line 46 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml"
                         foreach (var item in Model)
                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 51 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 54 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 57 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Profit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 60 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Customer.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 64 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                   \r\n                </table>\r\n                <hr />\r\n                <br />\r\n                <div style=\"text-align:center; color:darkorchid; font-size:20px;\">\r\n                    Sum Of Profit = ");
#nullable restore
#line 71 "C:\Users\user\Desktop\Tahaluf Training\First Project\LastCopy TheTop\TheTopWebsite\Views\Orders\Index - Copy.cshtml"
                               Write(ViewBag.SumProfit);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TheTopWebsite.Models.Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591