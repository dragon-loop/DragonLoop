using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DragonLoopApp.Services;
using DragonLoopApp.Views;

namespace DragonLoopApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<BusService>();
            DependencyService.Register<RouteService>();
            DependencyService.Register<StopService>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
