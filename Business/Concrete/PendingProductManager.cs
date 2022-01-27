using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PendingProductManager : IPendingProductsService
    {
        private IPendingProductsDal _PendingProductsDal;

        public PendingProductManager(IPendingProductsDal PendingProductsDal)
        {
            _PendingProductsDal = PendingProductsDal;
        }

        public IResult Add(PendingProducts PendingProducts)
        {
            _PendingProductsDal.Add(PendingProducts);
            return new SuccessResult("");
        }

        public IResult Delete(PendingProducts PendingProducts)
        {
            _PendingProductsDal.Delete(PendingProducts);
            return new SuccessResult("");
        }

        public IDataResult<List<PendingProducts>> GetAll()
        {
            return new SuccessDataResult<List<PendingProducts>>(_PendingProductsDal.GetAll());
        }

        public IDataResult<List<PendingRequestDetailDto>> GetAllDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<PendingRequestDetailDto>>(_PendingProductsDal.GetPendingRequestDetailDto(p => p.UserId == userId));
        }

        public IDataResult<PendingProducts> GetById(int Id)
        {
            return new SuccessDataResult<PendingProducts>(_PendingProductsDal.Get(a=>a.Id == Id));
        }

        public IResult Update(PendingProducts PendingProducts)
        {
            _PendingProductsDal.Update(PendingProducts);
            return new SuccessResult("");
        }
    }
}
