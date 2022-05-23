using Autofac;
using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.ProductFolder
{
    public class ProductBaseModel:AdminBaseModel, IDisposable
    {
        protected IProductService _productService;
        public ProductBaseModel(IProductService productService)
        {
            _productService = productService;
        }
        public ProductBaseModel()
        {
            _productService= Startup.AutofacContainer.Resolve<IProductService>();
        }
        public void Dispose()
        {
            _productService.Dispose();
        }
    }
}
