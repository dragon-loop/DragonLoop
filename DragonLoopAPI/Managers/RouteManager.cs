using DragonLoopModels;
using System;
using System.Linq;
using DragonLoopAPI.Models;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections.Generic;

namespace DragonLoopAPI.Managers
{
    public class RouteManager
    {
        private readonly DragonLoopContext _context;

        public RouteManager(DragonLoopContext context)
        {
            _context = context;
        }
        public async Task<bool> TruncateRouteSchedule(int RouteId)
        {
            Route route = await _context.Routes.FindAsync(RouteId);
            if (route == null)
            {
                return false;
            }
            route.Schedules.Clear();
            return true;
        }

        public async Task<bool> SetRouteSchedules(int RouteId, ICollection<Schedule> schedules)
        {
            Route route = await _context.Routes.FindAsync(RouteId);
            if (route == null)
            {
                return false;
            }
            route.Schedules = schedules;
            return true;
        }

        public async Task<Schedule> GetNewSchedule(ScheduleInput input, int RouteId)
        {
            Route route = await _context.Routes.FindAsync(RouteId);
            Stop stop = _context.Stops.Where(s => s.Name.Contains(input.StopName)).First();

            if (stop == null || route == null)
            {
                return null;
            }

            TimeSpan expectedTime = DateTime.ParseExact(input.ExpectedTime,
                                  "h:mmtt", CultureInfo.InvariantCulture).TimeOfDay;
            return new Schedule
            {
                ExpectedTime = expectedTime,
                Route = route,
                Stop = stop
            };
        }
    }
}
