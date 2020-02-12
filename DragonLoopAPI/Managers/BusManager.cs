using DragonLoopAPI.Models;
using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonLoopAPI.Managers
{
    public class BusManager
    {
        private readonly DragonLoopContext _context;
        private const double StopDistance = 0.001;

        public BusManager(DragonLoopContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a new <see cref="Bus"/> from the data given in the POST request
        /// </summary>
        /// <param name="input">The input <see cref="BusInput"/> from the request</param>
        /// <returns>A new <see cref="Bus"/></returns>
        public async Task<Bus> GetNewBus(BusInput input)
        {
            var route = await _context.Routes.FindAsync(input.RouteId);
            var nextSchedule = GetNextSchedule(route, DateTime.Now.TimeOfDay);

            return new Bus
            {
                XCoordinate = input.XCoordinate.Value,
                YCoordinate = input.YCoordinate.Value,
                RouteId = input.RouteId.Value,
                TripId = nextSchedule.TripId,
                IMEI = input.IMEI.Value,
                InactiveFlag = false
            };
        }

        /// <summary>
        /// Get the first schedule object on the route with a larger time than the given time.
        /// Return the first schedule if the time is later than every schedule on the route.
        /// </summary>
        /// <param name="route">The route to search for schedules from</param>
        /// <param name="time">The time to find the next schedule for</param>
        /// <returns>The next schedule</returns>
        private Schedule GetNextSchedule(Route route, TimeSpan time)
        {
            var schedules = route.Schedules.OrderBy(s => s.ExpectedTime);

            foreach (var schedule in schedules)
            {
                if (time < schedule.ExpectedTime)
                {
                    return schedule;
                }
            }

            return schedules.First();
        }

        /// <summary>
        /// Set the <see cref="Bus"/> attributes based on the given <see cref="BusInput"/>
        /// </summary>
        /// <param name="bus">The bus to update</param>
        /// <param name="input">The input <see cref="BusInput"/> from the request</param>
        public async Task UpdateExistingBus(Bus bus, BusInput input)
        {
            bus.XCoordinate = input.XCoordinate.Value;
            bus.YCoordinate = input.YCoordinate.Value;
            bus.RouteId = input.RouteId.Value;
            bus.InactiveFlag = false;

            var route = await _context.Routes.FindAsync(input.RouteId);
            var closestStop = GetClosestStop(bus, route);

            if (closestStop != null)
            {
                bus.LastStopId = closestStop.StopId;
                bus.LastStopTime = DateTime.Now.TimeOfDay;

                if (closestStop.FirstStopFlg)
                {
                    var firstStopSchedules = route.Schedules.Where(s => s.Stop.FirstStopFlg);
                    var closestSchedule = GetClosestSchedule(firstStopSchedules, DateTime.Now.TimeOfDay);
                    bus.TripId = closestSchedule.TripId;
                }
            }
        }

        /// <summary>
        /// If there is a <see cref="Stop"/> on the route within <see cref="StopDistance"/> from the bus, return it.
        /// Otherwise return null.
        /// </summary>
        /// <param name="bus">The <see cref="Bus"/></param>
        /// <param name="route">The <see cref="Route"/> to search for stops on</param>
        /// <returns>The closest stop if available</returns>
        private Stop? GetClosestStop(Bus bus, Route route)
        {
            foreach (var stop in route.Stops)
            {
                if (GetDistance(bus, stop) < StopDistance)
                {
                    return stop;
                }
            }

            return null;
        }

        /// <summary>
        /// Calculate distance between a <see cref="Bus"/> and <see cref="Stop"/> coordinates
        /// </summary>
        /// <param name="bus">The <see cref="Bus"/></param>
        /// <param name="stop">The <see cref="Stop"/></param>
        /// <returns>The distance between the bus and the stop</returns>
        private double GetDistance(Bus bus, Stop stop)
            => Math.Sqrt(Math.Pow(decimal.ToDouble(stop.XCoordinate - bus.XCoordinate), 2) + Math.Pow(decimal.ToDouble(stop.YCoordinate - bus.YCoordinate), 2));

        /// <summary>
        /// Return the <see cref="Schedule"/> that has an expected time closest to the given time
        /// </summary>
        /// <param name="schedules">The schedules to search through</param>
        /// <param name="time">The time to find the closest schedule for</param>
        /// <returns>The <see cref="Schedule"/> with the closest time to the input</returns>
        private Schedule GetClosestSchedule(IEnumerable<Schedule> schedules, TimeSpan time)
        {
            (TimeSpan timeDifference, Schedule schedule) closestSchedule = (TimeSpan.MaxValue, null);

            foreach (var schedule in schedules)
            {
                var timeDifference = (schedule.ExpectedTime - time).Duration();
                if (timeDifference < closestSchedule.timeDifference)
                {
                    closestSchedule = (timeDifference, schedule);
                }
            }

            return closestSchedule.schedule;
        }
    }
}
