using Newtonsoft.Json;

namespace DrexelBusModels
{
    public class Bus
    {
        public int BusId { get; set; }

        public decimal XCoordinate { get; set; }

        public decimal YCoordinate { get; set; }

        public int RouteId { get; set; }

        [JsonIgnore]
        public virtual Route Route { get; set; }
    }
}
