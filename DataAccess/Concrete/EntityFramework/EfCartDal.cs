using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepositoryBase<Carts, EmrOrgContext>, ICartDal
    {
        public List<CartDetailsDto> GetCartDetails(Expression<Func<Carts, bool>> filter = null)
        {
            using (var context = new EmrOrgContext())
            {
                var result = from c in filter == null ? context.cart : context.cart.Where(filter)
                             join p in context.product
                             on c.Id equals p.Id
                             join b in context.brand
                             on p.BrandId equals b.Id
                             join category in context.category
                             on p.CategoryId equals category.Id
                             join color in context.color
                             on p.ColorId equals color.Id
                             select new CartDetailsDto
                             {
                                 ProductDescription = p.ProductDescription,
                                 ProductDimensions = p.ProductDimensions,
                                 ProductDiscountedPrice = p.ProductDiscountedPrice,
                                 ProductName = p.ProductName,
                                 ProductPrice = p.ProductPrice,
                                 BrandName = b.Name,
                                 CategoryName = category.Name,
                                 ColorName = color.Name,
                                 ProductId = c.ProductId,
                                 Id = c.Id,
                                 ProductWeight = p.ProductWeight,
                                 Quantity = c.Quantity,
                                 UnitsInStock = p.UnitsInStock,
                                 ProductShortDescription = p.ProductShortDescription,
                                 Images = (from i in context.product_image where i.ProductId == p.Id select i.ImagePath).ToList(),
                             };
                return result.ToList();
            }

        }
            public List<CartDetailsDto> GetCartDetailsByUserId(int userId)
            {
                using (var context = new EmrOrgContext())
                {
                    var result = from c in context.cart where c.UserId== userId
                                 join p in context.product
                                 on c.Id equals p.Id
                                 join b in context.brand
                                 on p.BrandId equals b.Id
                                 join category in context.category
                                 on p.CategoryId equals category.Id
                                 join color in context.color
                                 on p.ColorId equals color.Id
                                 select new CartDetailsDto
                                 {
                                     UserId = c.UserId,
                                     ProductDescription = p.ProductDescription,
                                     ProductDimensions = p.ProductDimensions,
                                     ProductDiscountedPrice = p.ProductDiscountedPrice,
                                     ProductName = p.ProductName,
                                     ProductPrice = p.ProductPrice,
                                     BrandName = b.Name,
                                     CategoryName = category.Name,
                                     ColorName = color.Name,
                                     ProductId = c.ProductId,
                                     Id = c.Id,
                                     ProductWeight = p.ProductWeight,
                                     Quantity = c.Quantity,
                                     UnitsInStock = p.UnitsInStock,
                                     ProductShortDescription = p.ProductShortDescription,
                                     Images = (from i in context.product_image where i.ProductId == p.Id select i.ImagePath).ToList(),
                                 };
                    return result.Where(p => p.UserId == userId).ToList();
                }
            }
    }
}
