using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPendingProductsService
    {
        IResult Add(PendingProducts pendingProducts);
        IResult Delete(PendingProducts pendingProducts);
        IResult Update(PendingProducts pendingProducts);
        IDataResult<List<PendingProducts>> GetAll();
        IDataResult<List<PendingRequestDetailDto>> GetAllDetailsByUserId(int userId);
        IDataResult<List<PendingRequestDetailDto>> GetAllDetail();
    }
}
