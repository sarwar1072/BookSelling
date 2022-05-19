using BookSell.Web.Models;
using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.CategoryFolder
{
    public class CategoryModel:CategoryBaseModel
    {
        public CategoryModel(ICategoryService categoryService):base()
        {
        }
        public CategoryModel():base()
        {
        }

        internal object GetCategory(DataTablesAjaxRequestModel dataTables)
        {
            var data = _categoryService.GetCategory(
                                                     dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "Name"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.category
                        select new string[]
                        {
                                record.Name,
                                record.Id.ToString()
                        }
                       ).ToArray()
            };
        }
        internal string Delete(int Id)
        {
            var deletCategory = _categoryService.Delete(Id);
            return deletCategory.Name;
        }
    }
}
