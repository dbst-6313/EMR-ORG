using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Concrete
{
    public class ProductImages:IEntity
    {
        [Key]
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
    }
}
