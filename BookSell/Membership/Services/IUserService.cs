using Membership.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Services
{
    public interface IUserService
    {
        //public (IList<ApplicationUser> records, int total, int totalDisplay) GetAll(int pageIndex, int pageSize, string searchText, string sortText);
        //public (IList<ApplicationUser> records, int total, int totalDisplay) GetAllAdmin(int pageIndex, int pageSize, string searchText, string sortText);
        //public (IList<ApplicationUser> records, int total, int totalDisplay) GetAllUser(int pageIndex, int pageSize, string searchText, string sortText);
        public ApplicationUser GetById(string id);
        //public Task<string> Add(ApplicationUser user, string userRoleId, string password);
        ////public Task<string> Add(ApplicationUser user, string userRoleName, string password);
        //public Task<string> Update(ApplicationUser user, string userRoleId);
        //public Task<string> Update(ApplicationUser user);
        //public Task<bool> ChangePassword(string id, string currentPassword, string newPassword);
    }
}
