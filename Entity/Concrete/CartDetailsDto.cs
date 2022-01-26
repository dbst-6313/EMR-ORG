using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class CartDetailsDto:IDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductDimensions { get; set; }
        public int ProductPrice { get; set; }
        public int ProductDiscountedPrice { get; set; }
        public int ProductWeight { get; set; }
        public int UnitsInStock { get; set; }
        public int Quantity { get; set; }
    }
}
