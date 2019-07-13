using DrexelBusAPI.Models;
using System;
using System.Linq;

namespace DrexelBusAPI.Managers
{
    public class BusManager
    {
        private readonly DrexelBusContext _context;

        public BusManager(DrexelBusContext context)
        {
            _context = context;
        }

        public Stop GetClosestStop(Bus bus)
        {
            var stops = _context.Stops.Where(stop => stop.route_id == bus.route_id);

            if (!stops.Any())
            {
                return null;
            }

            (Stop stop, decimal distance) closesetStop = (null, decimal.MaxValue);
            foreach (Stop stop in stops)
            {
                var distance = Distance((bus.x_coordinate, bus.y_coordinate), (stop.x_coordinate, stop.y_coordinate));
                if (distance < closesetStop.distance)
                {
                    closesetStop = (stop, distance);
                }
            }

            return closesetStop.stop;
        }

        private decimal Distance((decimal x, decimal y) point1, (decimal x, decimal y) point2)
        {
            return ((point1.x - point2.x) * (point1.x - point2.x)) + ((point1.y - point1.y) * (point1.y - point1.y));
        }
    }
}
