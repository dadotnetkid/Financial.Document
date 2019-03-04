using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace FDTS.Helpers
{

    public class Parameters
    {
        public object Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }



    }

    public static class HtmlHelpers
    {
        public static void ButtonSubmitCancel(this HtmlHelper htmlHelper, dynamic gridViewName, string btnSubmit = "Update", string btnCancel = "Cancel")
        {
            htmlHelper.RenderAction("btnSubmitCancelPartial", "Partials", new { gridViewName = gridViewName, btnSubmit = btnSubmit, btnCancel = btnCancel });
        }


        public static void ComboBoxDepartments(this HtmlHelper htmlHelper, int? departmentId, string cboName = null, string caption = "Department")
        {
            htmlHelper.RenderAction("cboDepartmentsPartial", "Partials", new { departmentId = departmentId, cboName = cboName, caption = caption });
        }

        public static void ComboBoxTraceDocuments(this HtmlHelper htmlHelper, int? traceDocumentId, string cboName = null, string caption = "Trace Document", string clientSideEvent = null)
        {
            htmlHelper.RenderAction("cboTraceDocumentPartial", "Partials", new { traceDocumentId = traceDocumentId, cboName = cboName, caption = caption, clientSideEvent = clientSideEvent });
        }


        public static void ComboBoxUsers(this HtmlHelper htmlHelper, string userId, string cboName = null, string caption = "Employee|User", string textField = "FullName", bool? clientSide = true)
        {
            htmlHelper.RenderAction("cboUsersPartial", "Partials", new { userId = userId, cboName = cboName, caption = caption, textField = textField, clientSide = clientSide });
        }

        public static void ComboBoxTowns(this HtmlHelper htmlHelper, int? townCityId, string cboName = null, string caption = "Town")
        {
            htmlHelper.RenderAction("cboTownCityPartial", "Partials", new { townCityId = townCityId, cboName = cboName, caption = caption });
        }
        public static void ComboBoxDiscrepancyDescription(this HtmlHelper htmlHelper, int? discrepancyDescriptionId, string cboName = null, string caption = "Discrepancy Description")
        {
            htmlHelper.RenderAction("cboDiscrepancyDescriptionPartial", "Partials", new { discrepancyDescriptionId = discrepancyDescriptionId, cboName = cboName, caption = caption });
        }
        public static void ComboBoxDocumentAttachment(this HtmlHelper htmlHelper, int? documentAttachmentId, string cboName = null, string caption = "Document Attachment")
        {
            htmlHelper.RenderAction("cboDocumentAttachmentPartial", "Partials", new { documentAttachmentId = documentAttachmentId, cboName = cboName, caption = caption });
        }


        public static void ComboBoxRequestType(this HtmlHelper htmlHelper, int? requestTypeId, string cboName = null, string caption = "Request Type")
        {
            htmlHelper.RenderAction("cboRequestTypePartial", "Partials", new { requestTypeId = requestTypeId, cboName = cboName, caption = caption });
        }

        public static void TokenBoxUserRoles(this HtmlHelper htmlHelper, string userId, string name = "userRole", string caption = "User Roles")
        {
            htmlHelper.RenderAction("TokenUserRolesPartial", "Partials", new { userId = userId, name = name, caption = caption });
        }



    }
}
