 using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        //Claim
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //business codes
           
            _carDal.Add(car);
           return new SuccessResult(Messages.CarAdded);
        
        }

      
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true,Messages.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarSevice.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true,Messages.CarUpdated);
        }
        //it means, GetAll method is fetched from CacheAspect
        [CacheAspect]
        public  IDataResult<List<Car>> GetAll()
        {
           
            //if then correct we can list them
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().OrderBy(c=>c.Id).ToList(), Messages.CarListed);


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
        [CacheAspect]
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
