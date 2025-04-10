﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Framework.Entities
{
    public class CoverType: IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
