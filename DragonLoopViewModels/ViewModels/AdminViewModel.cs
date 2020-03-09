using DragonLoopModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DragonLoopViewModels.Services;

namespace DragonLoopViewModels.ViewModels
{
    public class AdminViewModel
    {
        private BusService BusService;
        public IEnumerable<Bus> Buses { get; set; }

        public AdminViewModel(string urlBase)
        {
            BusService = new BusService(urlBase);
        }
        public async Task LoadBuses()
            => Buses = await BusService.GetBusesAsync();
    }
}
