using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;
        IBrandDal _brandDal;

        public CarManager(DataAccess.Concrete.EntityFramework.EfCarDal efCarDal, IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll(); //if then correct we can list them
        }

        public List<Brand> GetCarsByBrand(string brand)
        {
            if (brand.Length>=2)
            {
                return _brandDal.GetAll(p => p.Name == brand);
            }
            else
            {
                return _brandDal.GetAll();
            }
           
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

      
       

        public List<Car> GetCarsByDailyPrice(decimal price)
        {
            if (price>0)
            {
                return _carDal.GetAll(p => p.DailyPrice == price);
            }
            else
            {
                return _carDal.GetAll();
            }
            
            
        }
    }
}
