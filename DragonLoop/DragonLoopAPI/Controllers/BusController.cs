using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DragonLoopAPI.Managers;
using DragonLoopModels;

namespace DragonLoopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly DragonLoopContext _context;
        private static BusManager _busManager = new BusManager();

        public BusController(DragonLoopContext context)
        {
            _context = context;
        }

        // GET: api/Bus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bus>>> GetBuses()
        {
            return await _context.Buses.ToListAsync();
        }

        // GET: api/Bus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> GetBus(int id)
        {
            var bus = await _context.Buses.FindAsync(id);

            if (bus == null)
            {
                return NotFound();
            }

            return bus;
        }

        // GET: api/Bus/5/ClosestStop
        [HttpGet("{id}/ClosestStop")]
        public async Task<ActionResult<Stop>> GetClosestStop(int id)
        {
            var bus = await _context.Buses.FindAsync(id);

            if (bus == null)
            {
                return NotFound();
            }

            return _busManager.GetClosestStop(bus);
        }

        // PUT: api/Bus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBus(int id, Bus bus)
        {
            if (id != bus.BusId)
            {
                return BadRequest();
            }

            _context.Entry(bus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

		//PUT: api/Bus/5/UpdateBusLocation
		///<summary>
		/// This method will update a bus's location given an ID. The request will be made as follows:
		/// content-type: application/json
		/// {
		///		XCoordinate : "1.00",
		///		YCoordinate : "1.00"
		/// }
		/// </summary>
		[HttpPut("{id}/UpdateBusLocation")]
		public async Task<IActionResult> PutBusLocation(int id, Bus newBusCoord)
		{
            Bus existingBus = await _context.Buses.FindAsync(id);
			
			if(existingBus != null)
			{
				existingBus.XCoordinate = newBusCoord.XCoordinate;
				existingBus.YCoordinate = newBusCoord.YCoordinate;

				try
				{
					await _context.SaveChangesAsync();

					return Ok();
				}
				catch (DbUpdateConcurrencyException)
				{
                    throw;
				}
			}
			return NoContent();
		}

        // POST: api/Bus
        [HttpPost]
        public async Task<ActionResult<Bus>> PostBus(Bus bus)
        {
            _context.Buses.Add(bus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBus", new { id = bus.BusId }, bus);
        }

        // DELETE: api/Bus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bus>> DeleteBus(int id)
        {
            var bus = await _context.Buses.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }

            _context.Buses.Remove(bus);
            await _context.SaveChangesAsync();

            return bus;
        }

        private bool BusExists(int id)
        {
            return _context.Buses.Any(e => e.BusId == id);
        }
    }
}
