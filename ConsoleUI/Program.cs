using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

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

            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine($"ID={cars.Id}");
                Console.WriteLine($"BrandID={cars.BrandId}");
                Console.WriteLine($"ColorID={cars.ColorId}");
                Console.WriteLine($"Car Name={cars.CarName}");
                Console.WriteLine($"Description={cars.Description}");
                Console.WriteLine($"Daily Price={cars.DailyPrice}");

                Console.WriteLine("-----------------------------");
            }


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
            //Brand brand2 = new Brand { Id = 2, Name = "Hundai" };
            //Brand brand3 = new Brand { Id = 3, Name = "Fiat" };
            //Brand brand4 = new Brand { Id = 4, Name = "Mercedes" };
            //Brand brand5 = new Brand { Id = 5, Name = "Mercedes" };
            //Brand brand6 = new Brand { Id = 6, Name = "Volvo" };
            //Brand brand7 = new Brand { Id = 7, Name = "Volvo" };
            //Brand brand8 = new Brand { Id = 8, Name = "TOGG" };
            //Brand brand9 = new Brand { Id = 9, Name = "TOGG" };
            //Brand brand10 = new Brand { Id = 10, Name = "Volvo" };
            //Brand brand11 = new Brand { Id = 11, Name = "Volvo" };
            //Brand brand12 = new Brand { Id = 12, Name = "Volvo" };
            //Brand brand13 = new Brand { Id = 13, Name = "Renult" };
            //Brand brand14 = new Brand { Id = 14, Name = "Renult" };
            //Brand brand15 = new Brand { Id = 15, Name = "Lexus" };

            //Color color1 = new Color { Id = 1, Name = "Blue" };
            //Color color2 = new Color { Id = 2, Name = "Black" };
            //Color color3 = new Color { Id = 3, Name = "Yellow" };
            //Color color4 = new Color { Id = 4, Name = "Brown" };
            //Color color5 = new Color { Id = 5, Name = "White" };
            //Color color6 = new Color { Id = 6, Name = "White" };
            //Color color7 = new Color { Id = 7, Name = "Black" };
            //Color color8 = new Color { Id = 8, Name = "Blue" };
            //Color color9 = new Color { Id = 9, Name = "Brown" };
            //Color color10 = new Color { Id = 10, Name = "Blue" };
            //Color color11 = new Color { Id = 11, Name = "Black" };
            //Color color12 = new Color { Id = 12, Name = "Blue" };
            //Color color13 = new Color { Id = 13, Name = "Blue" };
            //Color color14 = new Color { Id = 14, Name = "Blue" };
            //Color color15 = new Color { Id = 15, Name = "Blue" };


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
            //brandManager.Add(brand5);
            //colorManager.Add(color5);

            //carManager.Add(car6);
            //brandManager.Add(brand6);
            //colorManager.Add(color6);

            //carManager.Add(car7);
            //brandManager.Add(brand7);
            //colorManager.Add(color7);

            //carManager.Add(car8);
            //brandManager.Add(brand8);
            //colorManager.Add(color8);

            //carManager.Add(car9);
            //brandManager.Add(brand9);
            //colorManager.Add(color9);

            //carManager.Add(car10);
            //brandManager.Add(brand10);
            //colorManager.Add(color10);

            //carManager.Add(car11);
            //brandManager.Add(brand11);
            //colorManager.Add(color11);

            //carManager.Add(car12);
            //brandManager.Add(brand12);
            //colorManager.Add(color12);

            //carManager.Add(car13);
            //brandManager.Add(brand13);
            //colorManager.Add(color13);

            //carManager.Add(car14);
            //brandManager.Add(brand14);
            //colorManager.Add(color14);

            //carManager.Add(car15);
            //brandManager.Add(brand15);
            //colorManager.Add(color15);












        }
    }
}