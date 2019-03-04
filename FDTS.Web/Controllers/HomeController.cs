using System;
using DevExpress.Web.Mvc;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;
using BarcodeLib;
using FDTS.Models.Repository;
using FDTS.Models.ViewModels;
using System.Linq;
namespace FDTS.Web.Controllers
{
    [Authorize]
    public class HomeController : IdentityController
    {
        public ActionResult Index()
        {


            return View();
        }

        private UnitOfWork unitOfWork = new UnitOfWork();

        [ValidateInput(false)]
        public ActionResult OutgoingGridViewPartial()
        {
            var model = unitOfWork.TraceDocumentsRepo.Fetch(m => m.TraceTransactions.Any(x => x.isReceived == false && x.isTransmit == false && x.ReceivingDepartmentId == DepartmentId)).OrderByDescending(m => m.Id).ToList();
            return PartialView("_OutgoingGridViewPartial", model);
        }
        [ValidateInput(false)]
        public ActionResult ReceivingGridViewPartial()
        {
            var model = unitOfWork.TraceDocumentsRepo.Fetch(m => m.TraceTransactions.Any(x => x.isReceived == true && x.isTransmit == false && x.ReceivingDepartmentId == DepartmentId)).OrderByDescending(m => m.Id).ToList();
            return PartialView("_ReceivingGridViewPartial", model);
        }

    }
}