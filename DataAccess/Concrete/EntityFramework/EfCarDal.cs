using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarContext context=new CarContext())
            { 
                //we join the brands and colors with cars 

                var result = (from c in context.Cars //representative c=cars
                             join b in context.Brands //representative b=brands
                             on c.BrandId equals b.Id  //we joined brands and cars we match the with id
                             join co in context.Colors //co=colors from coming the Database
                             on c.ColorId equals co.Id   //we joined the colors and cars we match the with id if they same id.
                             select new CarDetailsDto { //then 
                                 CarId=c.Id,
                                 BrandName=b.Name,
                                 CarName=c.CarName,//we found them and dtos alias were defined  database variables
                                 ColorName=co.Name,
                                 DailyPrice=c.DailyPrice 
                             }).OrderBy(c => c.CarId).ToList();

                return result; //then we listed in result variable.

                         
            }
        }
    }
}
