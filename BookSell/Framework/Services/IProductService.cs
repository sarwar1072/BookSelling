using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
   public interface IProductService:IDisposable
    {
        void AddProduct(Product product);
        Product Delete(int id);
        void EditProduct(Product product);
        Product GetId(int id);
        (IList<Product> product, int total, int totalDisplay) GetProduct(int pageindex, int pagesize,
                                                                               string searchText, string orderBy);
        IList<Category> GetCategories();
        IList<CoverType> GetCoverTypes();

    }
}
