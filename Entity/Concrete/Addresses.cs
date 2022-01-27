using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Addresses:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string HouseId { get; set; }
        public string ExtraDescription { get; set; }
    }
}
