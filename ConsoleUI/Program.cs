using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarList();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ColorName + " /// " + item.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
