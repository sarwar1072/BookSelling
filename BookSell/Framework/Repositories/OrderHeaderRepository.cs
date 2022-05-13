using DataAccessLayer;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public class OrderHeaderRepository:Repository<OrderHeader,int,FrameworkContext>,IOrderHeaderRepository
    {
        public OrderHeaderRepository(FrameworkContext frameworkContext):base(frameworkContext)
        {

        }
    }
}
