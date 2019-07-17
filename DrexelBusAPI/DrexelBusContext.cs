using DrexelBusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DrexelBusAPI
{
    public class DrexelBusContext : DbContext
    {
        public DrexelBusContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Stop> Stops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>(entity =>
            {
                entity.HasKey(e => e.BusId)
                    .HasName("bus_pkey");

                entity.Property(e => e.BusId).HasDefaultValueSql("nextval('bus_bus_id_seq'::regclass)");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Buses)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_fkey");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.RouteId)
                    .HasName("route_pkey");

                entity.Property(e => e.RouteId).HasDefaultValueSql("nextval('route_route_id_seq'::regclass)");
            });

            modelBuilder.Entity<Stop>(entity =>
            {
                entity.HasKey(e => e.StopId)
                    .HasName("stop_pkey");

                entity.HasIndex(e => e.NextStopId)
                    .HasName("next_stop_id_key")
                    .IsUnique();

                entity.Property(e => e.StopId).HasDefaultValueSql("nextval('stop_stop_id_seq'::regclass)");

                entity.HasOne(d => d.NextStop)
                    .WithOne(p => p.PreviousStop)
                    .HasForeignKey<Stop>(d => d.NextStopId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("next_stop_id_fkey");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Stops)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_fkey");
            });

            modelBuilder.HasSequence<int>("bus_bus_id_seq");

            modelBuilder.HasSequence<int>("route_route_id_seq");

            modelBuilder.HasSequence<int>("stop_stop_id_seq");
        }
    }
}
