using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIModels
{
    public class CarsDataAPIModel
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public double CarMileage { get; set; }
        public string CarOwnerName { get; set; }
        public string CarOwnerEmail { get; set; }
    }
}
