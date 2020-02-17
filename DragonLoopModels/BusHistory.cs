using Newtonsoft.Json;
using System;

namespace DragonLoopModels
{
    public class BusHistory
    {
        public int BusHistoryId { get; set; }

        public int BusId { get; set; }

        public decimal XCoordinate { get; set; }

        public decimal YCoordinate { get; set; }

        public int RouteId { get; set; }

        [JsonIgnore]
        public virtual Route Route { get; set; }

        [JsonIgnore]
        public virtual Route Bus { get; set; }
    }
}
