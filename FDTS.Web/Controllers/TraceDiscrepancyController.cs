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
    public class TraceDiscrepancyController : Controller
    {
        private TraceDiscrepancyViewModel viewModel = new TraceDiscrepancyViewModel();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TraceDiscrepancyGridViewPartial(int? TraceTransactionId, string MasterGridName)
        {
            var model = viewModel.TraceDiscrepancies.Where(m => m.TraceTransactions.Id == TraceTransactionId);
            ViewBag.TraceTransactionId = TraceTransactionId;
            ViewBag.MasterGridName = MasterGridName;
            return PartialView("_TraceDiscrepancyGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TraceDiscrepancyGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.TraceDiscrepancies item, int? TraceTransactionId, string MasterGridName)
        {
            var model = viewModel.TraceDiscrepancies.Where(m => m.TraceTransactions.Id == TraceTransactionId);
            ViewBag.TraceTransactionId = TraceTransactionId;
            ViewBag.MasterGridName = MasterGridName;
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model


                    unitOfWork.TraceDiscrepanciesRepo.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_TraceDiscrepancyGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TraceDiscrepancyGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.TraceDiscrepancies item, int? TraceTransactionId, string MasterGridName)
        {
            var model = viewModel.TraceDiscrepancies.Where(m => m.TraceTransactions.Id == TraceTransactionId);
            ViewBag.TraceTransactionId = TraceTransactionId;
            ViewBag.MasterGridName = MasterGridName;
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_TraceDiscrepancyGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TraceDiscrepancyGridViewPartialDelete(System.Int32 Id, int? TraceTransactionId, string MasterGridName)
        {
            var model = viewModel.TraceDiscrepancies.Where(m => m.TraceTransactions.Id == TraceTransactionId);
            ViewBag.TraceTransactionId = TraceTransactionId;
            ViewBag.MasterGridName = MasterGridName;
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_TraceDiscrepancyGridViewPartial", model);
        }


        private UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult AddEditTraceDescriptionPartial(int? discrepancyDescriptionId,string gridName)
        {
            var model = unitOfWork.TraceDiscrepanciesRepo.Find(m => m.Id == discrepancyDescriptionId);
            ViewBag.GridName = gridName;
            return PartialView("AddEditTraceDescriptionPartial", model);
        }
    }
}