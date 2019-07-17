using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrexelBusAPI.Models
{
    [Table("routes")]
    public partial class Route
    {
        public Route()
        {
            Buses = new HashSet<Bus>();
            Stops = new HashSet<Stop>();
        }

        [Column("route_id")]
        public int RouteId { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [InverseProperty("Route")]
        [JsonIgnore]
        public virtual ICollection<Bus> Buses { get; set; }

        [InverseProperty("Route")]
        [JsonIgnore]
        public virtual ICollection<Stop> Stops { get; set; }
    }
}
