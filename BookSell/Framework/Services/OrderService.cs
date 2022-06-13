﻿using Framework.Entities;
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
        public (IList<OrderHeader> orderHeaders, int total, int totalDisplay) GetDetails(int pageindex, int Pagesize,
                                                                                   string searchText, string orderBy)
        {
            var result = _sellUnitOfWork.OrderHeaderRepository.GetDynamic(null, orderBy, "", pageindex, Pagesize, true);
            return (result.data, result.total, result.totalDisplay);
        }
    }
}
