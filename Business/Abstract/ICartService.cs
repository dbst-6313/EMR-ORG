using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICartService
    {
        IResult Add(Carts carts);
        IResult Update(Carts carts);
        IResult Delete(Carts carts);
        IDataResult<List<CartDetailsDto>> GetCartDetailsByUserId(int userId);
        IDataResult<List<Carts>> GetAll();

    }
}
