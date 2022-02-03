using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Carts:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
    }
}
