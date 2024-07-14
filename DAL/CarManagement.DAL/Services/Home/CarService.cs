using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarManagement.DAL.Services.Home
{
    public class CarService
    {
        private static CarManagementEntities db = null;

        static CarService()
        {
            db = new CarManagementEntities();
        }

        /// <summary>
        /// Display List of cars
        /// </summary>
        /// <returns>All the current cars present in the database</returns>
        public List<CarsData> SelectCarList()
        {
            return db.CarsDatas.AsNoTracking().ToList();
        }

        /// <summary>
        /// Insert a car in the database
        /// </summary>
        /// <param name="car">Car details</param>
        public bool InsertCar(CarsData car)
        {
            try
            {
                db.CarsDatas.Add(car);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting car: " + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Update Car details
        /// </summary>
        /// <param name="car">Car details</param>
        public bool UpdateCar(CarsData car)
        {
            try
            {
                db.sp_updateCar(car.CarID, car.CarName, Convert.ToDecimal(car.CarMileage), car.CarOwnerName, car.CarOwnerEmail);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating car: " + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Delete a car from the database
        /// </summary>
        /// <param name="id">Car ID for deleting a car</param>
        public bool DeleteCar(int id)
        {
            try
            {
                CarsData carToDelete = db.CarsDatas.Find(id);
                db.CarsDatas.Remove(carToDelete);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting car: " + ex.Message);
                return false;
            }

        }

        public bool DeleteAllEntries()
        {
            try
            {
                db.sp_TruncateCarEntries();
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting all cars: " + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Car with maximum mileage
        /// </summary>
        /// <returns>Car details which will have maximum mileage</returns>
        public CarsData CarWithMaxMileage()
        {
            return db.CarsDatas.OrderByDescending(x => x.CarMileage).FirstOrDefault();
        }

        /// <summary>
        /// Download csv file of data
        /// </summary>
        /// <returns>a csv file of all car data entries</returns>
        public FileContentResult DownloadCSV()
        {
            string csv = "\"ID\",\"Car Name\",\"Car Mileage\",\"Owner Name\",\"Owner Email\" \n";
            List<CarsData> cars = SelectCarList();
            foreach (var car in cars)
            {
                csv += $"{car.CarID},\"{car.CarName}\",{car.CarMileage},\"{car.CarOwnerName}\",\"{car.CarOwnerEmail}\" \n";
            }
            return new FileContentResult(Encoding.UTF8.GetBytes(csv), "text/csv")
            {
                FileDownloadName = "CarData.csv"
            };
        }
    }
}
