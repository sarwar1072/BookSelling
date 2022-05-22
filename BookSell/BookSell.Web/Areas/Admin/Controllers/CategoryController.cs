using Autofac;
using BookSell.Web.Areas.Admin.Models;
using BookSell.Web.Areas.Admin.Models.CategoryFolder;
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
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<CategoryModel>();
            return View(model);
        }

        public IActionResult AddCategory()
        {
            var model = new CreateCategory();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult AddCategory(CreateCategory model)
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
                    model.Response = new ResponseModel("fail to creat", ResponseType.Failure);

                }
            }
            return View(model);
        }
        public IActionResult EditCategory(int id)
        {
            var model = new Editcategory();
            model.Load(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditCategory(Editcategory model)
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
        public IActionResult DeleteCategory(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new CategoryModel();
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


        public IActionResult GetCategory()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<CategoryModel>();
            var data = model.GetCategory(tableModel);
            return Json(data);
        }
    }
}
