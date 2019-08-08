using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using DragonLoopApp.Models;
using DragonLoopApp.Services;
using DragonLoopModels;

namespace DragonLoopApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataService<Bus> BusService => DependencyService.Get<IDataService<Bus>>() ?? new BusService();
        public IDataService<Route> RouteService => DependencyService.Get<IDataService<Route>>() ?? new RouteService();
        public IDataService<Stop> StopService => DependencyService.Get<IDataService<Stop>>() ?? new StopService();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
