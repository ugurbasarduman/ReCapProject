using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.ColorId == id));
        }
        public IResult Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
            }
            else
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.ProductUpdated);
            }
            else
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.CarId == id));
        }

        public IDataResult<List<CarListDto>> GetCarList()
        {
            return new SuccessDataResult<List<CarListDto>>(_carDal.GetCarList());
        }
    }
}
