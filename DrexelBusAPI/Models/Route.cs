using System.Collections.Generic;

namespace DrexelBusAPI.Models
{
    public class Route
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Initial_stop { get; set; }

        public int Final_stop { get; set; }

        public IEnumerable<int> Stops { get; set; }
    }
}
