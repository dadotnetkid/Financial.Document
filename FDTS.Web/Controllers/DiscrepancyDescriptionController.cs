using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDTS.Models.Repository;
using FDTS.Models.ViewModels;

namespace FDTS.Web.Controllers
{
    public class DiscrepancyDescriptionController : Controller
    {
        private DiscrepancyDescriptionViewModel viewModel = new DiscrepancyDescriptionViewModel();
        private UnitOfWork unitOfWork = new UnitOfWork();



        [Route("maintenance/workflow/discrepancy-list")]
        public ActionResult Index()
        {
            return View();
        }

        #region Grid

        [ValidateInput(false)]
        public ActionResult DiscrepencyDescriptionPartial()
        {
            var model = viewModel;
            return PartialView("_DiscrepencyDescriptionPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DiscrepencyDescriptionPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.DiscrepancyDescriptions item)
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
            return PartialView("_DiscrepencyDescriptionPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DiscrepencyDescriptionPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.DiscrepancyDescriptions item)
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
            return PartialView("_DiscrepencyDescriptionPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DiscrepencyDescriptionPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] System.Int32 Id)
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
            return PartialView("_DiscrepencyDescriptionPartial", model);
        }



        #endregion


        public ActionResult AddEditDiscrepancyDescriptionPartial([ModelBinder(typeof(DevExpressEditorsBinder))] int? discrepancyDescriptionId)
        {
            var model = unitOfWork.DiscrepancyDescriptionsRepo.Find(m => m.Id == discrepancyDescriptionId);
            return PartialView("_AddEditDiscrepancyDescriptionPartial", model);
        }
    }
}