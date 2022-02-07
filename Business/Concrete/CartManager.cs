using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CartManager : ICartService

    {
        ICartDal _cartsDal;

        public CartManager(ICartDal cartsDal)
        {
            _cartsDal = cartsDal;
        }

        public IResult Add(Carts carts)
        {
            var allCarts = _cartsDal.GetAll();
            bool isUpdated = false;
            foreach (var item in allCarts)
            {
                if (carts.ProductId == item.ProductId)
                {
                    carts.Quantity = item.Quantity + carts.Quantity;
                    carts.Id = item.Id;
                    _cartsDal.Update(carts);
                    isUpdated = true;
                }

            }
            if (isUpdated == false)
            {
                _cartsDal.Add(carts);
            }
            return new SuccessResult("Ürün Sepete Eklendi");

        }

        public IResult Delete(Carts carts)
        {
            _cartsDal.Delete(carts);
            return new SuccessResult("Ürün Sepetten Silindi");
        }

        public IDataResult<List<Carts>> GetAll()
        {
            return new SuccessDataResult<List<Carts>>(_cartsDal.GetAll());
        }

        public IDataResult<List<CartDetailsDto>> GetCartDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<CartDetailsDto>>(_cartsDal.GetCartDetailsByUserId(userId), "Başarılı");
        }

        public IResult Update(Carts carts)
        {
            _cartsDal.Update(carts);
            return new SuccessResult("Sepetiniz Güncellendi");
        }
    }
}
