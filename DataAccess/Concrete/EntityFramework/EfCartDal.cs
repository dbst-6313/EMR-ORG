using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCartDal:EfEntityRepositoryBase<Carts,EmrOrgContext>,ICartDal
    {
        public List<CartDetailsDto> GetCartDetailsByUserId(int userId)
        {
            using (var context = new EmrOrgContext())
                {
                var result = from cart in context.cart
                             where cart.UserId == userId
                             join product in context.product
                             on cart.ProductId equals product.Id
                             join brand in context.brand
                             on product.BrandId equals brand.Id
                             join color in context.color
                             on product.ColorId equals color.Id
                             join category in context.category
                             on product.CategoryId equals category.Id
                             select new CartDetailsDto
                             {
                                 ProductShortDescription = product.ProductShortDescription,
                                 UnitsInStock = product.UnitsInStock,
                                 BrandName = brand.Name,
                                 CategoryName = category.Name,
                                 ColorName = color.Name,
                                 Id = cart.Id,
                                 ProductId = product.Id,
                                 Images = (from i in context.product_image where i.ProductId == cart.ProductId select i.ImagePath).ToList(),
                                 ProductDescription = product.ProductDescription,
                                 ProductDimensions = product.ProductDimensions,
                                 ProductDiscountedPrice = product.ProductDiscountedPrice,
                                 ProductName=product.ProductName,
                                 ProductPrice=product.ProductPrice,
                                 ProductWeight=product.ProductWeight,
                                 Quantity=cart.Quantity
                             };
                return result.ToList();
            }
        }
    }
}
