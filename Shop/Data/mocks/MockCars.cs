using Shop.Data.interfaces;
using Shop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car> { new Car { name = "Tesla",shortDesc="", longDesc="",img="",price=45000,isFavourite=true,
                    available=true, Category=_categoryCars.AllCategories.Last() } };
            }
        }

        public IEnumerable<Car> getFavCars { get; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}