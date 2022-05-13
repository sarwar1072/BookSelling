using DataAccessLayer;
using Framework.Entitiess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public class CoverTypeRepository:Repository<CoverType,int,FrameworkContext>,ICoverTypeRepository
    {
        public CoverTypeRepository(FrameworkContext frameworkContext):base(frameworkContext)
        {

        }
    }
}