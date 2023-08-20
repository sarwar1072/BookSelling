using BookSell.Web.Models;
using Framework.Services;
using System.Linq;

namespace BookSell.Web.Areas.Admin.Models.UserFolder
{
    public class UserModel:UserBaseModel
    {
        public UserModel(IUserService userService):base(userService)
        {
                
        }
        public UserModel():base()
        {
                
        }
       
        internal object GetUser(DataTablesAjaxRequestModel dataTables)
        {
            var data = _userService.GetUser(dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "FullName",
                                                     "PhoneNumber","City","Email","State","CreationTime"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.FullName,
                            record.PhoneNumber,
                            record.City,
                            record.Email,
                            record.State,
                            record.CreationTime.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
