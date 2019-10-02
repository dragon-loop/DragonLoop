using System;
using System.Collections.Generic;
using System.Text;

namespace DragonLoopApp.Models
{
    public enum MenuItemType
    {
        Map,
        Schedules,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
