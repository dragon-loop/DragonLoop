using DrexelBusAPI.Models;
using Npgsql;

namespace DrexelBusAPI.Accessors
{
    public class PostgresAccessor
    {
        string _connectionString;

        public PostgresAccessor(string connStr) =>
            _connectionString = connStr;

        public Bus GetBus(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand($"SELECT bus_id, x_coordinate, y_coordinate, route_id FROM drexelbus.buses WHERE bus_id = {id}", conn))
                using (var dbReader = cmd.ExecuteReader())
                {
                    if (dbReader.Read())
                    {
                        return new Bus
                        {
                            Id = (int)dbReader[0],
                            X_coordinate = (decimal)dbReader[1],
                            Y_coordinate = (decimal)dbReader[2],
                            Route_id = (int)dbReader[3]
                        };
                    }
                    return new Bus();
                }
            }
        }

        public Route GetRoute(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand($"SELECT route_id, name, initial_stop, final_stop, stops FROM drexelbus.routes WHERE route_id = {id}", conn))
                using (var dbReader = cmd.ExecuteReader())
                {
                    if (dbReader.Read())
                    {
                        return new Route
                        {
                            Id = (int)dbReader[0],
                            Name = (string)dbReader[1],
                            Initial_stop = (int)dbReader[2],
                            Final_stop = (int)dbReader[3],
                            Stops = (int[])dbReader[4]
                        };
                    }
                    return new Route();
                }
            }
        }

        public Stop GetStop(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand($"SELECT stop_id, x_coordinate, y_coordinate, name FROM drexelbus.stops WHERE stop_id = {id}", conn))
                using (var dbReader = cmd.ExecuteReader())
                {

                    if (dbReader.Read())
                    {
                        return new Stop
                        {
                            Id = (int)dbReader[0],
                            X_coordinate = (decimal)dbReader[1],
                            Y_coordinate = (decimal)dbReader[2],
                            Name = (string)dbReader[3]
                        };
                    }
                    return new Stop();
                }
            }
        }
    }
}
