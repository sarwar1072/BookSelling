using Autofac;
using BookSell.Web.Areas.Admin.Models;
using BookSell.Web.Areas.Admin.Models.OrderDetailsModel;
using BookSell.Web.Models;
using Framework.UnitOfWorkPro;
using Membership.Seeds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = IdenSD.Role_Admin)]

    public class OrderController : Controller
    {      
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<OrderDetailModel>();

            return View(model);
        }
        public IActionResult Details()
        {
            return View();
        }

        public IActionResult GetOrder()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<OrderDetailModel>();
            var data = model.GetOrder(tableModel);
            return Json(data);
        }

        
    }
}
