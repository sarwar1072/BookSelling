using Framework.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        IProductService _productService;
        public HomeController(IProductService productService)
        {
        _productService=productService;

         }
        public IActionResult Index()
        {
            var product = _productService.GetForConsumer();
            return View(product);
        }
    }
}
