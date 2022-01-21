using Business.Abstract;
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
        }

        public IResult Delete(Products product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        [SecuredOperation("admin")]
        public IDataResult<List<Products>> GetAll()
        {
            return new SuccessDataResult<List<Products>>(_productDal.GetAll());
        }

        public IDataResult<Products> GetById(int Id)
        {
            return new SuccessDataResult<Products>(_productDal.Get(p => p.Id == Id));
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetProductDetails(), "Hepsi listelendi");
        }

        public IResult Update(Products product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
