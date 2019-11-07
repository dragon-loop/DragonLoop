using DragonLoopModels;
using Microsoft.EntityFrameworkCore;

namespace DragonLoopAPI
{
    public class DragonLoopContext : DbContext
    {
        public DragonLoopContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Stop> Stops { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<RouteSegment> RouteSegments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack");

            modelBuilder.Entity<Bus>(entity =>
            {
                entity.HasKey(e => e.BusId)
                    .HasName("bus_pkey");

                entity.ToTable("buses");

                entity.Property(e => e.BusId)
                    .HasColumnName("bus_id")
                    .HasDefaultValueSql("nextval('bus_bus_id_seq'::regclass)");

                entity.Property(e => e.LastStopId).HasColumnName("last_stop_id");

                entity.Property(e => e.LastStopTime)
                    .HasColumnName("last_stop_time")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.TripId).HasColumnName("trip_id");

                entity.Property(e => e.XCoordinate)
                    .HasColumnName("x_coordinate")
                    .HasColumnType("numeric");

                entity.Property(e => e.YCoordinate)
                    .HasColumnName("y_coordinate")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.LastStop)
                    .WithMany(p => p.Buses)
                    .HasForeignKey(d => d.LastStopId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("last_stop_id_fkey");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Buses)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_fkey");
            });

            modelBuilder.Entity<RouteSegment>(entity =>
            {
                entity.HasKey(e => e.RouteSegmentId)
                    .HasName("route_segments_pkey");

                entity.ToTable("route_segments");

                entity.HasIndex(e => e.NextRouteSegmentId)
                    .HasName("next_route_segment_id_key")
                    .IsUnique();

                entity.Property(e => e.RouteSegmentId).HasColumnName("route_segment_id");

                entity.Property(e => e.FromStopId).HasColumnName("from_stop_id");

                entity.Property(e => e.NextRouteSegmentId).HasColumnName("next_route_segment_id");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.StartXCoordinate)
                    .HasColumnName("start_x_coordinate")
                    .HasColumnType("numeric");

                entity.Property(e => e.StartYCoordinate)
                    .HasColumnName("start_y_coordinate")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.FromStop)
                    .WithMany(p => p.RouteSegments)
                    .HasForeignKey(d => d.FromStopId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("from_stop_id_fkey");

                entity.HasOne(d => d.NextRouteSegment)
                    .WithOne(p => p.PreviousRouteSegment)
                    .HasForeignKey<RouteSegment>(d => d.NextRouteSegmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("next_route_segment_id_fkey");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.RouteSegments)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_fkey");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.RouteId)
                    .HasName("route_pkey");

                entity.ToTable("routes");

                entity.Property(e => e.RouteId)
                    .HasColumnName("route_id")
                    .HasDefaultValueSql("nextval('route_route_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => new { e.RouteId, e.TripId, e.StopId })
                    .HasName("schedules_pkey");

                entity.ToTable("schedules");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.TripId).HasColumnName("trip_id");

                entity.Property(e => e.StopId).HasColumnName("stop_id");

                entity.Property(e => e.ExpectedTime)
                    .HasColumnName("expected_time")
                    .HasColumnType("time without time zone");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_fkey");

                entity.HasOne(d => d.Stop)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.StopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stop_id_fkey");
            });

            modelBuilder.Entity<Stop>(entity =>
            {
                entity.HasKey(e => e.StopId)
                    .HasName("stop_pkey");

                entity.ToTable("stops");

                entity.Property(e => e.StopId)
                    .HasColumnName("stop_id")
                    .HasDefaultValueSql("nextval('stop_stop_id_seq'::regclass)");

                entity.Property(e => e.FirstStopFlg).HasColumnName("first_stop_flg");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.XCoordinate)
                    .HasColumnName("x_coordinate")
                    .HasColumnType("numeric");

                entity.Property(e => e.YCoordinate)
                    .HasColumnName("y_coordinate")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Stops)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("route_id_fkey");
            });
        }
    }
}
