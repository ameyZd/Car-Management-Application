using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIModels
{
    public class PremiumCarsDataAPIModel
    {
        public int CarOwnerID { get; set; }
        public string CarOwnerName { get; set; }
        public string CarOwnerEmail { get; set; }
        public string SelectedCar { get; set; }
    }
}
