using AutoMapper;
using CarManagement.DAL;
using CarManagement.DAL.Services.Home;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIModels;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace API.Controllers
{
    public class APICarController : ApiController
    {
        private readonly IMapper _mapper;   // mapper instance

        private readonly CarService _carService;  // DAL car service instance

        public APICarController(IMapper mapper)
        {
            _mapper = mapper;
            _carService = DependencyResolver.Current.GetService<CarService>();

        }

        public APICarController()
        {
            _mapper = DependencyResolver.Current.GetService<IMapper>();
            _carService = DependencyResolver.Current.GetService<CarService>();
        }
        [HttpGet]
        // GET: api/APICar/AllCars
        public IHttpActionResult AllCars()
        {
            try
            {
                List<CarsData> allCars = _carService.SelectCarList();

                if (allCars != null)
                {
                    return Ok(allCars);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return InternalServerError();
                //return null;
            }
        }

        [HttpPost]
        // POST: api/APICar/Insert
        public IHttpActionResult Insert(CarsDataAPIModel carAPIData)
        {
            try
            {
                if (carAPIData == null)
                {
                    return BadRequest("Invalid request data");
                }

                CarsData carData = _mapper.Map<CarsData>(carAPIData);

                bool isInserted = _carService.InsertCar(carData);

                if (isInserted)
                {
                    return Ok("Car inserted successfully");
                }
                else
                {
                    return BadRequest("Failed to insert car");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return InternalServerError();
            }
        }

        [HttpPost]
        // POST: api/APICar/Update
        public IHttpActionResult Update(CarsDataAPIModel carAPIData)
        {
            try
            {
                if (carAPIData == null)
                {
                    return BadRequest("Invalid request data");
                }

                CarsData carData = _mapper.Map<CarsData>(carAPIData);

                bool isUpdated = _carService.UpdateCar(carData);

                if (isUpdated)
                {
                    return Ok("Car updated successfully");
                }
                else
                {
                    return BadRequest("Failed to update car");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return InternalServerError();
            }
        }

        [HttpPost]
        // DELETE: api/APICar/Delete
        public IHttpActionResult Delete(CarsDataAPIModel carAPIData)
        {
            try
            {
                if (carAPIData == null)
                {
                    return BadRequest("Invalid request data");
                }

                CarsData carData = _mapper.Map<CarsData>(carAPIData);

                bool isDeleted = _carService.DeleteCar(carData.CarID);

                if (isDeleted)
                {
                    return Ok("Car deleted successfully");
                }
                else
                {
                    return BadRequest("Failed to delete car");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return InternalServerError();
            }
        }

        [HttpDelete]
        // DELETE: api/APICar/DeleteAll
        public IHttpActionResult DeleteAll()
        {
            try
            {
                bool AllCarsDeleted = _carService.DeleteAllEntries();

                if (AllCarsDeleted)
                {
                    return Ok("All Cars deleted successfully");
                }
                else
                {
                    return BadRequest("Failed to delete all cars");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return InternalServerError();
            }
        }

        [HttpGet]
        // GET: api/APICar/MaxMileage
        public IHttpActionResult MaxMileage()
        {
            try
            {
                CarsData carWithMaxMileage = _carService.CarWithMaxMileage();

                if (carWithMaxMileage != null)
                {
                    return Ok(carWithMaxMileage);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return InternalServerError();
            }
        }

        [HttpGet]
        // GET: api/APICar/DownloadCSV
        public IHttpActionResult DownloadCSV()
        {
            try
            {
                FileContentResult file = _carService.DownloadCSV();
                if (file != null)
                {
                    return Ok(file);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return InternalServerError();
            }
        }
    }
}
