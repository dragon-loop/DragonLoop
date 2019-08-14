using Newtonsoft.Json;
using System.Collections.Generic;

namespace DragonLoopModels
{
    public class Stop
    {
        public Stop()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int StopId { get; set; }

        public decimal XCoordinate { get; set; }

        public decimal YCoordinate { get; set; }

        public string Name { get; set; }

        public int RouteId { get; set; }

        public int? NextStopId { get; set; }

        [JsonIgnore]
        public virtual Stop NextStop { get; set; }

        [JsonIgnore]
        public virtual Route Route { get; set; }

        [JsonIgnore]
        public virtual Stop PreviousStop { get; set; }

        [JsonIgnore]
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
