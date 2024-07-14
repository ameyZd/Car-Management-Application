using System.ComponentModel.DataAnnotations;

namespace CarManagement.Model
{
    public class Cars
    {
        [Display(Name = "Car ID")]
        public int CarID { get; set; }

        [Required(ErrorMessage = "Car name is mandatory")]
        [Display(Name = "Car Name")]
        public string CarName { get; set; }

        [Display(Name = "Car Mileage")]
        public double CarMileage { get; set; }

        [Required(ErrorMessage = "Car owner name is mandatory")]
        [Display(Name = "Car Owner Name")]
        public string CarOwnerName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Enter Valid Email")]
        [Display(Name = "Car Owner Mail")]
        public string CarOwnerEmail { get; set; }
    }
}
