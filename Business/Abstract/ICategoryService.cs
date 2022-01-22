using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Categories category);
        IResult Delete(Categories category);
        IResult Update(Categories category);
        IDataResult<List<Categories>> GetAll();
        IDataResult<Categories> GetById(int Id);
    }
}
