using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FDTS.Models.ViewModels;
using FDTS.Helpers;
using FDTS.Models.Repository;

namespace FDTS.Web.Controllers
{
    public class ReceiveController : IdentityController
    {
        private TraceDocumentViewModel viewModel = new TraceDocumentViewModel();

        private UnitOfWork unitOfWork = new UnitOfWork();


        [Route("receive")]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult ReceivingGridViewPartial(int? traceTransactionId)
        {

            var res = unitOfWork.TraceTransactionsRepo.Find(m => m.Id == traceTransactionId);
            if (res != null)
            {
                res.isReceived = true;
                res.ReceivingPersonnelId = UserId;
                unitOfWork.Save();
            }


            var model = unitOfWork.TraceTransactionsRepo.Get(m => m.ReceivingDepartmentId == DepartmentId, includeProperties: "CreatedByUsers,ReceivingPersonnels");
            return PartialView("_ReceivingGridViewPartial", model);
        }

        public ActionResult ReceivingGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.TraceTransactions item, int? traceTransactionId)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model


                    if (item.TraceDocumentId != null)
                    {
                        var res = unitOfWork.TraceTransactionsRepo.Fetch(m => m.TraceDocumentId == item.TraceDocumentId && m.ReceivingDepartmentId == DepartmentId).OrderByDescending(m => m.Id).FirstOrDefault();
                        if (res != null)
                        {
                            res.ReceivingPersonnelId = UserId;
                            unitOfWork.Save();
                        }

                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.TraceTransactionsRepo.Get(m => m.ReceivingDepartmentId == DepartmentId, includeProperties: "CreatedByUsers,ReceivingPersonnels");
            return PartialView("_ReceivingGridViewPartial", model);
        }


        public ActionResult AddEditReceivePartial()
        {
            return PartialView();
        }



        #region Un used methods
        [HttpPost, ValidateInput(false)]
        public ActionResult ReceivingGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.TraceDocuments item)
        {
            var model = new object[0];
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
            return PartialView("_ReceivingGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ReceivingGridViewPartialDelete(System.Int32 Id)
        {
            var model = new object[0];
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
            return PartialView("_ReceivingGridViewPartial", model);
        }


        #endregion
    }
}