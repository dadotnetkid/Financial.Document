using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using FDTS.Models;
using FDTS.Models.Repository;
using Microsoft.AspNet.Identity;

namespace FDTS.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MaintenanceController : IdentityController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public MaintenanceController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }

        #region TownCity
        [Route("maintenance/town-cities")]
        public ActionResult TownCity()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult TownCityGridPartial()
        {
            ViewBag.States = unitOfWork.AddressStateProvincesRepo.Get().Select(x => new { Id = x.StateProvinceId, Name = x.Name }).OrderBy(x => x.Name);
            var model = unitOfWork.AddressTownCitiesRepo.Get(includeProperties: "AddressStateProvinces");
            return PartialView("_TownCityGridPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TownCityGridPartialAddNew(AddressTownCities item)
        {
            var model = new object[0];
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
            return PartialView("_TownCityGridPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TownCityGridPartialUpdate(AddressTownCities item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.AddressTownCitiesRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_TownCityGridPartial", unitOfWork.AddressTownCitiesRepo.Get(includeProperties: "AddressStateProvinces"));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TownCityGridPartialDelete(System.Int32 TownCityId)
        {
            var model = new object[0];
            if (TownCityId >= 0)
            {
                try
                {
                    AddressTownCities addressTownCity = unitOfWork.AddressTownCitiesRepo.GetByID(TownCityId);
                    unitOfWork.AddressTownCitiesRepo.Delete(TownCityId);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_TownCityGridPartial", model);
        }
        #endregion
        #region User



        [Route("maintenance/users")]
        public ActionResult Users()
        {
            //foreach (var i in new DummyAgentSeederHelper().GenerateAgent())
            //{
            //    var res = UserManager.Create(i, "123321");
            //    if (res.Succeeded)
            //        UserManager.AddToRole(i.Id, "Agent");

            //}
            return View();
        }

        [ValidateInput(false)]
        public ActionResult UserGridViewPartial()
        {

            return PartialView("_UserGridViewPartial", unitOfWork.UsersRepo.Get(includeProperties: "UserRoles"));
        }

        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> UserGridViewPartialAddNew(Users item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    item.Id = Guid.NewGuid().ToString();
                    item.UserName = item.Email.Split('@')[0];
                    var res = await UserManager.CreateAsync(item, item.Password);
                    if (res.Succeeded)
                    {



                        await UserManager.AddToRoleAsync(item.Id, item.userRole);

                        await unitOfWork.SaveAsync();
                    }
                    else
                    {
                        ViewData["model"] = item;
                        ViewData["EditError"] = string.Join(Environment.NewLine, res.Errors);
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var m in ModelState)
                {
                    if (m.Value.Errors.Any())
                    {
                        ModelState.AddModelError(m.Key, string.Join(Environment.NewLine, m.Value.Errors.Select(x => x.ErrorMessage)));
                        stringBuilder.AppendLine(m.Value.Errors[0].ErrorMessage);
                    }
                }
                ViewData["EditError"] = "Please, correct all errors." + Environment.NewLine + stringBuilder.ToString();
                ViewData["Model"] = item;
            }

            return PartialView("_UserGridViewPartial", unitOfWork.UsersRepo.Get(includeProperties: "UserRoles,Departments"));
        }
        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> UserGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))]Users item)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    var user = await UserManager.FindByIdAsync(item.Id);
                    user.FirstName = item.FirstName;
                    user.LastName = item.LastName;
                    user.MiddleName = item.MiddleName;
                    user.Gender = item.Gender;
                    user.TownCityId = item.TownCityId;

                    user.Email = item.Email;
                    user.UserName = item.Email.Split('@')[0];
                    user.BiometricId = item.BiometricId;
                    user.DepartmentId = item.DepartmentId ?? user.DepartmentId;

                    await UserManager.UpdateAsync(user);

                    #region UpdateRole
                    /* var roles = await UserManager.GetRolesAsync(user.Id);
                     await UserManager.RemoveFromRolesAsync(user.Id, roles.ToArray());
                     await UserManager.AddToRoleAsync(user.Id, item.userRole);*/
                    #endregion

                    if (item.Password != null)
                    {
                        var token = await UserManager.GeneratePasswordResetTokenAsync(item.Id);
                        var res = await UserManager.ResetPasswordAsync(item.Id, token, item.Password);
#if DEBUG
                        if (!res.Succeeded)
                        {
                            Debug.WriteLine(string.Join(",", res.Errors));
                        }
#endif
                    }


                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var m in ModelState)
                {
                    if (m.Value.Errors.Any())
                    {
                        ModelState.AddModelError(m.Key, string.Join(Environment.NewLine, m.Value.Errors.Select(x => x.ErrorMessage)));
                        stringBuilder.AppendLine(m.Value.Errors[0].ErrorMessage);
                    }
                }
                ViewData["EditError"] = "Please, correct all errors." + Environment.NewLine + stringBuilder.ToString();
                ViewData["Model"] = item;
            }

            return PartialView("_UserGridViewPartial", unitOfWork.UsersRepo.Get(includeProperties: "UserRoles,Departments"));
        }
        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> UserGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))]Users item)
        {
            if (item.Id != null)
            {
                try
                {

                    unitOfWork.UsersRepo.Delete(m => m.Id == item.Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_UserGridViewPartial", unitOfWork.UsersRepo.Get(includeProperties: "UserRoles,Departments"));
        }
        [ChildActionOnly]
        public ActionResult UserAddEditPartial(Users item)
        {
            var user = UserManager.FindById(item.Id);
            if (user != null)
            {
                // user.userRole = user.UserRoles.FirstOrDefault() == null ? "" : user.UserRoles.FirstOrDefault().Name;

            }
            ViewBag.TownCity = new UnitOfWork().AddressTownCitiesRepo.Get();
            return PartialView("_useraddeditpartial", user);
        }




        #endregion
        #region User Role
        [Route("maintenance/user-roles")]
        public ActionResult UserRoles()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult UserRolesGridViewPartial()
        {

            return PartialView("_UserRolesGridViewPartial", unitOfWork.UserRolesRepo.Get());
        }

        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> UserRolesGridViewPartialAddNew(UserRoles item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    item.Id = Guid.NewGuid().ToString();
                    unitOfWork.UserRolesRepo.Insert(item);
                    await unitOfWork.SaveAsync();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                foreach (var i in ModelState)
                {
                    if (i.Value.Errors.Any())
                    {
                        ModelState.AddModelError(i.Key, string.Join(Environment.NewLine, i.Value.Errors));
                    }
                }
                ViewData["EditError"] = "Please, correct all errors.";
                ViewData["model"] = item;
            }

            return PartialView("_UserRolesGridViewPartial", await unitOfWork.UserRolesRepo.GetAsync());
        }
        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> UserRolesGridViewPartialUpdate(UserRoles item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.UserRolesRepo.Update(item);
                    await unitOfWork.SaveAsync();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
            {
                foreach (var i in ModelState)
                {
                    if (i.Value.Errors.Any())
                    {
                        ModelState.AddModelError(i.Key, string.Join(Environment.NewLine, i.Value.Errors));
                    }
                }
                ViewData["EditError"] = "Please, correct all errors.";
                ViewData["model"] = item;
            }
            return PartialView("_UserRolesGridViewPartial", await unitOfWork.UserRolesRepo.GetAsync());
        }

        [ChildActionOnly]
        public ActionResult UserRoleAddEditPartial(UserRoles item)
        {
            return PartialView("_UserRoleAddEditPartial", unitOfWork.UserRolesRepo.Get(filter: m => m.Id == item.Id).FirstOrDefault());
        }
        #endregion





    }
}