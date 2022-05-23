using Framework.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.ProductFolder
{
    public class EditProduct:ProductBaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price100 { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public IFormFile formFile { get; set; }
        public int CategoryId { get; set; }
        public int CoverTypeId { get; set; }


        public EditProduct(IProductService productService) : base() { }
        public EditProduct() : base() { }

        public void Edit()
        {
            var product = new Framework.Entities.Product
            {
                Id = Id,
            Title = Title,
            Description = Description,
            ISBN =ISBN,
            Author = Author,
            ListPrice = ListPrice,
            Price = Price,
            Price50 = Price50,
            Price100 = Price100,
            ImageUrl = ImageUrl,
            CategoryId = CategoryId,
            CoverTypeId = CoverTypeId,
               };
            _productService.EditProduct(product);
        }

        public void Load(int id)
        {
            var entity = _productService.GetId(id);
            if(entity != null)
            {
                Id = entity.Id;
                Title = entity.Title;
                Description = entity.Description;
                ISBN = entity.ISBN;
                Author = entity.Author;
                ListPrice = entity.ListPrice;
                Price = entity.Price;
                Price50 = entity.Price50;
                Price100 = entity.Price100;
                ImageUrl = entity.ImageUrl;
                CategoryId = entity.CategoryId;
                CoverTypeId = entity.CoverTypeId;

            }
        }


        public IList<SelectListItem> ListOfCoverType()
        {
            var cover = new List<SelectListItem>();
            foreach (var item in _productService.GetCoverTypes())
            {
                var addItem = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                cover.Add(addItem);
            }
            return cover;
        }

        public IList<SelectListItem> ListOfCategory()
        {
            var category = new List<SelectListItem>();
            foreach (var item in _productService.GetCategories())
            {
                var addItem = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                category.Add(addItem);
            }
            return category;
        }


    }
}
