﻿using Autofac;
using BookSell.Web.Areas.Admin.Models;
using BookSell.Web.Areas.Admin.Models.CategoryFolder;
using BookSell.Web.Areas.Admin.Models.CompanyFolder;
using BookSell.Web.Areas.Admin.Models.CoverTypeFolder;
using BookSell.Web.Areas.Admin.Models.OrderDetailsModel;
using BookSell.Web.Areas.Admin.Models.ProductFolder;
using BookSell.Web.Areas.Admin.Models.UserFolder;
using BookSell.Web.Models;
using Framework.Entities;
using Framework.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BookSell.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WebModule(string connectionString, string migrationAssemblyName
            , IWebHostEnvironment webHostEnvironment
         )
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;   
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CoverTypeModel>().AsSelf();
            builder.RegisterType<ResponseModel>().AsSelf();
            builder.RegisterType<CategoryModel>().AsSelf();
            builder.RegisterType<ProductModel>().AsSelf();
            builder.RegisterType<FileHelper>().As<IFileHelper>().InstancePerLifetimeScope();
            builder.RegisterType<CompanyModel>().AsSelf();
            builder.RegisterType<Product>().AsSelf();
            builder.RegisterType<OrderDetailModel>().AsSelf();
            builder.RegisterType<UserModel>().AsSelf();
			builder.RegisterType<OrderDetailsVM>().AsSelf();
            builder.RegisterType<DashboardModel>().AsSelf();


            builder.RegisterType<ShoppingCartVM>().AsSelf();
            
            //builder.RegisterType<FileHelper>().As<IFileHelper>()
            //    .InstancePerLifetimeScope();
          
            base.Load(builder);
        }
    }
}
