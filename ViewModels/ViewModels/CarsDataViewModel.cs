using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CarsDataViewModel
    {
        [Display(Name = "Car ID")]
        public int CarID { get; set; }

        [Display(Name = "Car Name")]
        [RegularExpression(@"^\s*\S.*$", ErrorMessage = "Car Name cannot consist of only blank spaces.")]
        [Required(ErrorMessage = "Car name is mandatory")]
        public string CarName { get; set; }

        [Display(Name = "Car Mileage")]
        [Required(ErrorMessage = "Car Mileage is required")]
        [RegularExpression(@"^\s*\S.*$", ErrorMessage = "Car Mileage cannot consist of only blank spaces.")]
        public double CarMileage { get; set; }

        [Display(Name = "Car Owner Name")]
        [Required(ErrorMessage = "Car owner name is mandatory")]
        [RegularExpression(@"^\s*\S.*$", ErrorMessage = "Car Owner name cannot consist of only blank spaces.")]
        public string CarOwnerName { get; set; }

        [Display(Name = "Car Owner Mail")]
        [Required(ErrorMessage = "Car owner Email is mandatory")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Enter Valid Email")]
        public string CarOwnerEmail { get; set; }
    }
}
