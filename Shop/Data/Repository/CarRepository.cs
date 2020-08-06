using Microsoft.EntityFrameworkCore;
using Shop.Data.interfaces;
using Shop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBContent;

        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Car> Cars => appDBContent.Cars.Include(c => c.Category);
        public IEnumerable<Car> getFavCars => appDBContent.Cars.Where(p => p.isFavourite).Include(c => c.Category);

        public Car getObjectCar(int carId) => appDBContent.Cars.FirstOrDefault(p => p.id == carId);
    }
}