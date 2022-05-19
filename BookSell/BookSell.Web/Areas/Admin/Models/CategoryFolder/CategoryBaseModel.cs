using Autofac;
using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.CategoryFolder
{
    public class CategoryBaseModel:AdminBaseModel,IDisposable
    {
        protected ICategoryService _categoryService;
        public CategoryBaseModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public CategoryBaseModel()
        {
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
        }

        public void Dispose()
        {
            _categoryService.Dispose();
        }
    }
}
