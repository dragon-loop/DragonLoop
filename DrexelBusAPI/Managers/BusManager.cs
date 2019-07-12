using DrexelBusAPI.Accessors;
using DrexelBusAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DrexelBusAPI.Managers
{
    public class BusManager
    {
        private readonly IOptions<AppSettings> _config;
        private static PostgresAccessor _pgAccessor;        

        public BusManager(IOptions<AppSettings> config)
        {
            _config = config;
            _pgAccessor = new PostgresAccessor(_config.Value.PgConnectionString);
        }

        public Bus GetBus(int id) =>
            _pgAccessor.GetBus(id);
    }
}
