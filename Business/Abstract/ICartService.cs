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
        IResult Delete(Carts carts);
        IResult Update(Carts carts);
        IDataResult<List<Carts>> GetAll();
        IDataResult<List<CartDetailsDto>> GetCartDetails();
        IDataResult<List<CartDetailsDto>> GetCartDetailsByUserId(int userId); 
    }
}
