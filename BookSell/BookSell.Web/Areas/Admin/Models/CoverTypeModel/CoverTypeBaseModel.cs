using Autofac;
using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.CoverTypeModel
{
    public class CoverTypeBaseModel : AdminBaseModel, IDisposable
    {
        protected ICoverTypeService _coverTypeService;
        public CoverTypeBaseModel(ICoverTypeService coverTypeService)
        {
            _coverTypeService = coverTypeService;

        }
        public CoverTypeBaseModel()
        {
            _coverTypeService = Startup.AutofacContainer.Resolve<ICoverTypeService>();
        }
        public void Dispose()
        {
            _coverTypeService.Dispose();
        }
    }
}
