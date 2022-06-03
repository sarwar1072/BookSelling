using BookSell.Web.Areas.Customer.Models;
using Framework;
using Framework.Entities;
using Framework.UnitOfWorkPro;
using Microsoft.AspNetCore.Http;
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
       // private readonly UserManager<IdentityUser> _userManager;

        public CartController(ISellUnitOfWork sellUnitOfWork)
        {
            _sellUnitOfWork = sellUnitOfWork;
            
        }
        
        public IActionResult Index( )
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
           
           var  ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new OrderHeader(),
               ListCart = _sellUnitOfWork.ShoppingCartRepository.GetAll(u => u.ApplicationUserId == claim.Value,
                 includeProperties:"Product")
           };
            ShoppingCartVM.OrderHeader.OrderTotal = 0;
           
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

        public IActionResult Plus(int cartId)
        {
            var cart = _sellUnitOfWork.ShoppingCartRepository.GetFirstOrDefault
                            (c => c.Id == cartId, includeProperties: "Product");
            cart.Count += 1;
            cart.Price = SD.GetPriceBasedOnQuantity(cart.Count, cart.Product.Price,
                                    cart.Product.Price50, cart.Product.Price100);
            _sellUnitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Minus(int cartId)
        {
            var cart = _sellUnitOfWork.ShoppingCartRepository.GetFirstOrDefault
                            (c => c.Id == cartId, includeProperties: "Product");
            if (cart.Count == 1)
            {
                var cnt = _sellUnitOfWork.ShoppingCartRepository.GetAll(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
                _sellUnitOfWork.ShoppingCartRepository.Remove(cart);
                _sellUnitOfWork.Save();
                HttpContext.Session.SetInt32(SD.ssShoppingCart, cnt - 1);
            }
            else
            {
                cart.Count -= 1;
                cart.Price = SD.GetPriceBasedOnQuantity(cart.Count, cart.Product.Price,
                                    cart.Product.Price50, cart.Product.Price100);
                _sellUnitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

       


    }
}
