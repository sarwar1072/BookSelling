using System;

using Microsoft.AspNetCore.Identity;

namespace Membership.Entities
{
    public class RoleClaim
        : IdentityRoleClaim<string>
    {
        public RoleClaim()
            : base()
        {

        }
    }
}
