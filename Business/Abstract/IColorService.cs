using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Colors colors);
        IResult Update(Colors colors);
        IResult Delete(Colors colors);
        IDataResult<List<Colors>> GetAllColors();
        IDataResult<Colors> GetById(int id);
    }
}
