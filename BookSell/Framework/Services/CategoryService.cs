using Framework.Entities;
using Framework.UnitOfWorkPro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
    public class CategoryService: ICategoryService
    {
        private ISellUnitOfWork _sellUnitOfWork;
        public CategoryService(ISellUnitOfWork sellUnitOfWork)
        {
            _sellUnitOfWork = sellUnitOfWork;
        }
        public void AddCategory(Category category)
        {
            var count = _sellUnitOfWork.CategoryRepository.GetCount(c => c.Name == category.Name);

            if (count > 0)
            {
                throw new DuplicationException("category already exist",nameof(category.Name));
            }
            _sellUnitOfWork.CategoryRepository.Add(category);
            _sellUnitOfWork.Save();
        }

        public Category Delete(int id)
        {
            var category = _sellUnitOfWork.CategoryRepository.GetById(id);
            _sellUnitOfWork.CategoryRepository.Remove(category);
            _sellUnitOfWork.Save();
            return category;
        }
        public void Dispose()
        {
            _sellUnitOfWork.Dispose();
        }
        public void EditCategory(Category category)
        {
            var categoryEntity = _sellUnitOfWork.CategoryRepository.GetById(category.Id);
            categoryEntity.Name = category.Name;
            _sellUnitOfWork.CategoryRepository.Edit(categoryEntity);
            _sellUnitOfWork.Save();
        }

        public Category GetId(int id)
        {
             
            return _sellUnitOfWork.CategoryRepository.GetById(id);
        }
        public (IList<Category> category,int total,int totalDisplay)GetCategory(int pageindex,int Pagesize,
                                                                                 string searchText,string orderBy)
        {
            var result = _sellUnitOfWork.CategoryRepository.GetDynamic(null, orderBy, "", pageindex, Pagesize, true);
            return (result.data,result.total,result.totalDisplay);
        }
    }
}
