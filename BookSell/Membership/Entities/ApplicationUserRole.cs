using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Membership.Entities
{
    public class ApplicationUserRole
      : IdentityUserRole<string>
    {
        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        public Role Role { get; set; }
    }
}
