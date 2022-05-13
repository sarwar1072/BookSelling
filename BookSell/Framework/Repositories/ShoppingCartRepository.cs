using DataAccessLayer;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public class ShoppingCartRepository:Repository<ShoppingCart,int,FrameworkContext>,IShoppingCartRepository
    {
        public ShoppingCartRepository(FrameworkContext frameworkContext):base(frameworkContext)
        {

        }

    }
}
