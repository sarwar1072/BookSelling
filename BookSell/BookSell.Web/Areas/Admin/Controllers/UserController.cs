using Membership.Seeds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = IdenSD.Role_Admin)]

    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
