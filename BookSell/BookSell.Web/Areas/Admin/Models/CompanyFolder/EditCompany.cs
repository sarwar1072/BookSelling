using Framework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.CompanyFolder
{
    public class EditCompany:CompanyBaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAuthorizedCompany { get; set; }
        public EditCompany(ICompanyService companyService) : base() { }
        public EditCompany() : base() { }

        public void Edit()
        {
            var editCompany = new Framework.Entities.Company
            {
                Id = Id,
                Name=Name,
                StreetAddress = StreetAddress,
                City = City,
                State = State,
                PostalCode = PostalCode,
                PhoneNumber = PhoneNumber,
                IsAuthorizedCompany = IsAuthorizedCompany,
            };
            _companyService.Edit(editCompany);
        }

        public void Load(int id)
        {
            var company = _companyService.GetId(id);
            if(company != null)
            {
                Id = company.Id;
                Name = company.Name;
                StreetAddress = company.StreetAddress;
                City = company.City;
                State = company.State;
                PostalCode = company.PostalCode;
                PhoneNumber = company.PhoneNumber;
                IsAuthorizedCompany = company.IsAuthorizedCompany;
            }
        }
                      
    }
}
