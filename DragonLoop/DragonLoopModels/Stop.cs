using Newtonsoft.Json;
using System.Collections.Generic;

namespace DragonLoopModels
{
    public class Stop
    {
        public Stop()
        {
            Schedules = new HashSet<Schedule>();
            Buses = new HashSet<Bus>();
        }

        public int StopId { get; set; }

        public decimal XCoordinate { get; set; }

        public decimal YCoordinate { get; set; }

        public string Name { get; set; }

        public int RouteId { get; set; }

        public bool FirstStopFlg { get; set; }

        [JsonIgnore]
        public virtual Route Route { get; set; }

        [JsonIgnore]
        public virtual ICollection<Schedule> Schedules { get; set; }

        [JsonIgnore]
        public virtual RouteSegment RouteSegment { get; set; }

        [JsonIgnore]
        public virtual ICollection<Bus> Buses { get; set; }
    }
}
