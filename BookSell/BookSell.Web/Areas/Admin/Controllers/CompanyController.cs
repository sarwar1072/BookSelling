using Autofac;
using BookSell.Web.Areas.Admin.Models;
using BookSell.Web.Areas.Admin.Models.CompanyFolder;
using BookSell.Web.Models;
using Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<CompanyModel>();
            return View(model);
        }
        public IActionResult AddCompany()
        {
            var model = new CreateCompany();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddCompany(CreateCompany model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("added successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("fail to create", ResponseType.Failure);

                }
            }
            return View(model);
        }
        public IActionResult EditCompany(int id)
        {
            var model = new EditCompany();
            model.Load(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditCompany(EditCompany model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Edited successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicationException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("edited fail", ResponseType.Failure);
                }
            }
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeleteCompany(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new CompanyModel();
                try
                {
                    var title = model.Delete(id);
                    model.Response = new ResponseModel("delete ", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    model.Response = new ResponseModel("fail", ResponseType.Failure);
                }
            }
            return RedirectToAction("Index");

        }
        public IActionResult GetComapny()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<CompanyModel>();
            var data = model.GetCompany(tableModel);
            return Json(data);
        }
    }
}
