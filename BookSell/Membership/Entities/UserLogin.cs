using System;

using Microsoft.AspNetCore.Identity;

namespace Membership.Entities
{
    public class UserLogin
        : IdentityUserLogin<string>
    {
        public UserLogin()
            : base()
        {

        }
    }
}
