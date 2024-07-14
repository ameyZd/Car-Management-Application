using CarManagement.Model.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarManagement.DAL.Services.Home
{
    public class PremiumCarSerice
    {
        public static List<string> GetSelectListItems()
        {
            return new List<string>
            {
                "Aston Martin",
               "Audi Q8",
               "Bentley Continental",
                "Bugatti",
                "Mercedes Maybach",
                "Range Rover SV",
                "Rolls-Royce Cullinan",
                "Mustang"
            };
        }
    }
}
