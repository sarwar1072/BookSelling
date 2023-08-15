using Membership.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace Membership.Seeds
{
	internal class ApplicationUserSeed
	{
		internal static ApplicationUser[] Users
		{
			get
			{
				var rootUser = new ApplicationUser
				{
					Id = "e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125",
		  		    FullName = "Admin",
					UserName = "admin@stackOverflow.com",
					NormalizedUserName = "ADMIN@STACKOVERFLOW.COM",
					Email = "admin@stackOverflow.com",
					NormalizedEmail = "ADMIN@STACKOVERFLOW.COM",
					LockoutEnabled = true,
					//SecurityStamp = String(),
					EmailConfirmed = true
				};
				var normalUser = new ApplicationUser
				{
					Id = "8f3d96ce-76ec-4992-911a-33ceB81fa29d",
					FullName = "sarwar",
					UserName = "user@stackOverflow.com",
					NormalizedUserName = "USER@STACKOVERFLOW.COM",
					Email = "user@stackOverflow.com",
					NormalizedEmail = "USER@STACKOVERFLOW.COM",
					LockoutEnabled = true,
					//SecurityStamp = Guid.NewGuid().ToString(),
					EmailConfirmed = true
				};
				var password = new PasswordHasher<ApplicationUser>();
				var rootHashed = password.HashPassword(rootUser, "Admin@123");
				var normalHashed = password.HashPassword(normalUser, "User@123");
                rootUser.PasswordHash = rootHashed;
				normalUser.PasswordHash = normalHashed;

				return new ApplicationUser[]
				{
                    rootUser,
					normalUser
                };
			}
		}
	}
}
