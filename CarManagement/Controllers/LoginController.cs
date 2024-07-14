using CarManagement.BAL.Agents.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using ViewModels; 

namespace CarManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginManager _loginManager;

        public LoginController()
        {
            _loginManager = DependencyResolver.Current.GetService<ILoginManager>();

        }

        /// <summary>
        /// Display login page
        /// </summary>
        /// <returns>Show login page</returns>
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        /// <summary>
        /// Verification of valid users
        /// </summary>
        /// <param name="user">Username and Password</param>
        /// <returns>List of cars if valid login details else "Login Failed" message</returns>
        [HttpPost]
        public async Task<JsonResult> Verify(UserViewModel user)
        {
            if (await _loginManager.Verification(user))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return Json(new { success = true, message = "Login Success" });
            }
            else
            {
                return Json(new { success = false, message = "Login Failed" });
            }
        }
    }
}