using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //we used the constructures' information then we added from here to there 

            CarManager carManager = new CarManager(new EfCarDal(),new EfBrandDal());

            //it has to be more than 2 words brands name to select car we wrote code in business layer...
            foreach (var cars in carManager.GetCarsByBrand("Fi"))
            {
                Console.WriteLine(cars.Name);
            }
            Console.WriteLine("-----------");


            //we can take the 500 tl moneys Cars will list in display

            foreach (var cars in carManager.GetCarsByDailyPrice(500))
            {
                Console.WriteLine(cars.Description);
            }

        }
    }
}