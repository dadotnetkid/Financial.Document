using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDTS.Models;
using FDTS.Models.Repository;
using FDTS.Models.ViewModels;

namespace FDTS.Web.Controllers
{
    public class DocumentAttachmentController : Controller
    {
        private DocumentAttachmentViewModel viewModel = new DocumentAttachmentViewModel();
        UnitOfWork unitOfWork = new UnitOfWork();
        [Route("maintenance/workflow/attachment-types")]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult DocumentAttachmentGridViewPartial()
        {
            var model = viewModel;
            return PartialView("_DocumentAttachmentGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DocumentAttachmentGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.DocumentAttachments item)
        {
            var model = viewModel;
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.AddNew(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_DocumentAttachmentGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DocumentAttachmentGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.DocumentAttachments item)
        {
            var model = viewModel;
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.Update(item);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_DocumentAttachmentGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DocumentAttachmentGridViewPartialDelete(int? Id)
        {
            var model = viewModel;
            if (Id >= 0)
            {
                try
                {
                    viewModel.Delete(m => m.Id == Id);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_DocumentAttachmentGridViewPartial", model);
        }


        public ActionResult AddEditDocumentAttachmentPartial([ModelBinder(typeof(DevExpressEditorsBinder))]int? documentAttachmentId)
        {
            var model = unitOfWork.DocumentAttachmentsRepo.Find(m => m.Id == documentAttachmentId);
            ViewBag.Departments= new DepartmentViewModel().Departments;
            return PartialView("_AddEditDocumentAttachmentPartial", model);
        }


        public ActionResult cboDepartmentPartial(DocumentAttachments item)
        {
            ViewBag.Departments = new DepartmentViewModel().Departments;
            return PartialView("_cboDepartmentPartial", item);
        }

    }
}