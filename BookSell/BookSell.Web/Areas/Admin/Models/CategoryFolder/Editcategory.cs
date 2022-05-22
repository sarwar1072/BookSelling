using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.CategoryFolder
{
    public class Editcategory:CategoryBaseModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public Editcategory(ICategoryService categoryService) : base(categoryService) { }
        public Editcategory() : base()
        {
        }
        public void Edit()
        {
            var edit = new Framework.Entities.Category
            { 
                Id=Id,
                Name = Name
            };
            _categoryService.EditCategory(edit);
        }
        public void Load(int id)
        {
            var category = _categoryService.GetId(id);
            if (category != null)
            {
                Id = category.Id;
                Name = category.Name;
            }
        }
    }
}
