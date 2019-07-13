using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrexelBusAPI.Models
{
    public class Route
    {
        [Key]
        public int route_id { get; set; }

        public string name { get; set; }
    }
}
