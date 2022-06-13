using BookSell.Web.Models;
using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.OrderDetailsModel
{
    public class OrderDetailModel:OrderDetailsBaseModel
    {
        public OrderDetailModel() : base() { }      
        public OrderDetailModel(IOrderService orderService) : base() { }       
        internal object GetOrder(DataTablesAjaxRequestModel dataTables)
        {
            var data = _ordrService.GetDetails(
                                                     dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "OrderHeader","Count" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.orderDetails
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.OrderHeader.Name,
                                record.OrderHeader.PhoneNumber,
                                record.OrderHeader.OrderStatus,
                                record.Price.ToString(),
                                record.Id.ToString()
                        }).ToArray()
            };
        }

    }
}
