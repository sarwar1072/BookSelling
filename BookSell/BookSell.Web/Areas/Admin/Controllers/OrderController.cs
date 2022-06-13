using BookSell.Web.Areas.Admin.Models;
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
        private readonly ISellUnitOfWork _sellUnitOfWork;
        public OrderController(ISellUnitOfWork  sellUnitOfWork)
        {
                _sellUnitOfWork=sellUnitOfWork;
         }

        [BindProperty]
        public OrderDetailsVM OrderVM { get; set; }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            OrderVM = new OrderDetailsVM()
            {
                OrderHeader = _sellUnitOfWork.OrderHeaderRepository.GetFirstOrDefault(u => u.Id == id,
                                                includeProperties: "ApplicationUser"),
                OrderDetails = _sellUnitOfWork.OrderDetailsRepository.GetAll(o => o.OrderId == id, includeProperties: "Product")

            };
            return View(OrderVM);
        }
    }
}
