using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cars_Web.cars.Dtos
{
    public class CarRequest
    {
       
        public string Brand { get; set; }


        public string Model { get; set; }

        public string Color { get; set; }


        public int Year { get; set; }




    }
}
