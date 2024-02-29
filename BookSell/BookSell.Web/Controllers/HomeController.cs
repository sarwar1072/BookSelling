using Framework;
using Framework.Entities;
using Framework.Services;
using Framework.UnitOfWorkPro;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookSell.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductService _productService;

        ISellUnitOfWork _sellUnitOfWork;
        public HomeController(IProductService productService, ISellUnitOfWork sellUnitOfWork)
        {
           _productService=productService;
            _sellUnitOfWork=sellUnitOfWork;
        }

        public IActionResult Index(string term = "", int currentPage = 1)
        {
          //  var product = _productService.GetForConsumer();
            var listOfProduct = _productService.PagintList(term, true, currentPage);
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var count = _sellUnitOfWork.ShoppingCartRepository
                    .GetAll(c => c.ApplicationUserId == claim.Value)
                    .ToList().Count();

                HttpContext.Session.SetInt32(SD.ssShoppingCart, count);
            }
            return View(listOfProduct);
        }

        public IActionResult Details(int id)
        {
            var productFromDb = _productService.GetProductWithChild(id);
            var cartObj = new ShoppingCart() {
                ProductId = productFromDb.Id,
                Product=productFromDb,
            };
            return View(cartObj);              
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            shoppingCart.Id = 0;
            if (ModelState.IsValid)
            {
                //then we will add to cart
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                shoppingCart.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDb = _sellUnitOfWork.ShoppingCartRepository.GetFirstOrDefault(
                   u => u.ApplicationUserId == shoppingCart.ApplicationUserId && u.ProductId == shoppingCart.ProductId
                   , includeProperties: "Product"
                   );
                if (cartFromDb == null)
                {
                    //no records exists in database for that product for that user
                    _sellUnitOfWork.ShoppingCartRepository.Add(shoppingCart);
                }
                else
                {
                    cartFromDb.Count += shoppingCart.Count;
                    //_unitOfWork.ShoppingCart.Update(cartFromDb);
                }
                _sellUnitOfWork.Save();
                var count = _sellUnitOfWork.ShoppingCartRepository
                    .Get(c => c.ApplicationUserId == shoppingCart.ApplicationUserId)
                    .ToList().Count();
                //HttpContext.Session.SetObject(SD.ssShoppingCart, CartObject);
                HttpContext.Session.SetInt32(SD.ssShoppingCart, count);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var productFromDb = _sellUnitOfWork.ProductRepository.
                        GetFirstOrDefault(u => u.Id == shoppingCart.ProductId, includeProperties: "Category,CoverType");
                ShoppingCart cartObj = new ShoppingCart()
                {
                    Product = productFromDb,
                    ProductId = productFromDb.Id
                };
                return View(cartObj);
            }             
        }

    }
}
