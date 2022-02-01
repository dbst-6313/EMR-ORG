using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class PendingRequestDetailDto:IDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string ProductShortDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public int IsConfirmed { get; set; } = 2;
        public int isDone { get; set; } = 0;
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string HouseId { get; set; }
        public string ExtraDescription { get; set; }
        public DateTime ProductDate { get; set; } = DateTime.Now;
        public int Quantity { get; set; }

    }
}
