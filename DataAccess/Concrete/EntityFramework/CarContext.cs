﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context is matching Db files and project classes...
    public class CarContext:DbContext
    {
        //we are selecting the which database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KHCVNCN\SQL;DataBase=Cars;TrustServerCertificate=True");
        }
        //which object in sql server match which object in project we are doint it
        public DbSet<Car> CarsInformations { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }



    }
}
