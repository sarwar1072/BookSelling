using DataAccessLayer;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public interface IOrderHeaderRepository:IRepository<OrderHeader,int,FrameworkContext>
    {
    }
}
