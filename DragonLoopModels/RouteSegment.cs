using Newtonsoft.Json;

namespace DragonLoopModels
{
    public class RouteSegment
    {
        public int RouteSegmentId { get; set; }

        public decimal StartXCoordinate { get; set; }

        public decimal StartYCoordinate { get; set; }

        public int RouteId { get; set; }

        public int? NextRouteSegmentId { get; set; }

        public int? FromStopId { get; set; }

        [JsonIgnore]
        public virtual Route Route { get; set; }

        [JsonIgnore]
        public virtual RouteSegment NextRouteSegment { get; set; }

        [JsonIgnore]
        public virtual RouteSegment PreviousRouteSegment { get; set; }

        [JsonIgnore]
        public virtual Stop FromStop { get; set; }
    }
}
