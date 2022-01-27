using Core.DataAccess;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPendingProductsDal:IEntityRepository<PendingProducts>
    {
        List<PendingRequestDetailDto> GetPendingRequestDetailDto(Expression<Func<PendingProducts, bool>> filter = null);
    }
}
