using BookSell.Web.Models;
using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.ProductFolder
{
    public class ProductModel:ProductBaseModel
    {
        public ProductModel(IProductService productService) : base(productService) { }
        public ProductModel() : base() { }
        internal object GetProduct(DataTablesAjaxRequestModel dataTables)
        {
            var data = _productService.GetProduct(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "Title",
                                                     "Description","ISBN","Author","Price","Category"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.product
                        select new string[]
                        {
                            record.Title,
                            record.Description,
                            record.ISBN,
                            record.Author,
                            record.Price.ToString(),
                            record.ImageUrl,
                            record.Category.Name,
                            record.Id.ToString()
                        }).ToArray()
            };
        }
        internal string Delete(int id)
        {
            var deleteData = _productService.Delete(id);
            return deleteData.Title;
        }

    }
}
