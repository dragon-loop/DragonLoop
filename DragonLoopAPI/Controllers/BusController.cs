using DragonLoopAPI.Managers;
using DragonLoopAPI.Models;
using DragonLoopModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DragonLoopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly DragonLoopContext _context;
        private readonly BusManager _busManager;

        public BusController(DragonLoopContext context)
        {
            _context = context;
            _busManager = new BusManager(context);
        }

        // POST: api/Bus/UpdateBusLocation
        [HttpPost("UpdateBusLocation")]
        public async Task<IActionResult> PostBusLocation(BusInput input)
        {
            ValidateInput(input);

            var buses = _context.Buses.Where(b => b.IMEI == input.IMEI.Value).ToList();

            if (buses.Count == 0)
            {
                var bus = await _busManager.GetNewBus(input);
                _context.Buses.Add(bus);
            }
            else if (buses.Count == 1)
            {
                await _busManager.UpdateExistingBus(buses[0], input);
            }
            else
            {
                throw new ArgumentException($"Multiple buses were found with IMEI number '{input.IMEI}'! None were updated.");
            }

            await _context.SaveChangesAsync();
            return Ok();
        }


        // POST: api/Bus/DeactivateBus/{imei}
        [HttpPost("DeactivateBus/{imei}")]
        public async Task<IActionResult> DeactivateBus(long imei)
        {
            var buses = _context.Buses.Where(b => b.IMEI == imei).ToList();

            if (buses.Count < 1)
            {
                throw new ArgumentException($"No buses were found with IMEI number '{imei}'!");
            }
            else if (buses.Count > 1)
            {
                throw new ArgumentException($"Multiple buses were found with IMEI number '{imei}'! None were updated.");
            }
            else
            {
                buses[0].InactiveFlag = true;
            }           

            await _context.SaveChangesAsync();
            return Ok();
        }

        private void ValidateInput(BusInput input)
        {
            if (input.XCoordinate == null || input.YCoordinate == null || input.RouteId == null || input.IMEI == null)
            {
                throw new ArgumentException("A Route ID and X and Y coordinates must be included in the body of the request.");
            }
        }
    }
}
