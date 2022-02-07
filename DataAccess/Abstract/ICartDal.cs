using Business.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICartDal:IEntityRepository<Carts>
    {
        List<CartDetailsDto> GetCartDetailsByUserId(int userId);
    }
}
