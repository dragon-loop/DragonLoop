using DragonLoopModels;

namespace DragonLoopAPI.Managers
{
    public class BusManager
    {
        public Stop GetClosestStop(Bus bus)
        {
            (Stop stop, decimal distance) closesetStop = (null, decimal.MaxValue);
            foreach (Stop stop in bus.Route.Stops)
            {
                var distance = Distance((bus.XCoordinate, bus.YCoordinate), (stop.XCoordinate, stop.YCoordinate));
                if (distance < closesetStop.distance)
                {
                    closesetStop = (stop, distance);
                }
            }

            return closesetStop.stop;
        }

        private static decimal Distance((decimal x, decimal y) point1, (decimal x, decimal y) point2)
            => ((point1.x - point2.x) * (point1.x - point2.x)) + ((point1.y - point1.y) * (point1.y - point1.y));
    }
}
