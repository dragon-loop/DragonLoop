using DrexelBusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DrexelBusAPI
{
    public class DrexelBusContext : DbContext
    {
        public DbSet<Bus> Buses { get; set; }

        public DbSet<Route> Route { get; set; }

        public DbSet<Stop> Stop { get; set; }

        public DrexelBusContext(DbContextOptions options) : base(options) { }        
    }
}
