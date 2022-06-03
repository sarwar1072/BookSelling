using System;

using Microsoft.AspNetCore.Identity;

namespace Membership.Entities
{
    public class UserToken
        : IdentityUserToken<string>
    {
        public UserToken()
            : base()
        {

        }
    }
}
