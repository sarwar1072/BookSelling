using Autofac;
using BookSell.Web.Areas.Admin.Models;
using BookSell.Web.Areas.Admin.Models.OrderDetailsModel;
using BookSell.Web.Models;
using Framework.UnitOfWorkPro;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        //private readonly ISellUnitOfWork _sellUnitOfWork;
        //public OrderController(ISellUnitOfWork  sellUnitOfWork)
        //{
        //        _sellUnitOfWork=sellUnitOfWork;
        // }

        //[BindProperty]
        //public OrderDetailsVM OrderVM { get; set; }
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<OrderDetailModel>();

            return View(model);
        }

        public IActionResult GetOrder()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<OrderDetailModel>();
            var data = model.GetOrder(tableModel);
            return Json(data);
        }

        //public IActionResult Details(int id)
        //{
        //    OrderVM = new OrderDetailsVM()
        //    {
        //        OrderHeader = _sellUnitOfWork.OrderHeaderRepository.GetFirstOrDefault(u => u.Id == id,
        //                                        includeProperties: "ApplicationUser"),
        //        OrderDetails = _sellUnitOfWork.OrderDetailsRepository.GetAll(o => o.OrderId == id, includeProperties: "Product")

        //    };
        //    return View(OrderVM);
        //}
    }
}
