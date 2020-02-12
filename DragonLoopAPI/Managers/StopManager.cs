using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonLoopAPI.Managers
{
    public class StopManager
    {
        /// <summary>
        /// Backtracks route segments to find previous stops and check for buses on this route that
        /// have last stopped there
        /// </summary>
        /// <param name="stop">The stop to find the next bus to arrive at</param>
        /// <returns>The next bus to arrive at the given stop</returns>
        public Bus GetNextBus(Stop stop)
        {
            Bus bus;
            var routeSegment = stop.RouteSegment.PreviousRouteSegment;

            //look through previous route segments until a stop is found that a bus has recently stopped at
            while (routeSegment.FromStop == null || !TryGetBusAtStop(routeSegment.FromStop, out bus))
            {
                routeSegment = routeSegment.PreviousRouteSegment;
            }

            return bus;
        }

        /// <summary>
        /// Get the first bus that has most recently stopped at the given stop
        /// </summary>
        /// <param name="stop">The stop to find buses at</param>
        /// <param name="bus">The bus that first passed this stop</param>
        /// <returns>If a bus was most recently at the given stop</returns>
        private bool TryGetBusAtStop(Stop stop, out Bus bus)
        {
            var buses = stop.Buses.Where(b => b.InactiveFlag == false);
            if (buses.Any())
            {
                (Bus bus, TimeSpan time) firstBus = (null, TimeSpan.MaxValue);

                foreach (Bus b in buses)
                {
                    if (b.LastStopTime < firstBus.time)
                    {
                        firstBus = (b, b.LastStopTime.Value);
                    }
                }

                bus = firstBus.bus;
                return true;
            }
            else
            {
                bus = null;
                return false;
            }
        }

        /// <summary>
        /// Iterates through Schedules to find the next expected arrival time for the given stop
        /// after the given time. Return the first stop of the next day if no buses arrive at that
        /// stop for the rest of the current day.
        /// </summary>
        /// <param name="schedules">The ordered list of schedules to iterate through</param>
        /// <param name="time">The time to start searching for next expected time from</param>
        /// <returns>The next expected time of a bus to the given stop</returns>
        public TimeSpan GetNextExpectedTime(IEnumerable<Schedule> schedules, TimeSpan time)
        {
            foreach (Schedule schedule in schedules)
            {
                if (schedule.ExpectedTime > time)
                {
                    return schedule.ExpectedTime;
                }
            }

            return schedules.First().ExpectedTime;
        }
    }
}
