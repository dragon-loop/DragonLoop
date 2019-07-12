using DrexelBusAPI.Managers;
using DrexelBusAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DrexelBusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopController : ControllerBase
    {
        private readonly IOptions<AppSettings> _config;
        private static StopManager _stopManager;

        public StopController(IOptions<AppSettings> config)
        {
            _config = config;
            _stopManager = new StopManager(_config);
        }

        // GET: api/Stop/5
        [HttpGet("{id}")]
        public Stop Get(int id)
        {
            return _stopManager.GetStop(id);
        }
    }
}
