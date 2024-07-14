using AutoMapper;
using CarManagement.BAL.Agents.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using WebAPIModels;

namespace CarManagement.BAL.Agents.Classes
{
    public class LoginManager : ILoginManager
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public LoginManager(IMapper mapper)
        {
            _mapper = mapper;
            _httpClient = new HttpClient();
        }

        
        public async Task<bool> Verification(UserViewModel userViewData)
        {
            try
            {
                UserAPIModel userAPIData = _mapper.Map<UserAPIModel>(userViewData);
                string jsonData = JsonConvert.SerializeObject(userAPIData);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:44311/api/APILogin/VerifyUser", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to verify user: {response.StatusCode}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

    }
}
