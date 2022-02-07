﻿using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Core.Utilities.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Products product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
                    product.View= product.View+ product.View;

        }

    
        public IResult Delete(Products product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        public IDataResult<List<Products>> GetAll()
        {
            return new SuccessDataResult<List<Products>>(_productDal.GetAll());
        }

        public IDataResult<Products> GetById(int Id)
        {
            var product = _productDal.Get(p => p.Id == Id);
            product.View = product.View + 1;
            return new SuccessDataResult<Products>(_productDal.Get(p => p.Id == Id));

        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails(), "Hepsi listelendi");
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetailsById(int id)
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetailsById(id));
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetailsByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails(p=>p.CategoryId==categoryId));
        }

        public IResult Update(Products product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

    
    }
}
