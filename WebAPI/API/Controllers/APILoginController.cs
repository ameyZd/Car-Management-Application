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
    public class APILoginController : ApiController
    {
        private readonly IMapper _mapper;   // mapper instance

        private readonly UserAuthenticationService _userAuthenticationService;  // DAL user auth instance

        public APILoginController(IMapper mapper)
        {
            _mapper = mapper;
            _userAuthenticationService = DependencyResolver.Current.GetService<UserAuthenticationService>();

        }

        public APILoginController()
        {
            _mapper = DependencyResolver.Current.GetService<IMapper>();
            _userAuthenticationService = DependencyResolver.Current.GetService<UserAuthenticationService>();
        }

        [HttpGet]
        // GET: api/APILogin/AllUser
        public IHttpActionResult AllUser()
        {
            try
            {
                List<User> users = _userAuthenticationService.PutValue();

                if (users != null)
                {
                    return Ok(users);
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
        // POST: api/APILogin/VerifyUser
        public IHttpActionResult VerifyUser(UserAPIModel user)
        {
            try
            {
                User userData = _mapper.Map<User>(user);

                bool isVerified = _userAuthenticationService.Verify(userData);

                if (isVerified)
                {
                    return Ok(isVerified);
                }
                else
                {
                    return BadRequest("Invalid user data");
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

