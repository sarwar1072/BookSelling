﻿using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
    public interface IOrderService:IDisposable
    {
        (IList<OrderHeader> orderHeaders, int total, int totalDisplay) GetDetails(int pageindex, int Pagesize,
            
          string searchText, string orderBy);
        OrderDetails GetDetails(int id);
        double ToTalRevenue();
        int NumberOfOrders();
    }
}
