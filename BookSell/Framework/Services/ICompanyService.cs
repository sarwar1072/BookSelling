using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
   public interface ICompanyService:IDisposable
    {
        void AddCompany(Company company);
        Company Delete(int id);
        void Edit(Company company);
        Company GetId(int id);
        (IList<Company> companies, int total, int totalDisplay) GetCompany(int pageindex, int pagesize,
                                                                                  string searchText, string orderBy);
    }
}
