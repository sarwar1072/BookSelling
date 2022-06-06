using Autofac;
using Framework.Repositories;
using Framework.Services;
using Framework.UnitOfWorkPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework
{
    public class FoundationModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FoundationModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameworkContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CoverTypeRepository>().As<ICoverTypeRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderDetailsRepository>().As<IOrderDetailsRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderHeaderRepository>().As<IOrderHeaderRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>().As<IProductRepository>()
              .InstancePerLifetimeScope();

            builder.RegisterType<ShoppingCartRepository>().As<IShoppingCartRepository>()
             .InstancePerLifetimeScope();

            builder.RegisterType<SellUnitOfWork>().As<ISellUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryService>().As<ICategoryService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<CompanyService>().As<ICompanyService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<CoverTypeService>().As<ICoverTypeService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>()
                .InstancePerLifetimeScope();

            // builder.RegisterType<RazorPayConfig>().AsSelf();


            base.Load(builder);
        }
    }
}
