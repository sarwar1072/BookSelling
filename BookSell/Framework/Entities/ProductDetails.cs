using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Entities
{
    public class ProductDetails
    {
        public IQueryable<Product> ProductList { get; set; }
        public ICollection<Category> CategoryList { get; set; }
       
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}
