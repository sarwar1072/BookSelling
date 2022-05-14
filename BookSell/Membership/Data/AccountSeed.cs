﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Membership.Services;
using Membership.Entities;
using Membership.Contexts;
using DataAccessLayer;
using Framework;

namespace Membership.Data
{
    public class AccountSeed : DataSeed
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        private readonly ApplicationUser  _adminUser;
        private readonly Role  _adminRole;
        //private readonly SD ;
        public AccountSeed(UserManager userManager, RoleManager roleManager, ApplicationDbContext context)
            : base(context)
        {
            _userManager = userManager; 
            _roleManager = roleManager;

         // _superAdminUser = new ApplicationUser("superadmin","sarwar mahmud milon","8801628504000","sarwar@gmail.com");
            _adminUser = new ApplicationUser("admin","sarwar mahmud milon","13579","sarwar.cse.diu@gmail.com");
           
           // _superAdminRole = new Role("SuperAdmin");
            _adminRole = new Role("Admin");
           
        }

        private async Task<bool> CheckAndCreateRoleAsync(Role role)
        {
            if((await _roleManager.FindByNameAsync(role.Name)) == null)
            {
                var result = await _roleManager.CreateAsync(role);
                return result.Succeeded;
            }
            return true;
        }

        private async Task SeedUserAsync()
        {
            IdentityResult result = null;
            //if((await _userManager.FindByNameAsync(_superAdminUser.UserName.ToUpper())) == null)
            //{
            //    result = await _userManager.CreateAsync(_superAdminUser, "Sarwar@1072");
            //    if (result.Succeeded)
            //    {
            //        if (await CheckAndCreateRoleAsync(_superAdminRole))
            //        {
            //            await _userManager.AddToRoleAsync(_superAdminUser, _superAdminRole.Name);
            //        }
            //    }
            //}

            if ((await _userManager.FindByNameAsync(_adminUser.UserName.ToUpper())) == null)
            {
                result = await _userManager.CreateAsync(_adminUser, "Sarwar@1072");
                if (result.Succeeded)
                {
                    if (await CheckAndCreateRoleAsync(_adminRole))
                    {
                        await _userManager.AddToRoleAsync(_adminUser, _adminRole.Name);
                    }
                }
            }

        }

        public override async Task SeedAsync()
        {
            await SeedUserAsync();
        }

    }
}
