using CarManagement.BAL.Agents.Classes;
using CarManagement.BAL.Agents.Interfaces;
using System.Web.Mvc;
using ViewModels;

namespace CarManagement.Controllers
{
    [Authorize]
    public class PremiumCarController : Controller
    {
        private readonly IPremiumCarManager _premiumCarManager;

        public PremiumCarController()
        {
            _premiumCarManager = DependencyResolver.Current.GetService<IPremiumCarManager>();
        }

        /// <summary>
        /// Display all the premium cars and user details
        /// </summary>
        /// <returns>Shows all the premium car and user details</returns>
        [HttpGet]
        public ActionResult SelectPreimumCars()
        {
            if (ModelState.IsValid)
            {
                ViewBag.list = _premiumCarManager.ListOfAllAvailablePremiumCars();
                return View();
            }
            return View();
        }

        /// <summary>
        /// Adding user details, selecting premium car 
        /// and sending confirmation mail to given Email ID
        /// </summary>
        /// <param name="model">Premium Cars details"</param>
        /// <returns>Shows a confirmation page with all the user details and premium car choice</returns>
        [HttpPost]
        public ActionResult SelectPreimumCars(AvailablePremiumCarsDataViewModel model)
        {

            if (ModelState.IsValid)
            {
                _premiumCarManager.PremiumCarBooked(model);
                Session["PremiumCars"] = model;
                _premiumCarManager.SendPremiumCarEmail(model);
                return RedirectToAction("Done");
            }
            ViewBag.list = _premiumCarManager.ListOfAllAvailablePremiumCars();
            return View(model);
        }

        /// <summary>
        /// Refresh all premium cars
        /// </summary>
        /// <returns></returns>
        public ActionResult RefreshAvailablePremiumCars()
        {
            _premiumCarManager.RefreshAvailablePremiumCars();
            return RedirectToAction("SelectPreimumCars");
        }


        /// <summary>
        /// Display a confirmation page showing premium car and car user details
        /// </summary>
        /// <returns>Shows a confirmation page with all the user details and premium car choice</returns>
        public ActionResult Done()
        {
            AvailablePremiumCarsDataViewModel model = Session["PremiumCars"] as AvailablePremiumCarsDataViewModel;
            return View(model);
        }
    }
}