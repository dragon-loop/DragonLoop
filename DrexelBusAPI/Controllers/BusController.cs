using DrexelBusAPI.Managers;
using DrexelBusAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DrexelBusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IOptions<AppSettings> _config;
        private static BusManager _busManager;

        public BusController(IOptions<AppSettings> config)
        {
            _config = config;
            _busManager = new BusManager(_config);
        }

        // GET: api/Bus/5
        [HttpGet("{id}")]
        public Bus Get(int id)
        {
            return _busManager.GetBus(id);
        }
    }
}
