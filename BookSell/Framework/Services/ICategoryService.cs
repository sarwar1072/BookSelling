using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
   public interface ICategoryService:IDisposable
    {
        void AddCategory(Category category);
        Category Delete(int id);
        void EditCategory(Category category);
        Category GetId(int id);
        (IList<Category> category, int total, int totalDisplay) GetCategory(int pageindex, int Pagesize,
                                                                                 string searchText, string orderBy);
    }
}
