using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ProductAdded);
            
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(x => x.ColorId == id));
        }

        public IResult Update(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.ProductUpdated);
            
        }
    }
}
