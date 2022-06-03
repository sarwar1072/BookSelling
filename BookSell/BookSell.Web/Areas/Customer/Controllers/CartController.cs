using BookSell.Web.Areas.Customer.Models;
using Framework;
using Framework.Entities;
using Framework.UnitOfWorkPro;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public CartController(ISellUnitOfWork sellUnitOfWork
            , UserManager<IdentityUser> userManager)
        {
            _sellUnitOfWork = sellUnitOfWork;
            _userManager = userManager;
        }
        
        public IActionResult Index( )
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
           
           var  ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new OrderHeader(),
               //ListCart = _sellUnitOfWork.ShoppingCartRepository.GetFirstOrDefault(u => u.ApplicationUserId == claim.Value,
               //  "Product")
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
