using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace DragonLoopApp.Views.MapElements
{
    public class CustomMap : Map
    {
        public CustomMap(MapSpan region) : base(region)
        {
            CustomPins = new List<CustomPin>();
        }
        public List<CustomPin> CustomPins { get; set; }
    }
}
