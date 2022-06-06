using DataAccessLayer;
using Membership.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Framework.Entities
{
    public class ShoppingCart: IEntity<int>
    {
        public ShoppingCart()
        {
            Count = 1;
        }
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        //[ForeignKey("ApplicationUserId")]
        [NotMapped]

        public ApplicationUser AUser { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Count { get; set; }
        [NotMapped]
        public double Price { get; set; }
    }
}
