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
    public class RentalManager : IRentalService
    {
        IRentalDal rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            this.rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            rentalDal.Add(rental);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Rental rental)
        {
            rentalDal.Delete(rental);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(rentalDal.Get(x => x.RentalId == id));
        }

        public IResult Update(Rental rental)
        {
            rentalDal.Update(rental);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
