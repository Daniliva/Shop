using Shop.Data.Model;
using System.Collections.Generic;

namespace Shop.Data.interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> getFavCars { get; }

        Car getObjectCar(int carId);
    }
}