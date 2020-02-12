using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DragonLoopModels;
using DragonLoopAPI.Managers;
using System;
using System.Linq;

namespace DragonLoopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopController : ControllerBase
    {
        private readonly DragonLoopContext _context;
        private static readonly StopManager _stopManager = new StopManager();

        public StopController(DragonLoopContext context)
        {
            _context = context;
        }

        // GET: api/Stop/5/NextBus
        [HttpGet("{id}/NextBus")]
        public async Task<ActionResult<Bus>> GetNextBus(int id)
        {
            var stop = await _context.Stops.FindAsync(id);

            if (stop == null)
            {
                return NotFound();
            }

            if (!stop.Route.Buses.Where(b => b.InactiveFlag == false).Where(b => b.LastStop != null).Any())
            {
                return NoContent();
            }

            return _stopManager.GetNextBus(stop);
        }

        // GET: api/Stop/5/NextExpectedTime/5:00
        [HttpGet("{id}/NextExpectedTime/{time}")]
        public async Task<ActionResult<TimeSpan>> GetNextExpectedTime(int id, TimeSpan time)
        {
            var stop = await _context.Stops.FindAsync(id);

            if (stop == null)
            {
                return NotFound();
            }

            var schedules = _context.Schedules.Where(s => s.Stop.StopId == stop.StopId)
                                              .OrderBy(s => s.ExpectedTime)
                                              .ToList();

            return _stopManager.GetNextExpectedTime(schedules, time);           
        }
    }
}
