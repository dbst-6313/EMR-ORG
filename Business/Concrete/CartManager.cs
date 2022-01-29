using Business.Abstract;
using Core.Utilities.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CartsManager:ICartService
    {
        ICartDal _cartsDal;

        public CartsManager(ICartDal cartsDal)
        {
            _cartsDal = cartsDal;
        }

        public IResult Add(Carts cart)
        {
            _cartsDal.Add(cart);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Carts cart)
        {
            _cartsDal.Delete(cart);
            return new SuccessResult("s");
        }

        public IDataResult<List<Carts>> GetAll()
        {
            return new SuccessDataResult<List<Carts>>(_cartsDal.GetAll());
        }

        public IDataResult<Carts> GetById(int Id)
        {
            return new SuccessDataResult<Carts>(_cartsDal.Get(b => b.Id == Id));
        }

        public IDataResult<List<CartDetailsDto>> GetCartDetails()
        {
            return new SuccessDataResult<List<CartDetailsDto>>(_cartsDal.GetCartDetails(), "sa");
        }

        public IDataResult<List<CartDetailsDto>> GetCartDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<CartDetailsDto>>(_cartsDal.GetCartDetailsByUserId(userId), "Succes");
        }

        public IResult Update(Carts cart)
        {
            _cartsDal.Update(cart);
            return new SuccessResult(Messages.AnswerAdded);
        }
    }
}
