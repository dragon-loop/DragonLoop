using DrexelBusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DrexelBusAPI
{
    public class DrexelBusContext : DbContext
    {
        public DbSet<Bus> Buses { get; set; }

        public DrexelBusContext(DbContextOptions options) : base(options) { }

        public DbSet<DrexelBusAPI.Models.Route> Route { get; set; }

        public DbSet<DrexelBusAPI.Models.Stop> Stop { get; set; }
    }
}
