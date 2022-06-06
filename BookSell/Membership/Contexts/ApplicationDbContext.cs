using System;
using System.Collections.Generic;
using System.Text;
using Membership.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Membership.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, string,
        UserClaim, ApplicationUserRole, UserLogin, RoleClaim, UserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
    }
}
