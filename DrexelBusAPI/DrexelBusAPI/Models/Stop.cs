using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrexelBusAPI.Models
{
    [Table("stops")]
    public partial class Stop
    {
        [Column("stop_id")]
        public int StopId { get; set; }

        [Column("x_coordinate", TypeName = "numeric")]
        public decimal XCoordinate { get; set; }

        [Column("y_coordinate", TypeName = "numeric")]
        public decimal YCoordinate { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("route_id")]
        public int RouteId { get; set; }

        [Column("next_stop_id")]
        public int? NextStopId { get; set; }

        [ForeignKey("NextStopId")]
        [InverseProperty("PreviousStop")]
        [JsonIgnore]
        public virtual Stop NextStop { get; set; }

        [ForeignKey("RouteId")]
        [InverseProperty("Stops")]
        [JsonIgnore]
        public virtual Route Route { get; set; }

        [InverseProperty("NextStop")]
        [JsonIgnore]
        public virtual Stop PreviousStop { get; set; }
    }
}
