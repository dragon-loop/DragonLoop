using DrexelBusAPI.Accessors;
using DrexelBusAPI.Models;
using Microsoft.Extensions.Options;

namespace DrexelBusAPI.Managers
{
    public class StopManager
    {
        private readonly IOptions<AppSettings> _config;
        private static PostgresAccessor _pgAccessor;

        public StopManager(IOptions<AppSettings> config)
        {
            _config = config;
            _pgAccessor = new PostgresAccessor(_config.Value.PgConnectionString);
        }

        public Stop GetStop(int id) =>
            _pgAccessor.GetStop(id);
    }
}
