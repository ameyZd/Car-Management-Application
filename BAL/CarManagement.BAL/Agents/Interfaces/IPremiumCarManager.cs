using System.Collections.Generic;
using ViewModels;

namespace CarManagement.BAL.Agents.Interfaces
{
    public interface IPremiumCarManager
    {
        /// <summary>
        /// Select list of all premium cars
        /// </summary>
        /// <returns>List of all premium cars</returns>
        List<string> ListOfAllAvailablePremiumCars();

        /// <summary>
        /// Bokking a premium car
        /// </summary>
        void PremiumCarBooked(AvailablePremiumCarsDataViewModel model);

        /// <summary>
        /// Gets all the premium cars from premium car repository again
        /// </summary>
        void RefreshAvailablePremiumCars();

        /// <summary>
        /// Sends a confirmation mail
        /// </summary>
        /// <param name="premiumCarsData">Premium car data</param>
        void SendPremiumCarEmail(AvailablePremiumCarsDataViewModel premiumCarsData);
    }
}
