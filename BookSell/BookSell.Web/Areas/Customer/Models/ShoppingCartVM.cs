using Autofac;
using Framework.Entities;
using Framework.Services;
using Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Customer.Models
{
    public class ShoppingCartVM
    {
        private IUserService _userService;

        public ShoppingCartVM(IUserService userServic)
        {
            _userService = userServic;
        }
        public ShoppingCartVM()
        {
            _userService = Startup.AutofacContainer.Resolve<IUserService>();


        }
        public ApplicationUser GetId(string Id)
        {
            return _userService.GetUser(Id);           
        }
        public IList<ShoppingCart> ListCart { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
