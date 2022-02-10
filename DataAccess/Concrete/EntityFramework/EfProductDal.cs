﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Products, EmrOrgContext>, IProductDal
    {
  
        public List<ProductDetailsDto> GetProductDetails(Expression<Func<Products, bool>> filter = null)
        {

            using (var context = new EmrOrgContext())
         
            {
                var product = from p in filter == null ? context.product : context.product.Where(filter)
                              join c in context.category
                              on p.CategoryId equals c.Id
                              join b in context.brand
                              on p.BrandId equals b.Id
                              join col in context.color
                              on p.ColorId equals col.Id
                              select new ProductDetailsDto
                              {
                                  ColorName = col.Name,
                                  ProductDimensions = p.ProductDimensions,
                                  ProductWeight = p.ProductWeight,
                                  CategoryId = c.Id,
                                  BrandName = b.Name,
                                  BrandId = p.BrandId,
                                  CategoryName = c.Name,
                                  ColorId=col.Id,
                                  Id = p.Id,
                                  ProductDescription = p.ProductDescription,
                                  View=p.View,
                                  ProductDiscountedPrice = p.ProductDiscountedPrice,
                                  ProductName = p.ProductName,
                                  ProductPrice = p.ProductPrice,
                                  ProductShortDescription = p.ProductShortDescription,
                                  UnitsInStock = p.UnitsInStock,
                                  Images = (from i in context.product_image where i.ProductId == p.Id select i.ImagePath).ToList(),
                                  AddDate = p.AddDate
                              };
                return product.ToList();
            }
        }
        public List<ProductDetailsDto> GetProductDetailsById(int id)
        {

            using (var context = new EmrOrgContext())

            {
                var product = from p in context.product where p.Id == id
                              join c in context.category
                              on p.CategoryId equals c.Id
                              join b in context.brand
                              on p.BrandId equals b.Id
                              join col in context.color

                             on p.ColorId equals col.Id
                              select new ProductDetailsDto
                              {
                                  ColorName = col.Name,
                                  ProductDimensions = p.ProductDimensions,
                                  ProductWeight = p.ProductWeight,
                                  BrandId=p.BrandId,
                                  CategoryId = c.Id,
                                  View = p.View,
                                  BrandName = b.Name,
                                  ProductShortDescription = p.ProductShortDescription,
                                  CategoryName = c.Name,
                                  Id = p.Id,
                                  ColorId=col.Id,
                                  ProductDescription = p.ProductDescription,
                                  ProductDiscountedPrice = p.ProductDiscountedPrice,
                                  ProductName = p.ProductName,
                                  ProductPrice = p.ProductPrice,
                                  UnitsInStock = p.UnitsInStock,
                                  Images = (from i in context.product_image where i.ProductId == p.Id select i.ImagePath).ToList(),
                                  AddDate = p.AddDate
                              };
                return product.Where(p=>p.Id == id).ToList();
            }
        }
    }
}
