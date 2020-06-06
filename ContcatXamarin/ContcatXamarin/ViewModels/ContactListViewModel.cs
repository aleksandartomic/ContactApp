using ContcatXamarin.Models;
using ContcatXamarin.Services;
using ContcatXamarin.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContcatXamarin.ViewModels
{
    public class ContactListViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public ICommand NavigateToPageCommand { get; private set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public List<User> Data { get; set; }
        public bool IsRefreshing { get; set; }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>((text) =>
                {
                    Users = new ObservableCollection<User>
                        (Data.Where(x => x.FullName.ToLower().Contains(text.ToString().ToLower())));
                }));
            }
        }


        public ContactListViewModel()
        {
            DeleteCommand = new Command(Delete);

            RefreshCommand = new Command(GetUsers);

            NavigateToPageCommand = new Command(NavigateToPage);
        }

        public async override void OnNavigatedTo(object parameters)
        {
            GetUsers();
        }

        public async void GetUsers()
        {
            IsRefreshing = true;
            Data = (await Repository.GetUsersAsync()).ToList();
            Users = new ObservableCollection<User> (Data);
            IsRefreshing = false;
        }

        public async void Delete(object id)
        {
            var result = await Shell.Current.DisplayAlert("Alert", "Are you sure", "Yes", "No");
            if (result == true)
            {
                Users.Remove(Users.Where(x => x.Id == (int)id).First());

                await Repository.DeleteUserAsync((int)id);
            }
            else
            {
                return;
            }
        }

        public async Task NavigateToUpdatePage(int id)
        {
            await Shell.Current.GoToAsync($"/AddPage?Id={id}");
        }

        public async Task NavigateToAddPage()
        {
            await Shell.Current.GoToAsync("/AddPage");
        }

        public async void NavigateToPage(object id)
        {
            if (id == null)
            {
                await NavigateToAddPage();
            }
            else
            {
                await NavigateToUpdatePage((int)id);
            }
        }
    }
}
