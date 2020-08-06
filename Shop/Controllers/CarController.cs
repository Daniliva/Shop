using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Model;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
    public class CarController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarController(IAllCars IAllCars, ICarsCategory IAllCategories)
        {
            _allCars = IAllCars;
            _allCategories = IAllCategories;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string currCategory = "";
            IEnumerable<Car> cars;

            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else if (string.Equals("electro", category, System.StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили")).OrderBy(i => i.id);
                currCategory = "Электромобили";
            }
            else if (string.Equals("fuel", category, System.StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Классические автомобили")).OrderBy(i => i.id);
                currCategory = "Классические автомобили";
            }
            else
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            var obj = new CarsListViewModel
            {
                allCars = cars,
                carsCategory = currCategory
            };
            ViewBag.Title = "Page with cars";
            return View(obj);
        }
    }
}