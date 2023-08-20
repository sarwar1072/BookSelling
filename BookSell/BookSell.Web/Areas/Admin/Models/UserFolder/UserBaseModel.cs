using Autofac;
using Framework.Services;
using System;
namespace BookSell.Web.Areas.Admin.Models.UserFolder
{
    public class UserBaseModel:AdminBaseModel,IDisposable
    {
        protected IUserService _userService;
        public UserBaseModel(IUserService userService)
        {
                _userService = userService; 
        }
        public UserBaseModel()
        {
         _userService=Startup.AutofacContainer.Resolve<IUserService>();        
        }
       
        public void Dispose() {
            _userService.Dispose(); 
        }   
    }
}
