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
    public class DepartmentController : Controller
    {
        private DepartmentViewModel viewModel = new DepartmentViewModel();

        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Department
        [Route("maintenance/departments")]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult DepartmentGridViewPartial()
        {
            
            return PartialView("_DepartmentGridViewPartial", viewModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DepartmentGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.Departments item)
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
            return PartialView("_DepartmentGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DepartmentGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] FDTS.Models.Departments item)
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
            return PartialView("_DepartmentGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DepartmentGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] int? Id)
        {
            var model = viewModel;
            if (Id >= 0)
            {
                try
                {
                    viewModel.Delete(m=>m.Id==Id);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_DepartmentGridViewPartial", model);
        }
    }
}