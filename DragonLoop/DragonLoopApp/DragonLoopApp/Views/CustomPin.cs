using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace DragonLoopApp.Views
{
    public class CustomPin : Pin
    {
        public string Url { get; set; }
        public int RouteId { get; set; }
    }
}
