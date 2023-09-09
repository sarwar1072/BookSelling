using Autofac;
using Framework.Entities;
using Framework.Services;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BookSell.Web.Areas.Admin.Models.OrderDetailsModel
{
    public class OrderDetailVM: OrderDetailsBaseModel
    {
        public OrderDetailVM(IOrderService ordrService) : base(ordrService) { }     
        public OrderDetailVM() : base() { }
        public int Id { get; set; }
        public Double OrderTotal { get; set; }
        public string TrackingNumber { get; set; }
        public string Carrier { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public string TransactionId { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public string Title { get; set; }
        public Double Price { get; set; }
        public int Count { get; set; }
        public DateTime ShippingDate { get; set; }
        public IEnumerable<OrderHeader> OrderHeaders { get; set; }
        public IEnumerable<OrderDetailsVM> OrderDetails { get; set; }
       // public IEnumerable<OrderDetailsVM> OrderDetailsVM { get; set; }
        public void Submitorder()
        {
            var entity = new OrderDetails {
              // OrderHeader.Name = Name,
                //OrderHeader.PhoneNumber=PhoneNumber,
                //OrderHeader.StreetAddress=StreetAddress,
                //OrderHeader.City=City,
                //OrderHeader.State=State,
                //OrderHeader.PostalCode=PostalCode,
                //OrderHeader.OrderDate=OrderDate,
                //OrderHeader.OrderStatus=OrderStatus,
              //  Count=Count,
                            
            };

        }
        public void Load(int id)
        {
            var data = _ordrService.GetDetails(id);
            if (data != null)
            {
                Id = data.Id;
                Name = data.OrderHeader.Name;
                PhoneNumber = data.OrderHeader.PhoneNumber;
                StreetAddress = data.OrderHeader.StreetAddress;
                //  OrderTotal=data.OrderHeader.OrderTotal; 
                City = data.OrderHeader.City;
                State = data.OrderHeader.State;
                PostalCode = data.OrderHeader.PostalCode;
                OrderDate = data.OrderHeader.OrderDate;
                OrderStatus = data.OrderHeader.OrderStatus;
                //Title = data.Product.Title;
                //Price = data.Product.Price;
                //Count = data.Count;
               OrderDetails =new List<OrderDetailsVM>() ;
                
                
            }
        }

    }
}

