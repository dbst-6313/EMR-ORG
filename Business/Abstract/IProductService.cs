using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Products product);
        IResult Update(Products product);
        IResult Delete(Products product);
        IDataResult<List<Products>> GetAll();
        IDataResult<Products> GetById(int Id);
        IDataResult<List<ProductDetailsDto>> GetProductDetails();
        IDataResult<List<ProductDetailsDto>> GetProductDetailsById(int id);
        IDataResult<List<ProductDetailsDto>> GetProductDetailsByCategoryId(int categoryId);
    }
}
