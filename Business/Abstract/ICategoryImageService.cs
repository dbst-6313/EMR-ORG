using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryImageService
    {
        IDataResult<List<CategoryImage>> GetAll();
        IDataResult<CategoryImage> GetById(int Id);
        IResult Add(CategoryImage categoryImage, IFormFile file);
        IResult Update(IFormFile file, CategoryImage categoryImage);
        IResult Delete(CategoryImage categoryImage);
    }
}
