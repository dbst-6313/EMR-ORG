using Business.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Categories>
    {
        List<CategoryWithImage> categoryWithImages(Expression<Func<Categories, bool>> filter = null);
    }
}
