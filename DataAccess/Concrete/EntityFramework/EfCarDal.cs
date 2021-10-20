using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public List<CarListDto> GetCarList()
        {
            using (RecapContext context = new RecapContext())
            {
                var lists = from c in context.Cars
                            join b in context.Brands on c.BrandId equals b.BrandId
                            join co in context.Colors on c.ColorId equals co.ColorId
                            select new CarListDto { BrandName = b.BrandName, CarId = c.CarId, CarName = c.CarName, ColorName = co.ColorName, DailyPrice = c.DailyPrice };
                return lists.ToList();
                            
                            
            }
        }
    }
}
