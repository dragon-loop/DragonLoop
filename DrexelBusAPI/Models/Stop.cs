using System.ComponentModel.DataAnnotations;

namespace DrexelBusAPI.Models
{
    public class Stop
    {
        [Key]
        public int stop_id { get; set; }

        public decimal x_coordinate { get; set; }

        public decimal y_coordinate { get; set; }

        public string name { get; set; }

        public int route_id { get; set; }

        public int? next_stop_id { get; set; }
    }
}
