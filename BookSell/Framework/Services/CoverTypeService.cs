using Framework.Entities;
using Framework.UnitOfWorkPro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
   public class CoverTypeService: ICoverTypeService
    {
        private ISellUnitOfWork _sellUnitOfWork;
        public CoverTypeService(ISellUnitOfWork sellUnitOfWork)
        {
            _sellUnitOfWork = sellUnitOfWork;
        }
        public void AddCover(CoverType coverType)
        {
            _sellUnitOfWork.CoverTypeRepository.Add(coverType);
            _sellUnitOfWork.Save();
        }

        public CoverType DeleteCover(int id)
        {
            var count = _sellUnitOfWork.CoverTypeRepository.GetById(id);
            _sellUnitOfWork.CoverTypeRepository.Remove(count);
            _sellUnitOfWork.Save();
            return count;
        }
        public void Dispose()
        {
            _sellUnitOfWork.Dispose();
        }

        public void EditCover(CoverType coverType)
        {
            var coverEntity = _sellUnitOfWork.CoverTypeRepository.GetById(coverType.Id);
            coverEntity.Name = coverType.Name;
            _sellUnitOfWork.CoverTypeRepository.Edit(coverEntity);
            _sellUnitOfWork.Save();           
        }

        public CoverType GetId(int id)
        {
            return _sellUnitOfWork.CoverTypeRepository.GetById(id);
        }

        public (IList<CoverType> coverTypes,int total,int totalDisplay)GetCoverType(int pageindex,int Pagesize,
                                                                                    string searchText,string orderBy)
        {
            var result = _sellUnitOfWork.CoverTypeRepository.GetDynamic(null, orderBy, "", pageindex, Pagesize, true);
            return (result.data, result.total, result.totalDisplay);
        }
        
    }
}
