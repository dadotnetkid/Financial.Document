using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web;
using FDTS.Models.Repository;
using FDTS.Models.ViewModels;

namespace FDTS.Web.Controllers
{
    public class TraceDocumentController : IdentityController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private TraceDocumentViewModel viewModel = new TraceDocumentViewModel();
        [Route("trace-document")]
        public ActionResult Index()
        {
            return View();
        }

        #region Grid

        [ValidateInput(false)]
        public ActionResult TraceDocumentGridViewPartial(bool? isGenerateNewDocumentId)
        {

            return PartialView("_TraceDocumentGridViewPartial", viewModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TraceDocumentGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.TraceDocuments item)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (Session["Upload"] != null)
                    {
                        var uploadedFile = Session["Upload"] as UploadedFile;
                        item.Upload = uploadedFile.FileBytes;
                        viewModel.AddNew(item);
                    }
                    else
                    {
                        ViewData["EditError"] = "Please, correct all errors.";
                        ViewData["Model"] = item;
                    }

                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                    ViewData["Model"] = item;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_TraceDocumentGridViewPartial", viewModel);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TraceDocumentGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.TraceDocuments item)
        {
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
            return PartialView("_TraceDocumentGridViewPartial");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TraceDocumentGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))]int? Id)
        {
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
            return PartialView("_TraceDocumentGridViewPartial", viewModel);
        }

        #endregion

        public ActionResult AddEditTraceDocumentPartial(int? TraceDocumentId)
        {
            var model = unitOfWork.TraceDocumentsRepo.Find(m => m.Id == TraceDocumentId);
            return PartialView("AddEditTraceDocumentPartial", model);
        }

        public ActionResult PrintTraceDocumentPartial(int? traceDocumentId)
        {
            var model = unitOfWork.TraceDocumentsRepo.Get(m => m.Id == traceDocumentId);
            var barcodeReport = new BarcodeReport()
            {
                DataSource = model
            };
            return PartialView("PrintTraceDocumentPartial", barcodeReport);
        }

        public ActionResult UploadControlUpload()
        {
         UploadControlExtension.GetUploadedFiles("UploadControl", TraceDocumentControllerUploadControlSettings.UploadValidationSettings, TraceDocumentControllerUploadControlSettings.FileUploadComplete);
            return null;
        }
    }
    public class TraceDocumentControllerUploadControlSettings
    {
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".pdf", ".png", ".bmp", ".raw" },
            MaxFileSize = 4000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
                HttpContext.Current.Session["Upload"] = e.UploadedFile;
            }
        }
    }

}