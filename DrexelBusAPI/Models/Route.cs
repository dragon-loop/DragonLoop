using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrexelBusAPI.Models
{
    public class Route
    {
        [Key]
        public int route_id { get; set; }

        public string name { get; set; }

        public int initial_stop { get; set; }

        public int final_stop { get; set; }

        public int[] stops { get; set; }
    }
}
