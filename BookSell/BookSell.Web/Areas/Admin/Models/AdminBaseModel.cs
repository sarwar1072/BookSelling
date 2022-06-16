using Autofac;
using Framework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models
{
    public abstract class AdminBaseModel
    {
        public MenuModel MenuModel { get; set; }
        public ResponseModel Response
        {
            get
            {
                if (_httpContextAccessor.HttpContext.Session.IsAvailable
                    && _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
                    _httpContextAccessor.HttpContext.Session.Remove(nameof(Response));
                    return response;
                }
                else
                    return null;
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.Set(nameof(Response),
                    value);
            }
        }

        protected IHttpContextAccessor _httpContextAccessor;
        public AdminBaseModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
           SetupMenu();
        }
        public AdminBaseModel()
        {
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
           SetupMenu();
        }

        private void SetupMenu()
        {
            MenuModel = new MenuModel
            {
                MenuItems = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Title = "Category",
                        Childs = new List<MenuChildItem>
                        {
                            new MenuChildItem{ Title = "View Category", Url = "/Admin/Category/" },
                            new MenuChildItem{Title="Add category",Url="/Admin/Category/AddCategory/"}
                        }
                    },
                   new MenuItem
                   {
                       Title="Course",
                       Childs=new List<MenuChildItem>
                       {
                           new MenuChildItem{Title="View Company",Url="/Admin/Company/"},
                           new MenuChildItem{Title="Add Company",Url="/Admin/Company/AddCompany/"}
                       }

                   },

                   new MenuItem
                   {
                       Title="Student",
                       Childs=new List<MenuChildItem>
                       {
                           new MenuChildItem{Title="View CoverType",Url="/Admin/CoverType/"},
                           new MenuChildItem{Title="Add CoverType",Url="/Admin/CoverType/AddCoverType/"}
                       }
                   },

                   new MenuItem
                   {
                       Title="StudentRegistration",
                       Childs=new List<MenuChildItem>
                       {
                           new MenuChildItem{Title="View  Order",Url="/Admin/Order/"},
                           //new MenuChildItem{Title="Add ",Url="/Admin/StudentRegistration/CreateRegistration/"}
                       }
                   },

                   new MenuItem
                    {
                        Title = "Product",
                        Childs = new List<MenuChildItem>
                        {
                            new MenuChildItem{ Title = " View Product", Url = "/Admin/Product/" },
                            new MenuChildItem{ Title = "Add Product", Url ="/Admin/Product/AddProduct/"}

                        }

                    }

                }
            };
        }

    }
}
