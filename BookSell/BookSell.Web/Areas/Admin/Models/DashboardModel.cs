using Autofac;
using Framework.Entities;
using Framework.Services;
using Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models
{
    public class DashboardModel:AdminBaseModel,IDisposable
    {
        public int TotalUsers { get; set; }
        public int TotalOrders { get; set; }
        public double TotalRevenue { get; set; }
        

        protected IOrderService _orderService;
        protected IUserService _userService;
        public DashboardModel(IOrderService order, IUserService userService)
        {
            _orderService = order;
            _userService = userService; 
        }
        public DashboardModel()
        {
            _orderService = Startup.AutofacContainer.Resolve<IOrderService>();
            _userService=Startup.AutofacContainer.Resolve<IUserService>();  
        }
        public void Dispose()
        {
            _orderService.Dispose();
            _userService.Dispose();
        }

        public void GetAllProperty()
        {
            TotalOrders = _orderService.NumberOfOrders();
            TotalRevenue=_orderService.ToTalRevenue();
            TotalUsers=_userService.NumberOfUser();    

        }
    }
}
