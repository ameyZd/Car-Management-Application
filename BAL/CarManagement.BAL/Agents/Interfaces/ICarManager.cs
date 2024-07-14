using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels;

namespace CarManagement.BAL.Agents.Interfaces
{
    public interface ICarManager
    {
        /// <summary>
        /// Select list of all cars
        /// </summary>
        /// <returns>a list of updated cars</returns>
        List<CarsDataViewModel> SelectAllCars();

        /// <summary>
        /// Select Car entry based on Id
        /// </summary>
        /// <param name="id">Car Id</param>
        /// <returns>Car entry data based on Id</returns>
        CarsDataViewModel SelectCarById(int id);

        /// <summary>
        /// Insert Car entries in database
        /// </summary>
        /// <param name="car">Car details</param>
        void InsertCar(CarsDataViewModel car);

        /// <summary>
        /// Update Car entries in database
        /// </summary>
        /// <param name="car">Car details</param>
        void UpdateCar(CarsDataViewModel car);

        /// <summary>
        ///  Delete Car entries in database
        /// </summary>
        /// <param name="id">Car Id</param>
        void DeleteCar(int id);

        /// <summary>
        /// Delete all car entries from database
        /// </summary>
        void DeleteAllCars();

        /// <summary>
        /// Select car entry with max mileage
        /// </summary>
        /// <returns>Car with maximum mileage</returns>
        CarsDataViewModel MaxCarMileage();

        FileContentResult Download();
    }
}
