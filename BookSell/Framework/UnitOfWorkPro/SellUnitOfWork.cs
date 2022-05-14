using DataAccessLayer;
using Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.UnitOfWorkPro
{
   public class SellUnitOfWork:UnitOfWork,ISellUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public ICompanyRepository CompanyRepository { get; set; }
        public ICoverTypeRepository CoverTypeRepository { get; set; }
        public IOrderDetailsRepository OrderDetailsRepository { get; set; }
        public IOrderHeaderRepository OrderHeaderRepository { get; set; }
        public IProductRepository ProductRepository { set; get; }
        public IShoppingCartRepository ShoppingCartRepository { get; set; }
        public SellUnitOfWork(FrameworkContext frameworkContext,
            ICategoryRepository categoryRepository,
            ICompanyRepository companyRepository,
            ICoverTypeRepository coverTypeRepository,
            IOrderDetailsRepository orderDetailsRepository,
            IOrderHeaderRepository orderHeaderRepository,
            IProductRepository productRepository,
            IShoppingCartRepository shoppingCartRepository):base(frameworkContext)
        {
            CategoryRepository = categoryRepository;
            CompanyRepository = companyRepository;
            CoverTypeRepository = coverTypeRepository;
            OrderDetailsRepository = orderDetailsRepository;
            OrderHeaderRepository = orderHeaderRepository;
            ProductRepository = productRepository;
            ShoppingCartRepository = shoppingCartRepository;            
        }
    }
}
