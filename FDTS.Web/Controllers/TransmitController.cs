using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using FDTS.Models.Repository;

namespace FDTS.Web.Controllers
{
    public class TransmitController : IdentityController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        [Route("transmit")]
        public ActionResult Index()
        {
            return View();
        }

        #region Grid
        [ValidateInput(false)]
        public ActionResult TransmitGridViewPartial()
        {
            var model = unitOfWork.TraceTransactionsRepo.Get(m => m.CreatedBy == UserId,includeProperties: "ReceivingPersonnels,CreatedByUsers");
            return PartialView("_TransmitGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TransmitGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.TraceTransactions item)
        {

            if (ModelState.IsValid)
            {
                try
                {


                    var transaction = unitOfWork.TraceTransactionsRepo.Fetch(m => m.TraceDocumentId == item.TraceDocumentId && m.ReceivingDepartmentId == DepartmentId).OrderByDescending(m => m.Id).FirstOrDefault();
                    if (transaction != null)
                        transaction.isTransmit = true;


                    item.isReceived = false;
                    item.TraceDate = DateTime.Now;
                    item.CreatedBy = UserId;
                    unitOfWork.TraceTransactionsRepo.Insert(item);
                    unitOfWork.Save();

                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.TraceTransactionsRepo.Get(m => m.CreatedBy == UserId && m.isReceived == false, includeProperties: "Departments,TraceDocuments,ReceivingPersonnels,CreatedByUsers");
            return PartialView("_TransmitGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TransmitGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.TraceTransactions item)
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
            return PartialView("_TransmitGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TransmitGridViewPartialDelete(System.Int32 Id)
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
            return PartialView("_TransmitGridViewPartial", model);
        }


        #endregion



        public ActionResult cbpAddEditTransmitPartial(int? traceDocumentId)
        {

            var model = unitOfWork.TraceDocumentsRepo.Find(m => m.Id == traceDocumentId);
            return PartialView("cbpAddEditTransmitPartial", model);
        }

        public ActionResult ReceiveLiasonPartial(int? traceTransactionid, int? receivingPersonnelId)
        {

            var model = unitOfWork.TraceTransactionsRepo.Find(m => m.Id == traceTransactionid);
            if (receivingPersonnelId != null)
            {

                model.ReceivingPersonnelId = unitOfWork.UsersRepo.Find(m => m.EmployeeId == receivingPersonnelId)?.Id;
                model.isReceived = true;
                unitOfWork.Save();
            }


            return PartialView("ReceiveLiasonPartial", model);
        }
        [HttpPost]
        public JsonResult CheckEmployeeId([ModelBinder(typeof(DevExpressEditorsBinder))]int? employeeId)
        {
            return Json(unitOfWork.UsersRepo.Fetch(m => m.EmployeeId == employeeId).Any(),
                JsonRequestBehavior.AllowGet);
        }
    }
}




/*
                    * var res = unitOfWork.TraceDocumentsRepo.Find(m => m.Id == item.TraceDocumentId);


                   if (res.TraceTransactions.Any())
                   {
                       var traceDiscrepancy = new Models.TraceDiscrepancies();

                       traceDiscrepancy.TraceTransactionId = Request.Params["TraceTransactionId"] == null
                           ? (int?)null
                           : Convert.ToInt32(Request.Params["TraceTransactionId"]);

                       traceDiscrepancy.DocumentAttachmentId = Request.Params["DocumentAttachmentId"] == null
                           ? (int?)null
                           : Convert.ToInt32(Request.Params["DocumentAttachmentId"]);
                       traceDiscrepancy.DiscrepancyDescriptionId = Request.Params["DiscrepancyDescriptionId"] == null
                           ? (int?)null
                           : Convert.ToInt32(Request.Params["DiscrepancyDescriptionId"]);

                       traceDiscrepancy.DiscrepancyNotes = Request.Params["DiscrepancyNotes"];

                       item.TraceDiscrepancies.Add(traceDiscrepancy);
                       res.TraceTransactions.Add(item);
                       unitOfWork.Save();
                   }
                   else
                   {

                       unitOfWork.TraceTransactionsRepo.Insert(item);
                       unitOfWork.Save();
                   }
                    */
