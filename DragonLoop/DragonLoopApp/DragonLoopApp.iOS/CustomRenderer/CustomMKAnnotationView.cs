using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MapKit;
using UIKit;

namespace DragonLoopApp.iOS.CustomRenderer
{
    public class CustomMKAnnotationView : MKAnnotationView
    {
        public string MarkerId { get; set; }

        public string Url { get; set; }

        public CustomMKAnnotationView(IMKAnnotation annotation, string id)
            : base(annotation, id)
        {
        }
    }
}