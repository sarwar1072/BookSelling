using System;

using Microsoft.AspNetCore.Identity;

namespace Membership.Entities
{
    public class UserClaim
        : IdentityUserClaim<string>
    {
        public UserClaim()
            : base()
        {

        }
    }
}
