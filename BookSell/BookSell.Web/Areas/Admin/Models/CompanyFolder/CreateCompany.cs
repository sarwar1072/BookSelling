using Framework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.CompanyFolder
{
    public class CreateCompany:CompanyBaseModel
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
        public CreateCompany(ICompanyService companyService) : base() { }       
        public CreateCompany() : base() { }
        
        public void Create()
        {
            var create = new Framework.Entities.Company 
            {
                Name=Name,
                StreetAddress=StreetAddress,
                City=City,
                State=State,
                PostalCode=PostalCode,
                PhoneNumber=PhoneNumber,
                IsAuthorizedCompany=IsAuthorizedCompany,
            };
            _companyService.AddCompany(create);
        }


    }
}
