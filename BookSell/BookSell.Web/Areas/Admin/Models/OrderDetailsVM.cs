using BookSell.Web.Areas.Admin.Models.OrderDetailsModel;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models
{
    public class OrderDetailsVM: OrderDetailsBaseModel
	{
        public OrderDetailsVM() : base()
        {
        }
        //public OrderDetailsVM()
        //{

        //}
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
