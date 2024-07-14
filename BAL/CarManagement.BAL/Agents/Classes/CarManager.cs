using AutoMapper;
using CarManagement.BAL.Agents.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using ViewModels;
using WebAPIModels;

namespace CarManagement.BAL.Agents.Classes
{
    public class CarManager : ICarManager
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public CarManager(IMapper mapper)
        {
            _mapper = mapper;
            _httpClient = new HttpClient();
        }

        public List<CarsDataViewModel> SelectAllCars()
        {
            List<CarsDataAPIModel> listofCarsAPI = new List<CarsDataAPIModel>();

            HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44311/api/APICar/AllCars").Result;

            string carsData = response.Content.ReadAsStringAsync().Result;

            listofCarsAPI = JsonConvert.DeserializeObject<List<CarsDataAPIModel>>(carsData);

            List<CarsDataViewModel> listofCarsView = _mapper.Map<List<CarsDataViewModel>>(listofCarsAPI);

            return listofCarsView;
        }

        public CarsDataViewModel SelectCarById(int id)
        {
            CarsDataViewModel carIDView = SelectAllCars().Find(x => x.CarID == id);
            return carIDView;
        }

        public void InsertCar(CarsDataViewModel carViewModel)
        {
            try
            {
                CarsDataAPIModel carAPIData = _mapper.Map<CarsDataAPIModel>(carViewModel);
                string jsonData = JsonConvert.SerializeObject(carAPIData);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = _httpClient.PostAsync("https://localhost:44311/api/APICar/Insert", content);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

            }
        }

        public void UpdateCar(CarsDataViewModel carViewModel)
        {
            try
            {
                CarsDataAPIModel carAPIData = _mapper.Map<CarsDataAPIModel>(carViewModel);
                string jsonData = JsonConvert.SerializeObject(carAPIData);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = _httpClient.PostAsync("https://localhost:44311/api/APICar/Update", content);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

            }
        }

        public void DeleteCar(int id)
        {
            CarsDataViewModel carViewToDelete = SelectAllCars().Find(x => x.CarID == id);
            CarsDataAPIModel carAPIToDelete = _mapper.Map<CarsDataAPIModel>(carViewToDelete);
            string jsonData = JsonConvert.SerializeObject(carAPIToDelete);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync("https://localhost:44311/api/APICar/Delete", content);
        }

        public void DeleteAllCars()
        {
            try
            {
                HttpResponseMessage response = _httpClient.DeleteAsync("https://localhost:44311/api/APICar/DeleteAll").Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public CarsDataViewModel MaxCarMileage()
        {
            CarsDataAPIModel carApiMaxMileage;

            HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44311/api/APICar/MaxMileage").Result;

            string carWithMaxMileage = response.Content.ReadAsStringAsync().Result;

            carApiMaxMileage = JsonConvert.DeserializeObject<CarsDataAPIModel>(carWithMaxMileage);

            CarsDataViewModel carViewMaxMileage = _mapper.Map<CarsDataViewModel>(carApiMaxMileage);

            return carViewMaxMileage;
        }

        public FileContentResult Download()
        {

            HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44311/api/APICar/DownloadCSV").Result;

            string file = response.Content.ReadAsStringAsync().Result;

            FileContentResult fileContent = JsonConvert.DeserializeObject<FileContentResult>(file);

            return fileContent;
        }

    }
}
