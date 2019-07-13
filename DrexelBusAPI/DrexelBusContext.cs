using DrexelBusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DrexelBusAPI
{
    public class DrexelBusContext : DbContext
    {
        public DbSet<Bus> Buses { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Stop> Stops { get; set; }

        public DrexelBusContext(DbContextOptions options) : base(options) { }        
    }
}
