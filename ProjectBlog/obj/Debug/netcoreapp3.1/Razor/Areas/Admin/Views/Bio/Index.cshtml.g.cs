#pragma checksum "F:\.NET\ProjectBlog\ProjectBlog\Areas\Admin\Views\Bio\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "acc7c30ab38e6138b6350791537c46eac92fe01a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Bio_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Bio/Index.cshtml")]
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
#line 1 "F:\.NET\ProjectBlog\ProjectBlog\Areas\Admin\Views\_ViewImports.cshtml"
using ProjectBlog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\.NET\ProjectBlog\ProjectBlog\Areas\Admin\Views\_ViewImports.cshtml"
using ProjectBlog.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\.NET\ProjectBlog\ProjectBlog\Areas\Admin\Views\Bio\Index.cshtml"
using ProjectBlog.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acc7c30ab38e6138b6350791537c46eac92fe01a", @"/Areas/Admin/Views/Bio/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af9a5cfc54c5348b500cbfdf13d2819a4f4cd2ab", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Bio_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\.NET\ProjectBlog\ProjectBlog\Areas\Admin\Views\Bio\Index.cshtml"
  
    Layout = "_AdminLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "F:\.NET\ProjectBlog\ProjectBlog\Areas\Admin\Views\Bio\Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"col text-right\">\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 133, "\"", 170, 1);
#nullable restore
#line 10 "F:\.NET\ProjectBlog\ProjectBlog\Areas\Admin\Views\Bio\Index.cshtml"
WriteAttributeValue("", 140, Url.Action("AddBlog", "Blog"), 140, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary mb-3\">\r\n        Add Data\r\n    </a>\r\n</div>\r\n\r\n<table id=\"BioDatatable\" class=\"display\">\r\n</table>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"

    <script>
        $(document).ready(function () {
            var table = $('#BioDataTable').DataTable({
                paging: true, // Table pagination
                ordering: true, // Column ordering
                processing: true,
                info: true, // Bottom left status text
                responsive: true,
                serverSide: true,
                searching: true,
                dom: 'lrtip',
                ajax: {
                    url: ""/Admin/Bio/GetData"",
                    type: ""POST"",
                    headers: {
                        'RequestVerificationToken': $('input[name=""__RequestVerificationToken""]').val()
                    }
                },
                columns: [
                    {
                        data: 'Id',
                        title: 'ID',
                        visible: false
                    },
                    {
                        data: 'Name',
                        title: 'Name',
");
                WriteLiteral("                        visible: true,\r\n                        width: \'10%\'\r\n");
                WriteLiteral(@"                    },
                    {
                        data: 'Address',
                        title: 'Address',
                        visible: true,
                        width: '10%'
                    },
                    {
                        data: 'Nickname',
                        title: 'Nickname',
                        visible: true,
                        width: '10%',
                    },
                    {
                        data: 'Status',
                        title: 'Status',
                        visible: true,
                        width: '10%',
                    },
                    {
                        data: null,
                        title: 'Action',
                        width: '15%',
                        orderable: false
                    }
                ],
                order: [[1, ""desc""]],
                columnDefs: [{
                    targets: [-1], render: function (a, b, data, d) {
");
                WriteLiteral(@"                        return '<a href=""#"" class=""btn btn-act btn-sm btn-secondary"" act-type=""del""><em class=""fa fa-trash""></em> Delete</a>' + '&nbsp' +
                            (data.Status == 'Unpublished' ? '<a href=""#"" class=""btn btn-act btn-sm btn-secondary"" act-type=""publish""><em class=""fa fa-arrow-up""></em> Publish</a>' : '') +
                            (data.Status == 'Published' ? '<a href=""#"" class=""btn btn-act btn-sm btn-secondary"" act-type=""unpublish""><em class=""fa fa-arrow-down""></em> Unpublish</a>' : '');
                    }
                }],
                initComplete: function () {
                    $('#BioDataTable thead').append($('<tr id=""filter"">'));
                    //1: Title
                    let hName = $('<th>');
                    $('#filter').append(hName);
                    hName.append('<input type=""text"" placeholder=""Search Name"" name=""filter_1"" />');

                    //Address
                    let hAddress = $('<th>');
                 ");
                WriteLiteral(@"   $('#filter').append(hAddress);
                    hAddress.append('<input type=""text"" placeholder=""Search Address"" name=""filter_2"" />');

                    //Nickname
                    let hNickname = $('<th>');
                    $('#filter').append(hNickname);
                    hNickname.append('<input type=""text"" placeholder=""Search Nickname"" name=""filter_3"" />');

                    //3: Status
                    let hStatus = $('<th>');
                    $('#filter').append(hStatus);
                    hStatusControl = $('<select name=""filter_3""><select>');
                    hStatusControl.append($('<option>', { value: 'All', text: 'All' }));
                    hStatusControl.append($('<option>', { value: 'Unpublished', text: 'Unpublished' }));
                    hStatusControl.append($('<option>', { value: 'Published', text: 'Published' }));
                    hStatus.append(hStatusControl);

                    $('[name^=date_filter_]').on('change', function () {
");
                WriteLiteral(@"                        let names = this.name.split('_');
                        let pos = names[names.length - 2];
                        let idx = names[names.length - 1];
                        let startDate, endDate
                        if (pos === 'start') {
                            startDate = this.value
                            endDate = $(`[name=date_filter_end_${idx}]`).val()
                        } else {
                            startDate = $(`[name=date_filter_start_${idx}]`).val()
                            endDate = this.value
                        }
                        let searchVal = `${startDate}|${endDate}`
                        if (table.column(idx).search() !== searchVal) {
                            table.column(idx).search(searchVal).draw();
                        }
                    });

                    $('[name^=filter_]').on('keyup change', function () {
                        let names = this.name.split('_');
                     ");
                WriteLiteral(@"   let idx = names[names.length - 1];
                        if (table.column(idx).search() !== this.value) {
                            table.column(idx).search(this.value).draw();
                        }
                    });

                    //5: Action
                    let hAction = $('<th>');
                    $('#filter').append(hAction);
                }
            });
            let confirmSwal = {
                title: ""Are you sure?"",
                icon: 'warning',
                buttons: {
                    yes: {
                        text: 'Yes',
                        value: true
                    },
                    cancel: 'No'
                }
            };

");
                WriteLiteral("        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
