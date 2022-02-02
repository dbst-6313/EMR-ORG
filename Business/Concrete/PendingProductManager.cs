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

        public IResult ChangeDoneStateFalse(int pendingProductId)
        {
            var product = _PendingProductsDal.Get(p => p.Id == pendingProductId);
                product.isDone = 0;
            _PendingProductsDal.Update(product);
            return new SuccessResult();
        }

        public IResult ChangeDoneStateTrue(int pendingProductId)
        {
            var product = _PendingProductsDal.Get(p => p.Id == pendingProductId);
                product.isDone = 1;
            _PendingProductsDal.Update(product);
            return new SuccessResult();
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

        public IDataResult<List<PendingRequestDetailDto>> GetAllDetail()
        {
            return new SuccessDataResult<List<PendingRequestDetailDto>>(_PendingProductsDal.GetPendingRequestDetailDto());
        }

        public IDataResult<List<PendingRequestDetailDto>> GetAllDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<PendingRequestDetailDto>>(_PendingProductsDal.GetPendingRequestDetailDto(p => p.UserId == userId));
        }

        public IDataResult<List<PendingRequestDetailDto>> GetAllDoneProducts()
        {
            return new SuccessDataResult<List<PendingRequestDetailDto>>(_PendingProductsDal.GetPendingRequestDetailDto(p=>p.isDone == 1));
        }
        public IDataResult<List<PendingRequestDetailDto>> GetAllUncompletedProducts()
        {
            return new SuccessDataResult<List<PendingRequestDetailDto>>(_PendingProductsDal.GetPendingRequestDetailDto(p => p.isDone == 0));
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
