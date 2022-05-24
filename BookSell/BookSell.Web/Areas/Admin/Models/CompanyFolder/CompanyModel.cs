using BookSell.Web.Models;
using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.CompanyFolder
{
    public class CompanyModel:CompanyBaseModel
    {
        public CompanyModel(ICompanyService companyService) : base(companyService) { }
        public CompanyModel() : base() { }

        internal object GetCompany(DataTablesAjaxRequestModel dataTables)
        {
            var data = _companyService.GetCompany(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] 
                                                     { "Name","StreetAddress","City","State","PostalCode" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.companies
                        select new string[]
                        {
                            record.Name,
                            record.StreetAddress,
                            record.City,
                            record.State,
                            record.PostalCode,
                            record.PhoneNumber,
                            record.IsAuthorizedCompany.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };
        }

        internal string Delete(int id)
        {
            var deleteData = _companyService.Delete(id);
            return deleteData.Name;
        }

    }
}
