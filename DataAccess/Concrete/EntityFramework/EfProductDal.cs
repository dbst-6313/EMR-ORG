using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Products, EmrOrgContext>, IProductDal
    {
        public List<ProductDetailsDto> GetProductDetails()
        {

            using (var context = new EmrOrgContext())
         
            {
                var product = from p in context.product
                              join c in context.category
                              on p.CategoryId equals c.Id
                              join b in context.brand
                              on p.BrandId equals b.Id
                              select new ProductDetailsDto
                              {
                                  BrandName = b.Name,
                                  CategoryName = c.Name,
                                  Id = p.Id,
                                  ProductDescription = p.ProductDescription,
                                  ProductDiscountedPrice = p.ProductDiscountedPrice,
                                  ProductName = p.ProductName,
                                  ProductPrice = p.ProductPrice,
                                  UnitsInStock = p.UnitsInStock

                              };
                return product.ToList();
            }
        }
    }
}
