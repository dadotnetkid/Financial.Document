using DevExpress.Web.Mvc;
using FDTS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDTS.Models.Repository;

namespace FDTS.Web.Controllers
{
    public class TraceTransactionController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TraceTransactionGridViewPartial(int? TraceDocumentId)
        {
            var model = unitOfWork.TraceTransactionsRepo.Get(m => m.TraceDocumentId == TraceDocumentId,includeProperties: "ReceivingPersonnels,ReceivingPersonnels.Departments,Departments");

            ViewBag.TraceDocumentId = TraceDocumentId;

            return PartialView("_TraceTransactionGridViewPartial",model);
        }

        #region unUsed
        [HttpPost, ValidateInput(false)]
        public ActionResult TraceTransactionGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.TraceTransactions item, int? TraceDocumentId)
        {
            var model = new TraceTransactionViewModel().TraceTransactions.Where(m =>
                m.TraceTransaction.Id == TraceDocumentId);
            ViewBag.TraceDocumentId = TraceDocumentId;
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_TraceTransactionGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TraceTransactionGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.TraceTransactions item, int? TraceDocumentId)
        {
            var model = new TraceTransactionViewModel().TraceTransactions.Where(m =>
                m.TraceTransaction.Id == TraceDocumentId);
            ViewBag.TraceDocumentId = TraceDocumentId;
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
            return PartialView("_TraceTransactionGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TraceTransactionGridViewPartialDelete(System.Int32 Id, int? TraceDocumentId)
        {
            var model = new TraceTransactionViewModel().TraceTransactions.Where(m =>
                m.TraceTransaction.Id == TraceDocumentId);
            ViewBag.TraceDocumentId = TraceDocumentId;
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
            return PartialView("_TraceTransactionGridViewPartial", model);
        }


        #endregion
    }
}