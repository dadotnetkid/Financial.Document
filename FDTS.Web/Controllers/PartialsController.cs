using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDTS.Models;
using FDTS.Models.Repository;

namespace FDTS.Web.Controllers
{
    public class PartialsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult cboUsersPartial(string userId, string cboName = null, string caption = "Employee|Users",string textField="FullName",bool? clientSide=true)
        {
            ViewBag.UserId = userId;
            ViewBag.caption = caption;
            ViewBag.cboName = cboName;
            ViewBag.textField = textField;
            ViewBag.clientSide = clientSide;
            ViewBag.Users = new UnitOfWork().UsersRepo.Fetch().OrderBy(m => m.Id);
            var model = unitOfWork.UsersRepo.Find(m => m.Id == userId);
            return PartialView("cboUsersPartial", model);
        }

        public ActionResult cboDepartmentsPartial(int? departmentId, string cboName = null, string caption = "Department")
        {
            var model = unitOfWork.DepartmentsRepo.Find(m => m.Id == departmentId);
            ViewBag.Departments = new UnitOfWork().DepartmentsRepo.Fetch().OrderBy(m => m.Id);
            ViewBag.cboName = cboName;
            ViewBag.caption = caption;
            return PartialView("cboDepartmentsPartial", model);
        }

        public ActionResult cboTraceDocumentPartial(int? traceDocumentId, string cboName = null, string caption = "Trace Document")
        {
            var model = unitOfWork.TraceDocumentsRepo.Find(m => m.Id == traceDocumentId);
            ViewBag.TraceDocuments = new UnitOfWork().TraceDocumentsRepo.Fetch().OrderBy(m => m.Id);
            ViewBag.cboName = cboName;
            ViewBag.caption = caption;
            return PartialView("cboTraceDocumentPartial", model);
        }

        public ActionResult cboDiscrepancyDescriptionPartial(int? discrepencyDescriptionId, string cboName = null, string caption = "Descripancy Description")
        {
            var model = unitOfWork.DiscrepancyDescriptionsRepo.Find(m => m.Id == discrepencyDescriptionId);
            ViewBag.DiscrepancyDescriptions = new UnitOfWork().DiscrepancyDescriptionsRepo.Fetch().OrderBy(m => m.Id);
            ViewBag.cboName = cboName;
            ViewBag.caption = caption;
            return PartialView("cboDiscrepancyDescriptionPartial", model);
        }


        public ActionResult cboDocumentAttachmentPartial(int? documentAttachmentId, string cboName = null, string caption = "Document Attachment")
        {
            var model = unitOfWork.DocumentAttachmentsRepo.Find(m => m.Id == documentAttachmentId);
            ViewBag.DocumentAttachments = new UnitOfWork().DocumentAttachmentsRepo.Fetch().OrderBy(m => m.Id);
            ViewBag.cboName = cboName;
            ViewBag.caption = caption;
            return PartialView("cboDocumentAttachmentPartial", model);
        }

      



        public ActionResult TokenUserRolesPartial(string userId, string name = "UserRole", string caption = "User Roles")
        {
            ViewBag.UserRoles = unitOfWork.UsersRepo.Find(m => m.Id == userId)?.UserRoles;
            ViewBag.caption = caption;
            return PartialView("TokenUserRolesPartial", unitOfWork.UserRolesRepo.Get());
        }
        public ActionResult cboTownCityPartial(int? TownCityId, string cboName = null, string caption = "Trace Document")
        {
            ViewBag.AddressTownCities = unitOfWork.AddressTownCitiesRepo.Get();
            ViewBag.caption = caption;
            ViewBag.cboName = cboName;



            if (TownCityId == null)
                return PartialView("cboTownCityPartial", new AddressTownCities());
            else
                return PartialView("cboTownCityPartial", new AddressTownCities() { TownCityId = TownCityId.Value });
        }

        public ActionResult btnSubmitCancelPartial(string gridViewName,string btnSubmit="Update",string btnCancel="Cancel")
        {
            ViewBag.GridviewName = gridViewName;
            ViewBag.btnSubmit = btnSubmit;
            ViewBag.btnCancel = btnCancel;
            return PartialView("btnSubmitCancelPartial");
        }

        public ActionResult cboRequestTypePartial(int? requestTypeId, string cboName = null, string caption = "Request Type")
        {
            ViewBag.caption = caption;
            ViewBag.cboName = cboName;
            var model = unitOfWork.RequestTypesRepo.Find(m => m.Id == requestTypeId);
            ViewBag.RequestTypes = unitOfWork.RequestTypesRepo.Fetch().OrderBy(m => m.Id);
            ViewBag.cboName = cboName;
            ViewBag.caption = caption;
            return PartialView("cboRequestTypePartial", model);
        }
    }
}