using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace DragonLoopApp.ViewModels
{
    public class AboutViewModel
    {
        public string Title { get; set; }

        public ICommand OpenWebCommand { get; }

        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }
    }
}