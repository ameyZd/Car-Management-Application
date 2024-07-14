using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarManagement.Model.Home
{
    public class PremiumCars
    {
        [Required(ErrorMessage = "Car owner name is mandatory")]
        [Display(Name = "Car Owner Name")]
        public string CarOwnerName { get; set; }

        [Required(ErrorMessage = "Please enter Email ID")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Enter Valid Email")]
        [Display(Name = "Car Owner Mail")]
        public string CarOwnerEmail { get; set; }

        [Required(ErrorMessage = "Please select a car")]
        [Display(Name = "Your desired car")]
        public string SelectedCar { get; set; }

        [Display(Name = "Premium Car options")]
        public List<string> Cars { get; set; }
    }
}
