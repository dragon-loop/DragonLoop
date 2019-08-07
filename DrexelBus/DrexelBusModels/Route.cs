﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace DrexelBusModels
{
    public class Route
    {
        public Route()
        {
            Buses = new HashSet<Bus>();
            Stops = new HashSet<Stop>();
        }

        public int RouteId { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Bus> Buses { get; set; }

        [JsonIgnore]
        public virtual ICollection<Stop> Stops { get; set; }
    }
}