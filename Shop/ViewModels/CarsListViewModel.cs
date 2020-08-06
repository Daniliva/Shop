using Shop.Data.Model;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }
        public string carsCategory { get; set; }
    }
}