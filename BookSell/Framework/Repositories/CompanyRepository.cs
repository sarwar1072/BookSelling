using DataAccessLayer;
using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Repositories
{
   public class CompanyRepository:Repository<Company,int,FrameworkContext>,ICompanyRepository
    {
        public CompanyRepository(FrameworkContext frameworkContext):base(frameworkContext)
        {

        }
    }
}
