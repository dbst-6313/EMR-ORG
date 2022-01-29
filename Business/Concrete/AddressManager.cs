using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public IResult Add(Addresses address)
        {
            _addressDal.Add(address);
            return new SuccessResult("");
        }

        public IResult Delete(Addresses address)
        {
            _addressDal.Delete(address);
            return new SuccessResult("");
        }

        public IDataResult<List<Addresses>> GetAll()
        {
            return new SuccessDataResult<List<Addresses>>(_addressDal.GetAll());
        }

        public IDataResult<Addresses> GetById(int Id)
        {
            return new SuccessDataResult<Addresses>(_addressDal.Get(a=>a.UserId == Id));
        }

        public IResult Update(Addresses address)
        {
            _addressDal.Update(address);
            return new SuccessResult("");
        }
    }
}
