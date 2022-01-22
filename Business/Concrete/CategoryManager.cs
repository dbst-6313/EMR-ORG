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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Categories category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Categories category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Categories>> GetAll()
        {
            return new SuccessDataResult<List<Categories>>(_categoryDal.GetAll());
        }

        public IDataResult<Categories> GetById(int Id)
        {
            return new SuccessDataResult<Categories>(_categoryDal.Get(c => c.Id == Id));
        }

        public IResult Update(Categories category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
