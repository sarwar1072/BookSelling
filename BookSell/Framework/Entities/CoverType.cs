using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Framework.Entitiess
{
    public class CoverType: IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        //[Display(Name= "Cover Type")]
        //[Required]
        //[MaxLength(50)]
        public string Name { get; set; }
    }
}
