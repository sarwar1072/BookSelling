using Autofac;
using BookSell.Web.Areas.Admin.Models;
using BookSell.Web.Areas.Admin.Models.ProductFolder;
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

    public class ProductController : Controller
    {
         IFileHelper _fileHelper;

        public ProductController(IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;

        }
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<ProductModel>();
            return View(model);
        }
        public IActionResult AddProduct()
        {
            var model = new CreateProduct();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]

        public IActionResult AddProduct(CreateProduct model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.ImageUrl = _fileHelper.UploadFile(model.formFile);
                    model.AddProduct();
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

        public IActionResult EditProduct(int id)
        {
            var model = new EditProduct();
            model.Load(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult EditProduct(EditProduct model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.formFile != null)
                    {
                        _fileHelper.DeleteFile(model.ImageUrl);
                        model.ImageUrl = _fileHelper.UploadFile(model.formFile);
                    }
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
        public IActionResult DeleteProduct(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new ProductModel();
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

        public IActionResult GetProduct()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<ProductModel>();
            var data = model.GetProduct(tableModel);
            return Json(data);
        }
    }
}
