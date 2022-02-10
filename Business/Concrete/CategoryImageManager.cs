using Business.Abstract;
using Core.Utilities.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryImageManager : ICategoryImageService
    {
        ICategoryImageDal _categoryImageDal;

        public CategoryImageManager(ICategoryImageDal categoryImageDal)
        {
            _categoryImageDal = categoryImageDal;
        }

        public IResult Add(CategoryImage categoryImage, IFormFile file)
        {
            var imageLımıt = _categoryImageDal.GetAll(c => c.CategoryId == categoryImage.CategoryId).Count;
            if (imageLımıt>6)
            {
                return new ErrorResult();
            }
            var CategoryImageResult = CategoryFileHelper.Upload(file);
            if (!CategoryImageResult.Success)
            {
                return new ErrorResult(CategoryImageResult.Message);
            }
            categoryImage.ImagePath = CategoryImageResult.Message;
            _categoryImageDal.Add(categoryImage);
            return new SuccessResult(Messages.CategoryImageAdded);

        }

        public IResult Delete(CategoryImage categoryImage)
        {
            var image = _categoryImageDal.Get(d => d.CategoryImageId == categoryImage.CategoryImageId);
            if (image == null)
            {
                return new ErrorResult();
            }
            CategoryFileHelper.Delete(image.ImagePath);
            _categoryImageDal.Delete(categoryImage);
            return new SuccessResult();
        }

        public IDataResult<List<CategoryImage>> GetAll()
        {
            return new SuccessDataResult<List<CategoryImage>>(_categoryImageDal.GetAll());
        }

        public IDataResult<CategoryImage> GetById(int Id)
        {
            return new SuccessDataResult<CategoryImage>(_categoryImageDal.Get(d => d.CategoryImageId== Id));
        }

        public IResult Update(IFormFile file, CategoryImage categoryImage)
        {
            var image = _categoryImageDal.Get(d => d.CategoryImageId == categoryImage.CategoryImageId);
            if (image == null)
            {
                return new ErrorResult();
            }
            var updated = CategoryFileHelper.Update(file, image.ImagePath);
            if (!updated.Success)
            {
                return new ErrorResult(updated.Message);
            }
            categoryImage.ImagePath = updated.Message;
            _categoryImageDal.Update(categoryImage);
            return new SuccessResult();
        }
    }
}
