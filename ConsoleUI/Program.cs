using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }
            
        }
    }
}