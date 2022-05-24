using Autofac;
using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.CompanyFolder
{
    public class CompanyBaseModel:AdminBaseModel,IDisposable
    {
        protected ICompanyService _companyService;
        public CompanyBaseModel(ICompanyService companyService )
        {
            _companyService = companyService;
        }
        public CompanyBaseModel()
        {
            _companyService = Startup.AutofacContainer.Resolve<ICompanyService>();
        }

        public void Dispose()
        {
            _companyService.Dispose();
        }
    }
}
