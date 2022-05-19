using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.CategoryFolder
{
    public class CreateCategory:CategoryBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CreateCategory(ICategoryService categoryService) : base()
        {
        }
        public CreateCategory() : base()
        {
        }
        public void Create()
        {
            var category = new Framework.Entities.Category
            {
                Name = Name
            };
            _categoryService.AddCategory(category);
        }
    }
}
