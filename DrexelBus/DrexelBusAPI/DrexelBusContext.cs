using DrexelBusModels;
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
                entity.ToTable("buses");

                entity.HasKey(e => e.BusId)
                    .HasName("bus_pkey");

                entity.Property(e => e.BusId)
                    .HasColumnName("bus_id")
                    .HasDefaultValueSql("nextval('bus_bus_id_seq'::regclass)");

                entity.Property(e => e.XCoordinate)
                    .HasColumnName("x_coordinate")
                    .HasColumnType("numeric");

                entity.Property(e => e.YCoordinate)
                    .HasColumnName("y_coordinate")
                    .HasColumnType("numeric");

                entity.Property(e => e.RouteId)
                    .HasColumnName("route_id");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Buses)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_fkey");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("routes");

                entity.HasKey(e => e.RouteId)
                    .HasName("route_pkey");

                entity.Property(e => e.RouteId)
                    .HasColumnName("route_id")
                    .HasDefaultValueSql("nextval('route_route_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();

                entity.HasMany(d => d.Buses)
                    .WithOne(p => p.Route);

                entity.HasMany(d => d.Stops)
                    .WithOne(p => p.Route);
            });

            modelBuilder.Entity<Stop>(entity =>
            {
                entity.ToTable("stops");

                entity.HasKey(e => e.StopId)
                    .HasName("stop_pkey");

                entity.HasIndex(e => e.NextStopId)
                    .HasName("next_stop_id_key")
                    .IsUnique();

                entity.Property(e => e.StopId)
                    .HasColumnName("stop_id")
                    .HasDefaultValueSql("nextval('stop_stop_id_seq'::regclass)");

                entity.Property(e => e.XCoordinate)
                    .HasColumnName("x_coordinate")
                    .HasColumnType("numeric");

                entity.Property(e => e.YCoordinate)
                    .HasColumnName("y_coordinate")
                    .HasColumnType("numeric");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsRequired();

                entity.Property(e => e.RouteId)
                    .HasColumnName("route_id");

                entity.Property(e => e.NextStopId)
                    .HasColumnName("next_stop_id");

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

                entity.HasOne(d => d.PreviousStop)
                    .WithOne(p => p.NextStop);
            });

            modelBuilder.HasSequence<int>("bus_bus_id_seq");

            modelBuilder.HasSequence<int>("route_route_id_seq");

            modelBuilder.HasSequence<int>("stop_stop_id_seq");
        }
    }
}
