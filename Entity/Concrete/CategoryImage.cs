﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class CategoryImage:IEntity
    {
        [Key]
        public int CategoryImageId { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
    }
}
