﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class PendingProducts:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int AddressId { get; set; }
    }
}
