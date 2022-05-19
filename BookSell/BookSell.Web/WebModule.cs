using Autofac;
using BookSell.Web.Areas.Admin.Models.CoverTypeFolder;
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
            //builder.RegisterType<ItemModel>().AsSelf();
            //builder.RegisterType<AuthenticationService>().As<IAuthenticationService>()
            //         .InstancePerLifetimeScope();
            //builder.RegisterType<UserAccessor>().As<IUserAccessor>()
            //     .InstancePerLifetimeScope();
            //builder.RegisterType<FileHelper>().As<IFileHelper>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<ICartService>().As
            //  .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
