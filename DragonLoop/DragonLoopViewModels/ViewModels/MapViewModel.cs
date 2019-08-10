using DragonLoopModels;
using DragonLoopViewModels.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonLoopViewModels.ViewModels
{
    public class MapViewModel
    {
        public IEnumerable<Route> Routes { get; set; }

        private RouteService RouteService;

        public MapViewModel(string urlBase)
        {
            RouteService = new RouteService(urlBase);
        }

        public async Task LoadRoutes()
            => Routes = await RouteService.GetRoutesAsync();
    }
}
