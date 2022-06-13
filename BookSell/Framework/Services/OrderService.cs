using Framework.Entities;
using Framework.UnitOfWorkPro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
  public  class OrderService
    {
        private ISellUnitOfWork _sellUnitOfWork;
        public OrderService(ISellUnitOfWork sellUnitOfWork)
        {
            _sellUnitOfWork = sellUnitOfWork;

        }

        public (IList<OrderDetails> orderDetails, int total, int totalDisplay) GetCoverType(int pageindex, int Pagesize,
                                                                                   string searchText, string orderBy)
        {
            var result = _sellUnitOfWork.OrderDetailsRepository.GetDynamic(null, orderBy, "", pageindex, Pagesize, true);
            return (result.data, result.total, result.totalDisplay);
        }

    }
}
