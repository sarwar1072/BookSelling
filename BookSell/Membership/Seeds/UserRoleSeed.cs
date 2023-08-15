﻿using Membership.Entities;
using System;

namespace Membership.Seeds
{
    public class UserRoleSeed
    {
        public static ApplicationUserRole[] UserRole
        {
            get
            {
                return new ApplicationUserRole[]
                {
                    new ApplicationUserRole{ UserId = "e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125",
                        RoleId ="2c5e174e-3b0e-446f-86af-483d56fd7210" },
                    new ApplicationUserRole{ UserId = "8f3d96ce-76ec-4992-911a-33ceB81fa29d",
                        RoleId = "e943ffBf-65a4-4d42-bb74-f2ca9ea8d22a"  },
                };
            }
        }
    }
}
