using Framework.Entities;
using Framework.UnitOfWorkPro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
    public class CompanyService : ICompanyService
    {
        private ISellUnitOfWork _sellUnitOfWork;
        public CompanyService(ISellUnitOfWork sellUnitOfWork)
        {
            _sellUnitOfWork = sellUnitOfWork;
        }
        public void AddCompany(Company company)
        {
            _sellUnitOfWork.CompanyRepository.Add(company);
            _sellUnitOfWork.Save();
        }

        public Company Delete(int id)
        {
            var deleteEntity = _sellUnitOfWork.CompanyRepository.GetById(id);
            _sellUnitOfWork.CompanyRepository.Remove(deleteEntity);
            _sellUnitOfWork.Save();
            return deleteEntity;
        }

        public void Edit(Company company)
        {
            var entity = _sellUnitOfWork.CompanyRepository.GetById(company.Id);
            entity.Name = company.Name;
            entity.StreetAddress = company.StreetAddress;
            entity.City = company.City;
            entity.State = company.State;
            entity.PostalCode = company.PostalCode;
            entity.PhoneNumber = company.PhoneNumber;
            entity.IsAuthorizedCompany = company.IsAuthorizedCompany;
            _sellUnitOfWork.CompanyRepository.Edit(entity);
            _sellUnitOfWork.Save();
        }

        public Company GetId(int id)
        {
            return _sellUnitOfWork.CompanyRepository.GetById(id);
        }

        public (IList<Company> companies,int total,int totalDisplay)GetCompany(int pageindex,int pagesize,
                                                                                  string searchText,string orderBy)
        {
            var result = _sellUnitOfWork.CompanyRepository.GetDynamic(null, orderBy, "", pageindex, pagesize);
            return (result.data, result.total, result.totalDisplay);
        }
        public void Dispose()
        {
            _sellUnitOfWork.Dispose();
        }
    }
}
