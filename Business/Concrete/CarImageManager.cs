using Business.Abstract;
using Business.Constants;

using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

//﻿using Business.Abstract;


namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelperService _fileHelperService;


        public CarImageManager(ICarImageDal carImageDal,IFileHelperService fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;

        }

        
        //IFormFile it means for HTTP protocol for file to request.
        public IResult Add(IFormFile file, CarImage carImage)
        {
            //used the Polymorphism to use rules. I wrote the rule method at below side
            IResult result = BusinessRules.Run(CheckForCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelperService.Upload(file, PathConstants.CarImagesPath);
            carImage.ImageDate = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);

        }

        public IResult Delete(CarImage carImage)
        {
            //for safety we added each other after that we can find the way then we can delete it.
            _fileHelperService.Delete(PathConstants.CarImagesPath + carImage.ImagePath);
            //then we delete the in dataBase.
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);

        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == id), Messages.ImagesListedById);
          
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            //Firstly Update the ImageFilePath
            carImage.ImagePath = _fileHelperService.Update(file, PathConstants.CarImagesPath + carImage.ImagePath, 
                PathConstants.CarImagesPath);
           //Then Update the Upload time for image.When they uploaded in the system.
            carImage.ImageDate = DateTime.Now;
            //Then Update the Database ImageFilePath
            _carImageDal.Update(carImage);
            //everything Success result messages
            return new SuccessResult(Messages.ImageUpdated);
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckImageExists(id));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(id).Data);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id), Messages.ImagesListedByCarId);
        }

        //ImageLimit can not more 5 photos...
        private IResult CheckForCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitReached);
            }
            return new SuccessResult();

        }

        private IResult CheckImageExists(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;

            if (result > 0)
            {
                return new ErrorResult(Messages.CarImageAlreadyHave);
            }
            return new SuccessResult();

        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage { CarId = carId, ImageDate = DateTime.Now, ImagePath = "DefaultImage.jpg" });

            return new SuccessDataResult<List<CarImage>>(carImages);
        }

    }

}
