﻿using DataAccessLayer;
using Membership.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Framework.Entities
{
    public class OrderHeader: IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser AUser { get; set; }
        //public OrderDetails OrderDetails { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
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
    }
}
