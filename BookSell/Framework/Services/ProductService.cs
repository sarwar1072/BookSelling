using Framework.Entities;
using Framework.UnitOfWorkPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Services
{
    public class ProductService : IProductService
    {
        private readonly ISellUnitOfWork _sellUnitOfWork;
        public ProductService(ISellUnitOfWork sellUnitOfWork)
        {
            _sellUnitOfWork = sellUnitOfWork;
        }
        public void Dispose()
        {
            _sellUnitOfWork.Dispose();
        }

        public void AddProduct(Product product)
        {
            _sellUnitOfWork.ProductRepository.Add(product);
            _sellUnitOfWork.Save();
        }

        public Product Delete(int id)
        {
            var product = _sellUnitOfWork.ProductRepository.GetById(id);
            _sellUnitOfWork.ProductRepository.Remove(product);
            _sellUnitOfWork.Save();
            return product;
        }

        public void EditProduct(Product product)
        {
            var productEntity = _sellUnitOfWork.ProductRepository.GetById(product.Id);
            productEntity.Id = product.Id;

            productEntity.Title = product.Title;
            productEntity.Description = product.Description;
            productEntity.ISBN = product.ISBN;
            productEntity.Author = product.Author;
            productEntity.ListPrice = product.ListPrice;
            productEntity.Price = product.Price;
            productEntity.Price50 = product.Price50;
            productEntity.Price100 = productEntity.Price100;
            productEntity.ImageUrl = product.ImageUrl;
            productEntity.CategoryId = product.CategoryId;
            productEntity.CoverTypeId = product.CoverTypeId;
            _sellUnitOfWork.ProductRepository.Edit(productEntity);
            _sellUnitOfWork.Save();
        }

        public Product GetId(int id)
        {
            return _sellUnitOfWork.ProductRepository.GetById(id);
        }

        public IEnumerable<Product> GetForConsumer()
        {
            return _sellUnitOfWork.ProductRepository.GetAll().OrderBy(Product => Product.CategoryId).ThenBy(
              Product  => Product.CoverTypeId);
        }
        public ProductDetails PagintList(string term = "", bool paging = false, int currentPage = 0)
        {
            var data = new ProductDetails();
            var dataList = _sellUnitOfWork.ProductRepository.GetAll(null, null, "Category,CoverType");
            if (!string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                dataList = dataList.Where(a => a.Title.ToLower().StartsWith(term)).ToList();
            }
            if (paging)
            {
                int pageSize = 3;
                int count = dataList.Count;
                int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                dataList = dataList.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                data.PageSize = pageSize;
                data.CurrentPage = currentPage;
                data.TotalPages = TotalPages;
            }
            data.ProductList = dataList.AsQueryable();
            return data;
        }

        public (IList<Product> product ,int total,int totalDisplay)GetProduct(int pageindex,int pagesize,
                                                                               string searchText,string orderBy)
        {
            var result = _sellUnitOfWork.ProductRepository.GetDynamic(null, orderBy, "Category,CoverType", pageindex, pagesize,true);
            return (result.data, result.total, result.totalDisplay);
        }
        public Product GetProductWithChild(int id)
        {
            return _sellUnitOfWork.ProductRepository.GetFirstOrDefault(x => x.Id == id, "Category,CoverType");
        }
        public IList<Category> GetCategories()
        {
            return _sellUnitOfWork.CategoryRepository.GetAll();
        }
        public IList<CoverType> GetCoverTypes()
        {
          return   _sellUnitOfWork.CoverTypeRepository.GetAll();
        }
    }
}
