﻿using Membership.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
    public interface IUserService:IDisposable
    {
        //void CreateAP(ApplicationUser applicationUser);
        //ApplicationUser DeleteUser(Guid id);
        //void EditAP(ApplicationUser applicationUser);
        int NumberOfUser();
        (IList<ApplicationUser> records, int total, int totalDisplay) GetUser(int pageIndex, int pageSize, string searchText, string sortText);
        ApplicationUser GetUser(string id);
    }
}
