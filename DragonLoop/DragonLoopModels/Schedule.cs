using Newtonsoft.Json;
using System;

namespace DragonLoopModels
{
    public class Schedule
    {
        public int RouteId { get; set; }

        public int TripId { get; set; }

        public int StopId { get; set; }

        public TimeSpan ExpectedTime { get; set; }

        [JsonIgnore]
        public virtual Route Route { get; set; }

        [JsonIgnore]
        public virtual Stop Stop { get; set; }
    }
}
