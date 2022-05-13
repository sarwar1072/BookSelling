using DataAccessLayer;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public class ProductRepository:Repository<Product,int,FrameworkContext>,IProductRepository
    {
        public ProductRepository(FrameworkContext frameworkContext):base(frameworkContext)
        {

        }
    }
}
