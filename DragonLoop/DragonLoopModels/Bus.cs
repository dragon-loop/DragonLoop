using Newtonsoft.Json;
using System;

namespace DragonLoopModels
{
    public class Bus
    {
        public int BusId { get; set; }

        public decimal XCoordinate { get; set; }

        public decimal YCoordinate { get; set; }

        public int RouteId { get; set; }

        public int TripId { get; set; }

        public int? LastStopId { get; set; }

        public TimeSpan? LastStopTime { get; set; }

        [JsonIgnore]
        public virtual Stop LastStop { get; set; }

        [JsonIgnore]
        public virtual Route Route { get; set; }
    }
}
