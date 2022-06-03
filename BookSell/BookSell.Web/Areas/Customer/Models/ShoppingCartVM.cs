using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Customer.Models
{
    public class ShoppingCartVM
    {
        public IList<ShoppingCart> ListCart { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
