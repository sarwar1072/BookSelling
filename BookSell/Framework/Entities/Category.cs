using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Framework.Entities
{
    public class Category: IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        //[Display(Name="Category Name")]
        //[Required]
        //[MaxLength(50)]
        public string Name { get; set; }
    }
}
