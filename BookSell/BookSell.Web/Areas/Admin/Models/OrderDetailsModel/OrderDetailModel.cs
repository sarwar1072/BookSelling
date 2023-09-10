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
        public OrderDetailModel(IOrderService orderService) : base(orderService) { }       
        internal object GetOrder(DataTablesAjaxRequestModel dataTables)
        {
            var data = _ordrService.GetDetails(
                                                     dataTables.PageIndex,
                                                     dataTables.PageSize,
                                                     dataTables.SearchText,
                                                     dataTables.GetSortText(new string[] { "Name"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.orderHeaders
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Name,
                                record.PhoneNumber,
                                //record.OrderHeader.AUser.Email,
                                record.OrderStatus,
                                record.OrderTotal.ToString(),
                                record.Id.ToString()
                        }).ToArray()
            };
        }

    }
}
