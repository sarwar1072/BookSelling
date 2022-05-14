using DataAccessLayer;
using Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.UnitOfWorkPro
{
    public interface ISellUnitOfWork:IUnitOfWork
    {
         ICategoryRepository CategoryRepository { get; set; }
         ICompanyRepository CompanyRepository { get; set; }
         ICoverTypeRepository CoverTypeRepository { get; set; }
         IOrderDetailsRepository OrderDetailsRepository { get; set; }
         IOrderHeaderRepository OrderHeaderRepository { get; set; }
         IProductRepository ProductRepository { set; get; }
         IShoppingCartRepository ShoppingCartRepository { get; set; }
    }
}
