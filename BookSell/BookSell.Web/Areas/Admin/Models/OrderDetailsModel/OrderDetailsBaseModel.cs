using Autofac;
using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.OrderDetailsModel
{
    public class OrderDetailsBaseModel:IDisposable
    {
        protected IOrderService _ordrService;
        public OrderDetailsBaseModel(IOrderService ordrService)
        {
            _ordrService = ordrService;
        }
        public OrderDetailsBaseModel()
        {
            _ordrService = Startup.AutofacContainer.Resolve<IOrderService>();
        }

        public void Dispose()
        {
            _ordrService.Dispose();
        }
    }
}
