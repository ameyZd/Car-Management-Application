using AutoMapper;
using CarManagement.BAL.Agents.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ViewModels;
using WebAPIModels;

namespace CarManagement.BAL.Agents.Classes
{
    public class PremiumCarManager : IPremiumCarManager
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public PremiumCarManager(IMapper mapper)
        {
            _mapper = mapper;
            _httpClient = new HttpClient();
        }

        public List<string> ListOfAllAvailablePremiumCars()
        {
            List<AvailablePremiumCarsAPIModel> allPremiumCars = new List<AvailablePremiumCarsAPIModel>();

            HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44311/api/APIPremiumCar/AllAvailablePremiumCars").Result;

            string premiumCarsData = response.Content.ReadAsStringAsync().Result; // getting data here

            allPremiumCars = JsonConvert.DeserializeObject<List<AvailablePremiumCarsAPIModel>>(premiumCarsData);  // here it becomes null

            List<string> premiumCars = new List<string>();

            foreach (var car in allPremiumCars)
            {
                premiumCars.Add(car.PremiumCars);
            }

            return premiumCars;
        }

        public void PremiumCarBooked(AvailablePremiumCarsDataViewModel premiumCarView) 
        { 
            PremiumCarsDataAPIModel premiumCarAPI = _mapper.Map<PremiumCarsDataAPIModel>(premiumCarView);
            string jsonData = JsonConvert.SerializeObject(premiumCarAPI);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync("https://localhost:44311/api/APIPremiumCar/BookPremiumCar", content).Result;
        }

        public void RefreshAvailablePremiumCars()
        {
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44311/api/APIPremiumCar/RefreshPremiumCars").Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
 
        public void SendPremiumCarEmail(AvailablePremiumCarsDataViewModel premiumCarsData)
        {
            try
            {
                PremiumCarsDataAPIModel premiumCarsAPIdata = _mapper.Map<PremiumCarsDataAPIModel>(premiumCarsData);
                string jsonData = JsonConvert.SerializeObject(premiumCarsAPIdata);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = _httpClient.PostAsync("https://localhost:44311/api/APIPremiumCar/SendMail", content).Result;
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
    }
}
