using Framework.Entities;
using Framework.UnitOfWorkPro;
using Microsoft.EntityFrameworkCore;
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

        public (IList<OrderDetails> orderDetails, int total, int totalDisplay) GetDetails(int pageindex, int Pagesize,
                                                                                   string searchText, string orderBy)
        {
            var result = _sellUnitOfWork.OrderDetailsRepository.GetDynamic(null, orderBy,"Product", i => i.Include(s => s.OrderHeader).ThenInclude(s => s.AUser), 
                pageindex, Pagesize, true);
            return (result.data, result.total, result.totalDisplay);
        }

    }
}
