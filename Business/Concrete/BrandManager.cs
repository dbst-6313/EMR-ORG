using Business.Abstract;
using Core.Utilities.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brands brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brands brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDelete);
        }

        public IDataResult<List<Brands>> GetAll()
        {
            return new SuccessDataResult<List<Brands>>(_brandDal.GetAll());
        }

        public IDataResult<Brands> GetById(int Id)
        {
            return new SuccessDataResult<Brands>(_brandDal.Get(b => b.Id == Id));
        }

        public IResult Update(Brands brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdate);
        }
    }
}
