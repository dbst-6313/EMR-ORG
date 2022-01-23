using Core.DataAccess;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Products>
    {
        List<ProductDetailsDto> GetProductDetails(Expression<Func<Products, bool>> filter = null);
        List<ProductDetailsDto> GetProductDetailsById(int id);
    }
}
