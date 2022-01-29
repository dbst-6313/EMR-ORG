using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAddressService
    {
        IResult Add(Addresses address);
        IResult Delete(Addresses address);
        IResult Update(Addresses address);
        IDataResult<List<Addresses>> GetAll();
        IDataResult<Addresses> GetById(int Id);
    }
}
