using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _ProductImageDal;

        public ProductImageManager(IProductImageDal ProductImageDal)
        {
            _ProductImageDal = ProductImageDal;
        }
      
        public IResult Add(IFormFile file, ProductImages ProductImage)
        {
            var imageLımıt = _ProductImageDal.GetAll(d => d.ProductId == ProductImage.ProductId).Count;
            if (imageLımıt > 6)
            {
                return new ErrorResult(Messages.ProductUpdated);
            }
            var ProductImageResult = FileHelper.Upload(file);
            if (!ProductImageResult.Success)
            {
                return new ErrorResult(ProductImageResult.Message);
            }
            ProductImage.ImagePath = ProductImageResult.Message;
            _ProductImageDal.Add(ProductImage);
            return new SuccessResult(Messages.ProductUpdated);

        }

        public IResult Delete(ProductImages ProductImage)
        {
            var image = _ProductImageDal.Get(d => d.ProductImageId == ProductImage.ProductImageId);
            if (image == null)
            {
                return new ErrorResult(Messages.ProductUpdated);
            }
            FileHelper.Delete(image.ImagePath);
            _ProductImageDal.Delete(ProductImage);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<ProductImages>> GetAll()
        {
            return new SuccessDataResult<List<ProductImages>>(_ProductImageDal.GetAll());
        }

        public IDataResult<ProductImages> GetById(int Id)
        {
            return new SuccessDataResult<ProductImages>(_ProductImageDal.Get(d => d.ProductId == Id));
        }

        public IDataResult<List<ProductImages>> GetImagesByDonateId(int donateId)
        {
            IResult result = BusinessRules.Run(ProductImageCheck(donateId));
            if (result != null)
            {
                return new ErrorDataResult<List<ProductImages>>(result.Message);
            }
            return new SuccessDataResult<List<ProductImages>>(ProductImageCheck(donateId).Data);
        }

        public IResult Update(IFormFile file, ProductImages ProductImage)
        {
            var image = _ProductImageDal.Get(d => d.ProductImageId == ProductImage.ProductImageId);
            if (image == null)
            {
                return new ErrorResult(Messages.ProductUpdated);
            }
            var updated = FileHelper.Update(file, image.ImagePath);
            if (!updated.Success)
            {
                return new ErrorResult(updated.Message);
            }
            ProductImage.ImagePath = updated.Message;
            _ProductImageDal.Update(ProductImage);
            return new SuccessResult(Messages.ProductUpdated);
        }

        private IDataResult<List<ProductImages>> ProductImageCheck(int productId)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _ProductImageDal.GetAll(d => d.ProductId == productId).Any();
                if (!result)
                {
                    List<ProductImages> carimage = new List<ProductImages>();
                    carimage.Add(new ProductImages { ProductId = productId, ImagePath = path});
                    return new SuccessDataResult<List<ProductImages>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<ProductImages>>(exception.Message);
            }

            return new SuccessDataResult<List<ProductImages>>(_ProductImageDal.GetAll(d => d.ProductId == productId).ToList());
        }
    }
}
