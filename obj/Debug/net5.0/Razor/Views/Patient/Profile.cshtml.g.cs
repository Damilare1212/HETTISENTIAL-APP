#pragma checksum "C:\Users\hp\Documents\HettisentialMvcold\Views\Patient\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6af55ad702311d0585bb9f98d6c08347581f15ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Patient_Profile), @"mvc.1.0.view", @"/Views/Patient/Profile.cshtml")]
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
#line 1 "C:\Users\hp\Documents\HettisentialMvcold\Views\_ViewImports.cshtml"
using HettisentialMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hp\Documents\HettisentialMvcold\Views\_ViewImports.cshtml"
using HettisentialMvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6af55ad702311d0585bb9f98d6c08347581f15ae", @"/Views/Patient/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3793a18020ed73124ee9afe99f088d7e9ddcbe4d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Patient_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HettisentialMvc.PatientDto>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 100px; height: 100px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Patient", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n  <main id=\"main\" class=\"main\">\r\n\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6af55ad702311d0585bb9f98d6c08347581f15ae5146", async() => {
                WriteLiteral(@"
 <div class=""pagetitle"">
    <h1>Profile</h1>
    <nav>
      <ol class=""breadcrumb"">
        <li class=""breadcrumb-item""><a href=""index.html"">Home</a></li>
        <li class=""breadcrumb-item"">Users</li>
        <li class=""breadcrumb-item active"">Profile</li>
      </ol>
    </nav>
  </div><!-- End Page Title -->

  <section class=""section profile"">
    <div class=""row"">
      <div class=""col-xl-4"">

        <div class=""card"">
          <div class=""card-body profile-card pt-4 d-flex flex-column align-items-center"">           
            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6af55ad702311d0585bb9f98d6c08347581f15ae5986", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 780, "~/PatientImages/", 780, 16, true);
#nullable restore
#line 29 "C:\Users\hp\Documents\HettisentialMvcold\Views\Patient\Profile.cshtml"
AddHtmlAttributeValue("", 796, Model.Image, 796, 12, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <h2>");
#nullable restore
#line 30 "C:\Users\hp\Documents\HettisentialMvcold\Views\Patient\Profile.cshtml"
           Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h2>            
            <h5><span>Patient</span></h5>
            <div class=""social-links mt-2"">
              <a href=""#"" class=""twitter""><i class=""bi bi-twitter""></i></a>
              <a href=""#"" class=""facebook""><i class=""bi bi-facebook""></i></a>
              <a href=""#"" class=""instagram""><i class=""bi bi-instagram""></i></a>
              <a href=""#"" class=""linkedin""><i class=""bi bi-linkedin""></i></a>
            </div>
          </div>
        </div>

      </div>

      <div class=""col-xl-8"">

        <div class=""card"">
          <div class=""card-body pt-3"">
            <!-- Bordered Tabs -->
            <ul class=""nav nav-tabs nav-tabs-bordered"">

              <li class=""nav-item"">
                <button class=""nav-link active"" data-bs-toggle=""tab""
                  data-bs-target=""#profile-overview"">Overview</button>
              </li>

              <li class=""nav-item"">
                <button class=""nav-link"" data-bs-toggle=""tab"" data-bs-target=""#profile-edit"">Ed");
                WriteLiteral(@"it Profile</button>
              </li>

              <li class=""nav-item"">
                <button class=""nav-link"" data-bs-toggle=""tab"" data-bs-target=""#profile-settings"">Settings</button>
              </li>

              <li class=""nav-item"">
                <button class=""nav-link"" data-bs-toggle=""tab"" data-bs-target=""#profile-change-password"">Change
                  Password</button>
              </li>

            </ul>
            <div class=""tab-content pt-2"">

              <div class=""tab-pane fade show active profile-overview"" id=""profile-overview"">
                <h5 class=""card-title"">About</h5>
                <p class=""small fst-italic"">Dear Patient, You are welcome to your dashboard, as a user of this application
                     you are hereby implored to keep visiting your dashboard frequently as your complain will be welcome any 
                     time it arises so as to receive doctor's attention. Finally, your details are underlisted below</p>

          ");
                WriteLiteral(@"      <h5 class=""card-title"">Profile Details</h5>

                <div class=""card"">
                  <div class=""card-body"">
                    <h5 class=""card-title""></h5>

                    <!-- List group with active and disabled items -->
                    <ul class=""list-group"">
                      <li class=""list-group-item active"" aria-current=""true"">PERSONAL DETAILS</li>
                      <li class=""list-group-item""><b>  Fullname: </b> ");
#nullable restore
#line 86 "C:\Users\hp\Documents\HettisentialMvcold\Views\Patient\Profile.cshtml"
                                                                 Write(Model.Fullname);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n");
                WriteLiteral("                      <li class=\"list-group-item\"><b>GENDER: </b> ");
#nullable restore
#line 88 "C:\Users\hp\Documents\HettisentialMvcold\Views\Patient\Profile.cshtml"
                                                             Write(Model.Gender);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                      <li class=\"list-group-item\"><b>EMAIL: </b> ");
#nullable restore
#line 89 "C:\Users\hp\Documents\HettisentialMvcold\Views\Patient\Profile.cshtml"
                                                            Write(Model.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                      <li class=\"list-group-item\"><b>ADDRESS: </b> ");
#nullable restore
#line 90 "C:\Users\hp\Documents\HettisentialMvcold\Views\Patient\Profile.cshtml"
                                                              Write(Model.Address);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                      <li class=\"list-group-item\"><b>  UserName: </b> ");
#nullable restore
#line 91 "C:\Users\hp\Documents\HettisentialMvcold\Views\Patient\Profile.cshtml"
                                                                 Write(Model.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                      <li class=\"list-group-item\"><b>DATE OF BIRTH: </b> ");
#nullable restore
#line 92 "C:\Users\hp\Documents\HettisentialMvcold\Views\Patient\Profile.cshtml"
                                                                    Write(Model.DateOfBirth);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n");
                WriteLiteral(@"                      <li class=""list-group-item"" aria-disabled=""true"">
                      </li>
                    </ul><!-- End ist group with active and disabled items -->

                  </div>
                </div>           

              </div>
            
            </div>
          </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n \r\n\r\n        </div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HettisentialMvc.PatientDto> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591