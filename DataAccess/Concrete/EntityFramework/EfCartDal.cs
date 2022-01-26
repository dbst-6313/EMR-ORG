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
            using(var context = new EmrOrgContext())
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
                                 Id = c.Id,
                                 ProductWeight = p.ProductWeight
                                  ,
                                 Quantity = c.Quantity,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }
}
