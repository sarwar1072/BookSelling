using BookSell.Web.Areas.Customer.Models;
using Framework;
using Framework.Entities;
using Framework.UnitOfWorkPro;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        ISellUnitOfWork _sellUnitOfWork;
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        Guid guid;
        public CartController(ISellUnitOfWork sellUnitOfWork)
        {
            _sellUnitOfWork = sellUnitOfWork;
        }
        // public IActionResult Index()
        //{
        //}
        //[HttpPost]
        public IActionResult Index(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
           // shoppingCart.ApplicationUserId = Guid.Parse(claim.Value);
            //var claimId = claim.Value;
           // guid =Guid.Parse(claim.Value);
           var  ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new OrderHeader(),
                //ListCart = _sellUnitOfWork.ShoppingCartRepository.GetFirstOrDefault(x=>x.ApplicationUserId== shoppingCart.ApplicationUserId,
                //includeProperties:"Product")
            };
            ShoppingCartVM.OrderHeader.OrderTotal = 0;
            //ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser
            //                                            .GetFirstOrDefault(u => u.Id == claim.Value, 
            //                                            includeProperties: "Company");
            foreach (var list in ShoppingCartVM.ListCart)
            {
                list.Price = SD.GetPriceBasedOnQuantity(list.Count, list.Product.Price,
                                                    list.Product.Price50, list.Product.Price100);
                ShoppingCartVM.OrderHeader.OrderTotal += (list.Price * list.Count);
                list.Product.Description = SD.ConvertToRawHtml(list.Product.Description);
                if (list.Product.Description.Length > 100)
                {
                    list.Product.Description = list.Product.Description.Substring(0, 99) + "...";
                }
            }
            return View(ShoppingCartVM);
        }


    }
}
