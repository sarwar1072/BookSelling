using Autofac;
using BookSell.Web.Models;
using Framework;
using Framework.Entities;
using Framework.UnitOfWorkPro;
using Membership.Entities;
using Membership.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookSell.Web.Controllers
{
    public class CartController : Controller
    {
        ISellUnitOfWork _sellUnitOfWork;
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }    
        public CartController(ISellUnitOfWork sellUnitOfWork)
        {
            _sellUnitOfWork = sellUnitOfWork;                   
        }
     
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new OrderHeader(),
                ListCart = _sellUnitOfWork.ShoppingCartRepository.GetAll(u => u.ApplicationUserId == claim.Value,
                  includeProperties: "Product")
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
        public IActionResult Remove(int cartId)
        {
            var cart = _sellUnitOfWork.ShoppingCartRepository.GetFirstOrDefault
                            (c => c.Id == cartId, includeProperties: "Product");

            var cnt = _sellUnitOfWork.ShoppingCartRepository.GetAll(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
            _sellUnitOfWork.ShoppingCartRepository.Remove(cart);
            _sellUnitOfWork.Save();
            HttpContext.Session.SetInt32(SD.ssShoppingCart, cnt - 1);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            
            ShoppingCartVM = new ShoppingCartVM()
            {
                OrderHeader = new OrderHeader(),
                ListCart = _sellUnitOfWork.ShoppingCartRepository.GetAll(c => c.ApplicationUserId == claim.Value,
                includeProperties: "Product")
            };
           // var model = new ShoppingCartVM();         
            ShoppingCartVM.OrderHeader.AUser = ShoppingCartVM.GetId(claim.Value);
            foreach (var list in ShoppingCartVM.ListCart)
            {
                list.Price = SD.GetPriceBasedOnQuantity(list.Count, list.Product.Price,
                                                    list.Product.Price50, list.Product.Price100);
                ShoppingCartVM.OrderHeader.OrderTotal += (list.Price * list.Count);
            }
            ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.AUser.FullName;
            ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.AUser.PhoneNumber;
            ShoppingCartVM.OrderHeader.StreetAddress = ShoppingCartVM.OrderHeader.AUser.StreetAddress;
            ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.AUser.City;
            ShoppingCartVM.OrderHeader.State = ShoppingCartVM.OrderHeader.AUser.State;
            ShoppingCartVM.OrderHeader.PostalCode = ShoppingCartVM.OrderHeader.AUser.PostalCode;
            return View(ShoppingCartVM);
        }
        [HttpPost]
        [ActionName("Summary")]
        [ValidateAntiForgeryToken]
        public IActionResult SummaryPost()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

          //  ShoppingCartVM.OrderHeader.AUser = ShoppingCartVM.GetId(claim.Value); for this line showed  duplicate key error
            ShoppingCartVM.ListCart = _sellUnitOfWork.ShoppingCartRepository.GetAll(x => x.ApplicationUserId == claim.Value, 
                                                                                            includeProperties: "Product");

            ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusApproved;
            ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusApproved;
            // ShoppingCartVM.OrderHeader.ApplicationUserId = claim.Value;for this line showed  duplicate key error
            ShoppingCartVM.OrderHeader.OrderDate = DateTime.Now;

            _sellUnitOfWork.OrderHeaderRepository.Add(ShoppingCartVM.OrderHeader);
            _sellUnitOfWork.Save();

            foreach (var item in ShoppingCartVM.ListCart)
            {
                item.Price = SD.GetPriceBasedOnQuantity(item.Count, item.Product.Price,
                    item.Product.Price50, item.Product.Price100);
                OrderDetails orderDetails = new OrderDetails()
                {
                    ProductId = item.ProductId,
                    OrderId = ShoppingCartVM.OrderHeader.Id,
                    Price = item.Price,
                    Count = item.Count
                };
                ShoppingCartVM.OrderHeader.OrderTotal += orderDetails.Count * orderDetails.Price;
                _sellUnitOfWork.OrderDetailsRepository.Add(orderDetails);
            }
            _sellUnitOfWork.ShoppingCartRepository.Remove(ShoppingCartVM.ListCart);
            _sellUnitOfWork.Save();
            HttpContext.Session.SetInt32(SD.ssShoppingCart, 0);

            return RedirectToAction("OrderConfirmation", "Cart", new { id = ShoppingCartVM.OrderHeader.Id });
        }

        public IActionResult OrderConfirmation(int id)
        {
            OrderHeader orderHeader = _sellUnitOfWork.OrderHeaderRepository.GetFirstOrDefault(u => u.Id == id);
            
            return View(id);
        }
    }
 }

