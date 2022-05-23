﻿using Framework.Entities;
using Framework.UnitOfWorkPro;
using System;
using System.Collections.Generic;
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

        public (IList<Product> product ,int total,int totalDisplay)GetProduct(int pageindex,int pagesize,
                                                                               string searchText,string orderBy)
        {
            var result = _sellUnitOfWork.ProductRepository.GetDynamic(null, orderBy, "Category,CoverType", pageindex, pagesize,true);
            return (result.data, result.total, result.totalDisplay);
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
