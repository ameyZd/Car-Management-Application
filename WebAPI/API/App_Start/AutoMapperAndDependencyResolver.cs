using AutoMapper;
using CarManagement.DAL;
using CarManagement.DAL.Services.Home;
using System.Net.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebAPIModels;

namespace API.App_Start
{
    public class AutoMapperAndDependencyResolver
    {
        public static void Initialize()
        {
            var container = new UnityContainer();

            container.RegisterType<UserAuthenticationService, UserAuthenticationService>();
            container.RegisterType<CarService, CarService>();
            container.RegisterType<PremiumCarService, PremiumCarService>();

            container.RegisterInstance(new HttpClient());

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserAPIModel>().ReverseMap();
                cfg.CreateMap<CarsData, CarsDataAPIModel>().ReverseMap();
                cfg.CreateMap<PremiumCarsData, PremiumCarsDataAPIModel>().ReverseMap();
                cfg.CreateMap<AvailablePremiumCar, AvailablePremiumCarsAPIModel>().ReverseMap();
            });

            // IMapper instance
            container.RegisterInstance(mapperConfiguration.CreateMapper());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}