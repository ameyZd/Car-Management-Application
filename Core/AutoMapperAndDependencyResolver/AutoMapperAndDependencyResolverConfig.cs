using AutoMapper;
using CarManagement.BAL.Agents.Classes;
using CarManagement.BAL.Agents.Interfaces;
using CarManagement.DAL;
using System.Net.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using ViewModels;
using WebAPIModels;

namespace AutoMapperAndDependencyResolver
{
    public class AutoMapperAndDependencyResolverConfig
    {
        public static void Initialize()
        {
            var container = new UnityContainer();

            container.RegisterType<ILoginManager, LoginManager>();
            container.RegisterType<ICarManager, CarManager>();
            container.RegisterType<IPremiumCarManager, PremiumCarManager>();

            container.RegisterInstance(new HttpClient());

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, UserAPIModel>().ReverseMap();
                cfg.CreateMap<CarsDataViewModel, CarsDataAPIModel>().ReverseMap();
                cfg.CreateMap<AvailablePremiumCarsDataViewModel, PremiumCarsDataAPIModel>().ReverseMap();
            });

            // IMapper instance
            container.RegisterInstance(mapperConfiguration.CreateMapper());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}




