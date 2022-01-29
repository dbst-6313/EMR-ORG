
using Core.DataAccess;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICartDal:IEntityRepository<Carts>
    {
        List<CartDetailsDto> GetCartDetails(Expression<Func<Carts,bool>> filter=null);
        List<CartDetailsDto> GetCartDetailsByUserId(int userId);
    }
}
