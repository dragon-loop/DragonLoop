using DrexelBusAPI.Managers;
using DrexelBusAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DrexelBusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IOptions<AppSettings> _config;
        private static RouteManager _routeManager;

        public RouteController(IOptions<AppSettings> config)
        {
            _config = config;
            _routeManager = new RouteManager(_config);
        }

        // GET: api/Route/5
        [HttpGet("{id}")]
        public Route Get(int id)
        {
            return _routeManager.GetRoute(id);
        }
    }
}
