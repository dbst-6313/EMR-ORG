using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brands brand);
        IResult Delete(Brands brand);
        IResult Update(Brands brand);
        IDataResult<List<Brands>> GetAll();
        IDataResult<Brands> GetById(int Id);
    }
}
