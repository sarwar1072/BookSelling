using Autofac;
using BookSell.Web.Areas.Admin.Models.OrderDetailsModel;
using BookSell.Web.Areas.Admin.Models;
using BookSell.Web.Models;
using Framework.UnitOfWorkPro;
using Microsoft.AspNetCore.Mvc;
using Membership.Seeds;
using Microsoft.AspNetCore.Authorization;

namespace BookSell.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = IdenSD.Role_Admin)]
	public class OrderController : Controller
	{
		ISellUnitOfWork _sellUnitOfWork;
		public OrderDetailsVM OrderDetailsVM { get; set; }

		public OrderController(ISellUnitOfWork sellUnitOfWork)
		{
			_sellUnitOfWork = sellUnitOfWork;
		}
		public IActionResult Index()
		{
			var model = Startup.AutofacContainer.Resolve<OrderDetailModel>();

			return View(model);
		}
		public IActionResult Details(int id)
		{
			OrderDetailsVM = new OrderDetailsVM()
			{
				OrderHeader = _sellUnitOfWork.OrderHeaderRepository.GetFirstOrDefault(u => u.Id == id),
				OrderDetails = _sellUnitOfWork.OrderDetailsRepository.GetAll(u => u.OrderId == id, includeProperties: "Product"),
			};
			//var model = new OrderDetailVM();
			//model.Load(id);
			return View(OrderDetailsVM);
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
