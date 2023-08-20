using Autofac;
using BookSell.Web.Areas.Admin.Models.CoverTypeFolder;
using BookSell.Web.Areas.Admin.Models.UserFolder;
using BookSell.Web.Models;
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
            var model = Startup.AutofacContainer.Resolve<UserModel>();
            return View(model);
        }
        public IActionResult GetUser()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<UserModel>();
            var data = model.GetUser(tableModel);
            return Json(data);
        }
    }
}
