using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrexelBusAPI.Models
{
    [Table("buses")]
    public partial class Bus
    {
        [Column("bus_id")]
        public int BusId { get; set; }

        [Column("x_coordinate", TypeName = "numeric")]
        public decimal XCoordinate { get; set; }

        [Column("y_coordinate", TypeName = "numeric")]
        public decimal YCoordinate { get; set; }

        [Column("route_id")]
        public int RouteId { get; set; }

        [ForeignKey("RouteId")]
        [InverseProperty("Buses")]
        [JsonIgnore]
        public virtual Route Route { get; set; }
    }
}
