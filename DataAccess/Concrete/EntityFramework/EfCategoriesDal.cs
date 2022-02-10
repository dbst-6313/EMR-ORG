using Business.Abstract;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoriesDal : EfEntityRepositoryBase<Categories, EmrOrgContext>, ICategoryDal
    {
        public List<CategoryWithImage> categoryWithImages(Expression<Func<Categories, bool>> filter = null)
        {
            using(var context = new EmrOrgContext())
            {
                var result = from c in context.category
                             join cp in context.category_image
                             on c.Id equals cp.CategoryId
                             select new CategoryWithImage
                             {
                                 Id = c.Id,
                                 ImagePath = cp.ImagePath,
                                 Name = c.Name
                             };
                return result.ToList();
            }
        }
    }
}
