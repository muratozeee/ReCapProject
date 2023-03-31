using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _Car; //Global Variable,,,Name Convention...!

        public InMemoryCarDal()
           

        {//Oracle,Sql,Postgres,MongoDb we can see that...!
            _Car=new List<Car> { 
                new Car() {BrandId=1,ColorId=1,Id=1,Description="Mercedes",ModelYear=2023,DailyPrice=10000 },
                new Car() {BrandId=1,ColorId=2,Id=2,Description="Volkswagen",ModelYear=2022,DailyPrice=750 },
                new Car() {BrandId=2,ColorId=3,Id=3,Description="Fiat",ModelYear=2021,DailyPrice=500 },
                new Car() {BrandId=2,ColorId=4,Id=4,Description="Ford",ModelYear=2020,DailyPrice=300 },
            };
        }

        public void Add(Car car)
        {
            _Car.Add(car); // we are takin from Business-UI we are adding the data base...!
        }

        public void Delete(Car car)
        {
            Car carToDelete = _Car.SingleOrDefault(c => c.Id == car.Id);
            //Linq


            _Car.Remove(carToDelete);
        }

       

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _Car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
         return _Car.Where(c=>c.Id==id).ToList();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
           return _Car.Where(b=>b.Id ==brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _Car.Where(c => c.Id ==colorId).ToList();
        }

        public void Update(Car car)
        {

            Car carToUpdate = _Car.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;


        }
    }
}
