using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CarManagement.DAL.Services.Home
{
    public class PremiumCarService
    {
        private static CarManagementEntities db;

        static PremiumCarService()
        { 
            db = new CarManagementEntities();
        }

        public List<PremiumCarsRepository> AllPremiumCars()
        {
            return db.PremiumCarsRepositories.AsNoTracking().ToList();
        }

        /// <summary>
        /// Getting a list of premium cars
        /// </summary>
        /// <returns>A list of all the premium cars</returns>
        public List<AvailablePremiumCar> ListOfAllAvailablePremiumCars()
        {
            return db.AvailablePremiumCars.AsNoTracking().ToList();
        }

        /// <summary>
        /// Booking a premium car by removing it from Available premium cars 
        /// </summary>
        /// <param name="premiumCar"></param>
        public bool PremiumCarBooked(PremiumCarsData premiumCar)
        {
            try
            {
                var carToRemove = db.AvailablePremiumCars.FirstOrDefault(car => car.PremiumCars == premiumCar.SelectedCar);

                if (carToRemove != null)
                {
                    db.AvailablePremiumCars.Remove(carToRemove); 
                    db.SaveChanges();
                    return true; // Car booking successful
                }
                else
                {
                    return false; // Car not found in available cars
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sending email: {ex.Message}");
                return false; 
            }

        }

        /// <summary>
        /// Refresh all the premium cars (removes all the cars from available premium car table and add all the cars premium car repository)
        /// </summary>
        /// <returns></returns>
        public bool RefreshAllPremiumCars()
        {
            try
            {
                db.RefreshAvailablePremiumCars();
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting all cars: " + ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Sending confirmation mails to user with necessary details  
        /// </summary>
        /// <param name="recipientEmail">To whome the mail will be sent which is user</param>
        /// <param name="CarOwnerName">Name of the user</param>
        /// <param name="SelectedCar">Car selected by user</param>
        public bool SendEmail(string recipientEmail, string CarOwnerName, string SelectedCar)
        {
            //string senderEmail = ConfigurationManager.AppSettings["SenderMail"];
            string senderEmail = "20010700@ycce.in";
            string subject = $"Hello {CarOwnerName}, I am Amey";
            string body = $"Thank you for choosing our 'GO premium' Car service your {SelectedCar} is on its way";

            try
            {
                using (MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail))
                {
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(senderEmail, "vmee rlus iciw jovu");
                        smtp.Port = 587;
                        smtp.Send(mailMessage);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sending email: {ex.Message}");
                return false; // Mail sending failed
            }
        }
    }
}
