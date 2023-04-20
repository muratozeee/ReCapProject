using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice>0 && car.CarName.Length>=2)
            {
                _carDal.Add(car);
                
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
              //magic strings
                return new ErrorResult(Messages.CarNameİnvalid);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true,Messages.CarDeleted);
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true,Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //if then correct we can list them
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);


            //if false=
            // return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.BrandId==id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<Car>> GetsCarsId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.Id == id));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }
    }
}
