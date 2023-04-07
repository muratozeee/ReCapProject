using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ConsoleUI
{


internal class Program
    {
        static void Main(string[] args)
        {
            //we used the constructures' information then we added from here to there 

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager=new BrandManager(new EfBrandDal());
            ColorManager colorManager=new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());


            //Customer customer1 = new Customer { CompanyName = "Tei", UserId = 1 ,Id=1};

            //User user1 = new User { Id = 1, FirstName = "Suat", LastName = "Satılmıs", 
            //    Email = "suat.stlms@gmail.com", Password = "12345" 
            //};
            //User user2 = new User { Id = 2, FirstName = "Murat", LastName = "Oz", 
            //    Email = "murat.ozeee@gmail.com", Password = "456" 
            //};
            //customerManager.Add()
            //customerManager.Add(customer1);
           

           //userManager.Add(user1);

           // userManager.Add(user2);



            //var result = carManager.GetCarDetails();
            //if (result.Success==true)
            //{
            //    foreach (var cars in result.Data)
            //    {
            //        Console.WriteLine(cars.CarName + "/" + cars.BrandName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}


            //foreach (var carDetails in carManager.GetCarDetails())
            //{
            //    Console.WriteLine($"ID={carDetails.CarId}");
            //    Console.WriteLine($"Car Name={carDetails.CarName}");
            //    Console.WriteLine($"Brand={carDetails.BrandName}");
            //    Console.WriteLine($"Color={carDetails.ColorName}");
            //    Console.WriteLine($"Daily Price={carDetails.DailyPrice}");
            //    Console.WriteLine("---------------");
            //}




            //foreach (var cars in carManager.GetAll())
            //{
            //    Console.WriteLine($"ID={cars.Id}");
            //    Console.WriteLine($"BrandID={cars.BrandId}");
            //    Console.WriteLine($"ColorID={cars.ColorId}");
            //    Console.WriteLine($"Car Name={cars.CarName}");
            //    Console.WriteLine($"Description={cars.Description}");
            //    Console.WriteLine($"Daily Price={cars.DailyPrice}");
            //    Console.WriteLine($"Brand={brandManager.GetAll().Find(b => b.Id == cars.BrandId).Name}");
            //    Console.WriteLine($"Color={colorManager.GetAll().Find(c => c.Id == cars.BrandId).Name}");

            //    Console.WriteLine("-----------------------------");
            //}


            //foreach (var colors in colorManager.GetAll())
            //{
            //    colorManager.Delete(colors);
            //}
            //foreach (var brands in brandManager.GetAll())
            //{
            //    brandManager.Delete(brands);
            //}
            //Car car1 = new Car { Id = 1, BrandId = 1, ColorId = 1, CarName = "XC5", ModelYear = 2020, DailyPrice = 1000, Description = "hatchback" };
            //Car car2 = new Car { Id = 2, BrandId = 1, ColorId = 1, CarName = "i3", ModelYear = 2022, DailyPrice = 1500, Description = "Sedan" };
            //Car car3 = new Car { Id = 3, BrandId = 1, ColorId = 2, CarName = "i4", ModelYear = 2019, DailyPrice = 1450, Description = "hatchback" };
            //Car car4 = new Car { Id = 4, BrandId = 1, ColorId = 2, CarName = "i3", ModelYear = 2005, DailyPrice = 450, Description = "SUV 4x4" };
            //Car car5 = new Car { Id = 5, BrandId = 3, ColorId = 3, CarName = "XC60", ModelYear = 2019, DailyPrice = 650, Description = "SUV 4x4" };
            //Car car6 = new Car { Id = 6, BrandId = 1, ColorId = 3, CarName = "A300", ModelYear = 2022, DailyPrice = 1750, Description = "SUV 4x4" };
            //Car car7 = new Car { Id = 7, BrandId = 4, ColorId = 4, CarName = "C200", ModelYear = 2023, DailyPrice = 500, Description = "SUV 4x4" };
            //Car car8 = new Car { Id = 8, BrandId = 2, ColorId = 4, CarName = "TX10", ModelYear = 2023, DailyPrice = 2000, Description = "SUV 4x4" };
            //Car car9 = new Car { Id = 9, BrandId = 2, ColorId = 1, CarName = "TX10", ModelYear = 2023, DailyPrice = 2000, Description = "SUV 4x4" };
            //Car car10 = new Car { Id = 10, BrandId = 3, ColorId = 2, CarName = "XC5", ModelYear = 2023, DailyPrice = 1500, Description = "SUV 4x4" };
            //Car car11 = new Car { Id = 11, BrandId = 4, ColorId = 3, CarName = "i3", ModelYear = 1995, DailyPrice = 1500, Description = "hatchback" };
            //Car car12 = new Car { Id = 12, BrandId = 4, ColorId = 4, CarName = "i3", ModelYear = 1998, DailyPrice = 1000, Description = "hatchback" };
            //Car car13 = new Car { Id = 13, BrandId = 3, ColorId = 2, CarName = "i4", ModelYear = 2016, DailyPrice = 1200, Description = "Sedan" };
            //Car car14 = new Car { Id = 14, BrandId = 3, ColorId = 1, CarName = "X5", ModelYear = 2017, DailyPrice = 1250, Description = "Sedan" };
            //Car car15 = new Car { Id = 15, BrandId = 1, ColorId = 3, CarName = "X6", ModelYear = 2018, DailyPrice = 1300, Description = "Sedan" };

            //Brand brand1 = new Brand { Id = 1, Name = "Volvo" };
            //Brand brand2 = new Brand { Id = 2, Name = "TOGG" };
            //Brand brand3 = new Brand { Id = 3, Name = "Hundai" };
            //Brand brand4 = new Brand { Id = 4, Name = "Fiat" };

            //Color color1 = new Color { Id = 1, Name = "Blue" };
            //Color color2 = new Color { Id = 2, Name = "Black" };
            //Color color3 = new Color { Id = 3, Name = "Yellow" };
            //Color color4 = new Color { Id = 4, Name = "Brown" };



            //carManager.Add(car1);
            //brandManager.Add(brand1);
            //colorManager.Add(color1);

            //carManager.Add(car2);
            //brandManager.Add(brand2);
            //colorManager.Add(color2);

            //carManager.Add(car3);
            //brandManager.Add(brand3);
            //colorManager.Add(color3);

            //carManager.Add(car4);
            //brandManager.Add(brand4);
            //colorManager.Add(color4);

            //carManager.Add(car5);
            //carManager.Add(car6);
            //carManager.Add(car7);
            //carManager.Add(car8);
            //carManager.Add(car9);
            //carManager.Add(car10);
            //carManager.Add(car12);
            //carManager.Add(car13);
            //carManager.Add(car14);
            //carManager.Add(car15);













        }
    }
}