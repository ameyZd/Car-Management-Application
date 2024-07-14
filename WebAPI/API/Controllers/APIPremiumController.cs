using AutoMapper;
using CarManagement.DAL;
using CarManagement.DAL.Services.Home;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIModels;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace API.Controllers
{
    public class APIPremiumCarController : ApiController
    {
        private readonly IMapper _mapper;   // mapper instance

        private readonly PremiumCarService _premiumCarService;  // DAL car service instance

        public APIPremiumCarController(IMapper mapper)
        {
            _mapper = mapper;
            _premiumCarService = DependencyResolver.Current.GetService<PremiumCarService>();

        }

        public APIPremiumCarController()
        {
            _mapper = DependencyResolver.Current.GetService<IMapper>();
            _premiumCarService = DependencyResolver.Current.GetService<PremiumCarService>();

        }

        [HttpGet]
        // GET: api/APIPremiumCar/AllPremiumCars
        public IHttpActionResult AllAvailablePremiumCars()
        {
            try
            {
                List<AvailablePremiumCar> allAvailablePremiumCars = _premiumCarService.ListOfAllAvailablePremiumCars();

                if (allAvailablePremiumCars != null)
                {

                    return Ok(allAvailablePremiumCars);
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

        [HttpPost]
        // POST: api/APIPremium/BookPremiumCar
        public IHttpActionResult BookPremiumCar(PremiumCarsDataAPIModel premiumCarsDataAPI)
        {
            try
            {
                PremiumCarsData premiumCarsData = _mapper.Map<PremiumCarsData>(premiumCarsDataAPI);

                bool isBooked = _premiumCarService.PremiumCarBooked(premiumCarsData);

                if (isBooked)
                {

                    return Ok();
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
        // GET: api/APIPremiumCar/RefreshPremiumCars
        public IHttpActionResult RefreshPremiumCars()
        {
            try
            {
                bool AllPremiumCarsRefreshed = _premiumCarService.RefreshAllPremiumCars();

                if (AllPremiumCarsRefreshed)
                {
                    return Ok("All Premium Cars refreshed successfully");
                }
                else
                {
                    return BadRequest("Failed to refresh all all premium cars");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return InternalServerError();
            }

        }

        [HttpPost]
        // POST: api/APIPremiumCar/SendMail
        public IHttpActionResult SendMail(PremiumCarsDataAPIModel premiumCarsData)
        {
            try
            {
                bool mailSent = _premiumCarService.SendEmail(premiumCarsData.CarOwnerEmail, premiumCarsData.CarOwnerName, premiumCarsData.SelectedCar);

                if (mailSent)
                {
                    return Ok();
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