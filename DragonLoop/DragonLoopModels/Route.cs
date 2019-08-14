using Newtonsoft.Json;
using System.Collections.Generic;

namespace DragonLoopModels
{
    public class Route
    {
        public Route()
        {
            Buses = new HashSet<Bus>();
            Schedules = new HashSet<Schedule>();
            Stops = new HashSet<Stop>();
        }

        public int RouteId { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Bus> Buses { get; set; }

        [JsonIgnore]
        public virtual ICollection<Schedule> Schedules { get; set; }

        [JsonIgnore]
        public virtual ICollection<Stop> Stops { get; set; }
    }
}
