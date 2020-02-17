using DragonLoopAPI.Models;
using DragonLoopModels;
using System.Threading.Tasks;

namespace DragonLoopAPI.Managers
{
    public class BusHistoryManager
    {
        private readonly DragonLoopContext _context;

        public BusHistoryManager(DragonLoopContext context)
        {
            _context = context;
        }

        public async Task<BusHistory> AddHistory(Bus bus)
        {
            return new BusHistory
            {
                BusId = bus.BusId,
                XCoordinate = bus.XCoordinate,
                YCoordinate = bus.YCoordinate,
                RouteId = bus.RouteId,
            };
        }

    }
}
