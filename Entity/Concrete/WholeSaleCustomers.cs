using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
   public class WholeSaleCustomers:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int IsConfirmed { get; set; }
    }
}
