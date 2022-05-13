using DataAccessLayer;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public  class CategoryRepository:Repository<Category,int,FrameworkContext>,ICategoryRepository
    {
        public CategoryRepository(FrameworkContext frameworkContext):base(frameworkContext)
        {

        }
    }
}
