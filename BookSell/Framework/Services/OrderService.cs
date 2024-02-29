using Framework.Entities;
using Framework.UnitOfWorkPro;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Services
{
  public  class OrderService: IOrderService
    {
        private ISellUnitOfWork _sellUnitOfWork;
        public OrderService(ISellUnitOfWork sellUnitOfWork)
        {
            _sellUnitOfWork = sellUnitOfWork;
        }
        public void Dispose()
        {
            _sellUnitOfWork.Dispose();
        }
        //varar entity = (await _AndSUnitOfWork.QuestionRepository.GetAsync(a => a.Id == id,
        //        b => b.Include(c => c.Tags).Include(c => c.Answers).ThenInclude(d => d.Comments))).FirstOrDefault();
        public OrderDetails GetDetails(int id)
        {
            var detailsObj = _sellUnitOfWork.OrderDetailsRepository.
                Get(x=>x.Id==id,p=>p.Include(q=>q.Product).Include(r=>r.OrderHeader)).FirstOrDefault();
             return detailsObj;  
        }
        public (IList<OrderHeader> orderHeaders, int total, int totalDisplay) GetDetails(int pageindex, int Pagesize,
                                                                                   string searchText, string orderBy)
        {
            var result = _sellUnitOfWork.OrderHeaderRepository.
                GetDynamic(null, orderBy, "AUser", pageindex, Pagesize, true);
            return (result.data, result.total, result.totalDisplay);
        }
    }
}
