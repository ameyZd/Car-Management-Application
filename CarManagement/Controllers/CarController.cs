using CarManagement.BAL.Agents.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels;

namespace CarManagement.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarManager _carManager;

        public CarController()
        {
            _carManager = DependencyResolver.Current.GetService<ICarManager>();
        }

        /// <summary>
        /// Display list of cars
        /// </summary>
        /// <returns>Shows list of all cars</returns>
        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                IEnumerable<CarsDataViewModel> allCars = _carManager.SelectAllCars();
                return View(allCars);
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Display details of the Car
        /// </summary>
        /// <param name="carId">Randomly generated Car ID</param>
        /// <returns>Display car details</returns>
        public ActionResult Details(int carId)
        {
            if (ModelState.IsValid)
            {
                CarsDataViewModel carObject = _carManager.SelectCarById(carId);
                return View(carObject);
            }
            return View();
        }

        /// <summary>
        /// Display for creating Car
        /// </summary>
        /// <returns>Display created Car</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Inserting new Cars 
        /// </summary>
        /// <param name="car">Car details</param>
        /// <returns>Display all the created cars</returns>
        [HttpPost]
        public ActionResult Create(CarsDataViewModel car)
        {
            try
            {
                _carManager.InsertCar(car);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Editing inserted cars
        /// </summary>
        /// <param name="carId">Randomly generated Car ID</param>
        /// <returns>Display after edited cars</returns>
        [HttpGet]
        public ActionResult Edit(int carId)
        {
            if (ModelState.IsValid)
            {
                CarsDataViewModel car = _carManager.SelectCarById(carId);
                return View(car);
            }
            return View();
        }

        /// <summary>
        /// Editing Cars 
        /// </summary>
        /// <param name="car">Car details</param>
        /// <returns>Display the current list of cars after editing</returns>
        [HttpPost]
        public ActionResult Edit(CarsDataViewModel car)
        {
            try
            {
                _carManager.UpdateCar(car);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary> 
        /// Delete Car
        /// </summary>
        /// <param name="carId">Randomly generated Car ID</param>
        /// <returns>Display after deleted car</returns>
        [HttpGet]
        public ActionResult Delete(int carId)
        {
            if (ModelState.IsValid)
            {
                CarsDataViewModel car = _carManager.SelectCarById(carId);
                return View(car);
            }
            return View();
        }

        /// <summary>
        /// Delete car by selecting Car ID
        /// </summary>
        /// <param name="carId">The ID of the car to be deleted.</param>
        /// <param name="nothing">A dummy parameter to differentiate from the GET method.</param>
        /// <returns>Display current list of cars after deleting car</returns>
        [HttpPost]
        public ActionResult Delete(int carId, FormCollection nothing)
        {
            try
            {
                _carManager.DeleteCar(carId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteAll()
        {
            _carManager.DeleteAllCars();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Retrieves the car with the maximum mileage and displays its details.
        /// </summary>
        /// <returns>Displaying details of the car with the maximum mileage.</returns>
        public ActionResult MaximumMileage()
        {
            if (ModelState.IsValid)
            {
                CarsDataViewModel carWithMaxMileage = _carManager.MaxCarMileage();
                return View(carWithMaxMileage);
            }
            return View();
        }

        /// <summary>
        /// Downloads whole table in csv format
        /// </summary>
        /// <returns>a file in csv format</returns>
        public ActionResult DownloadCSV()
        {

            FileContentResult fileContent = _carManager.Download();

            return fileContent;
        }


    }


}