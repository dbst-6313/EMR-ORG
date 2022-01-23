using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{

    public interface IProductImageService
    {

        IDataResult<List<ProductImages>> GetAll();
        IDataResult<List<ProductImages>> GetImagesByDonateId(int productId);
        IDataResult<ProductImages> GetById(int Id);
        IResult Add(IFormFile file, ProductImages productImages);
        IResult Update(IFormFile file, ProductImages productImages);
        IResult Delete(ProductImages productImages);
    }
}
