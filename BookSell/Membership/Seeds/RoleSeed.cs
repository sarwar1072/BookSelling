﻿using Membership.Entities;
using System;

namespace Membership.Seeds
{
    public class RoleSeed
    {
        public static Role[] Roles
        {
            get
            {
                return new Role[]
                {
                    new Role{ Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", 
                        Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp =  DateTime.Now.Ticks.ToString()},
                    new Role{ Id = "e943ffBf-65a4-4d42-bb74-f2ca9ea8d22a", 
                        Name = "User", NormalizedName = "USER", ConcurrencyStamp =  DateTime.Now.Ticks.ToString()}
                };
            }
        }
    }
}
