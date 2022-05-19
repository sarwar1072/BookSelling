using BookSell.Web.Models;
using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.CoverTypeFolder
{
    public class CoverTypeModel:CoverTypeBaseModel
    {
        public CoverTypeModel(ICoverTypeService coverTypeService):base(coverTypeService)
        {
            _coverTypeService = coverTypeService;
        }
        public CoverTypeModel() : base() { }
        internal object GetCoverType(DataTablesAjaxRequestModel dataTables)
        {
            var data = _coverTypeService.GetCoverType(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "Name" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.coverTypes
                        select new string[]
                        {
                            record.Name,
                            record.Id.ToString()

                        }).ToArray()                                                   
            };
        }
        internal string Delete(int id)
        {
            var deleteData = _coverTypeService.DeleteCover(id);
            return deleteData.Name;
        }
        

    }
}
