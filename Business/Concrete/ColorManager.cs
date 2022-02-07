using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Colors colors)
        {
            _colorDal.Add(colors);
            return new SuccessResult("Renk eklendi");
        }

        public IResult Delete(Colors colors)
        {
            _colorDal.Delete(colors);
            return new SuccessResult("Renk silindi");
        }

        public IDataResult<List<Colors>> GetAllColors()
        {
            return new SuccessDataResult<List<Colors>>(_colorDal.GetAll());
        }

        public IDataResult<Colors> GetById(int id)
        {
            return new SuccessDataResult<Colors>(_colorDal.Get(p => p.Id == id));
        }

        public IResult Update(Colors colors)
        {
            _colorDal.Update(colors);
            return new SuccessResult("Renk güncellendi");
        }
    }
}
