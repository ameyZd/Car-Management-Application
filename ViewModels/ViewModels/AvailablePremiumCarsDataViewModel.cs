using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AvailablePremiumCarsDataViewModel
    {
        public int CarOwnerID { get; set; }

        [Display(Name = "Car Owner Name")]
        [Required(ErrorMessage = "Car owner name is mandatory")]
        [RegularExpression(@"^\s*\S.*$", ErrorMessage = "Car Owner name cannot consist of only blank spaces.")]
        public string CarOwnerName { get; set; }

        [Display(Name = "Car Owner Mail")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Enter Valid Email")]
        public string CarOwnerEmail { get; set; }

        [Required(ErrorMessage = "Please select a car")]
        [Display(Name = "Your desired car")]
        public string SelectedCar { get; set; }
    }
}
