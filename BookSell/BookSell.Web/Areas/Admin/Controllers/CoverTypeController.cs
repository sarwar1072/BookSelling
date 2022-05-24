using Autofac;
using BookSell.Web.Areas.Admin.Models;
using BookSell.Web.Areas.Admin.Models.CoverTypeFolder;
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
    public class CoverTypeController : Controller
    {
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<CoverTypeModel>();
            return View(model);
        }
        public IActionResult AddCoverType()
        {
            var model = new CreateCoverModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddCoverType(CreateCoverModel model)
        {          
                if (ModelState.IsValid)
                {
                    try
                    {
                    model.Create();
                    model.Response = new ResponseModel("added successfully", ResponseType.Success);
                    return RedirectToAction("Index");
                    }
                    catch(DuplicationException ex)
                    {
                        model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                    }
                   catch(Exception ex)
                        {
                    model.Response = new ResponseModel("fail to creat", ResponseType.Failure);

                        }
                }
            return View(model);          
        }
        public IActionResult EditCover(int id)
        {
            var model = new EditCover();
            model.Load(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditCover(EditCover model)
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
        public IActionResult DeleteCover(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new CoverTypeModel();
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
        public IActionResult GetCoverType()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<CoverTypeModel>();
            var data = model.GetCoverType(tableModel);
            return Json(data);
        }
    }
}
