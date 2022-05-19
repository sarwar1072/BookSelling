using Autofac;
using BookSell.Web.Areas.Admin.Models.CoverTypeFolder;
using BookSell.Web.Models;
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
        public IActionResult GetCoverType()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<CoverTypeModel>();
            var data = model.GetCoverType(tableModel);
            return Json(data);
        }
    }
}
