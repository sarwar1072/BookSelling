using Framework.Entities;
using Framework.UnitOfWorkPro;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
  public  class OrderService: IOrderService
    {
        private ISellUnitOfWork _sellUnitOfWork;
        public OrderService(ISellUnitOfWork sellUnitOfWork)
        {
            _sellUnitOfWork = sellUnitOfWork;
        }
        public void Dispose()
        {
            _sellUnitOfWork.Dispose();
        }
        public (IList<OrderDetails> orderDetails, int total, int totalDisplay) GetDetails(int pageindex, int Pagesize,
                                                                                   string searchText, string orderBy)
        {
            var result = _sellUnitOfWork.OrderDetailsRepository.GetDynamic(null, orderBy, "OrderHeader", pageindex, Pagesize, true);
            return (result.data, result.total, result.totalDisplay);
        }
    }
}
