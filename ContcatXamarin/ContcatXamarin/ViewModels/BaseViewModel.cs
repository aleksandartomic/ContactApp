using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using ContcatXamarin.Models;
using ContcatXamarin.Services;
using ContcatXamarin.Interfaces;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;

namespace ContcatXamarin.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, INavigationAware
    {
        public IRepository<User> Repository => App.Repository;

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
        
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void OnNavigatedFrom(object parameters)
        {
            
        }

        public virtual void OnNavigatedTo(object parameters)
        {
            
        }

        public async Task<PermissionStatus> CheckCameraPermissionAsync<TPermissions>()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
            }

            return status;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
