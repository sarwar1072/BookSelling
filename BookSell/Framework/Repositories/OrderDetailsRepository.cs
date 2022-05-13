using DataAccessLayer;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public  class OrderDetailsRepository:Repository<OrderDetails,int,FrameworkContext>,IOrderDetailsRepository
    {
        public OrderDetailsRepository(FrameworkContext frameworkContext):base(frameworkContext)
        {
        }
    }
}
