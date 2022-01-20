using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class RetailCustomers:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
