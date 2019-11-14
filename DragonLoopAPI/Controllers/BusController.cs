using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DragonLoopModels;

namespace DragonLoopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly DragonLoopContext _context;

        public BusController(DragonLoopContext context)
        {
            _context = context;
        }

        // PUT: api/Bus/5/UpdateBusLocation
        /// <summary>
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
            var existingBus = await _context.Buses.FindAsync(id);

            if (existingBus != null)
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
    }
}
