using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class CategoryImageDto:IEntity
    {
        public int CategoryImageId { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
    }
}
