using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Identities.Models
{
    public class LoginModel
    {
        public string ReturnUrl { get; set; }
        public string Email { get; set; }
        public bool RememberMe { get; set; }

        public string  Password { get; set; }
    }
}
