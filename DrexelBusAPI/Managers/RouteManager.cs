using DrexelBusAPI.Accessors;
using DrexelBusAPI.Models;
using Microsoft.Extensions.Options;

namespace DrexelBusAPI.Managers
{
    public class RouteManager
    {
        private readonly IOptions<AppSettings> _config;
        private static PostgresAccessor _pgAccessor;

        public RouteManager(IOptions<AppSettings> config)
        {
            _config = config;
            _pgAccessor = new PostgresAccessor(_config.Value.PgConnectionString);
        }

        public Route GetRoute(int id) =>
            _pgAccessor.GetRoute(id);
    }
}
