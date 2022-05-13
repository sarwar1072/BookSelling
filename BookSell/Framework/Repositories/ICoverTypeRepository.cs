using DataAccessLayer;
using Framework.Entitiess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public interface ICoverTypeRepository:IRepository<CoverType,int,FrameworkContext>
    {
    }
}
