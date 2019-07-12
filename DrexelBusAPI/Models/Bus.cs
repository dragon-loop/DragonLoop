using System.ComponentModel.DataAnnotations;

namespace DrexelBusAPI.Models
{
    public class Bus
    {
        [Key]
        public int bus_id { get; set; }

        public decimal x_coordinate { get; set; }

        public decimal y_coordinate { get; set; }

        public int route_id { get; set; }
    }
}
