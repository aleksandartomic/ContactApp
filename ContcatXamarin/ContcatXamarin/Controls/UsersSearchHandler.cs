using ContcatXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ContcatXamarin.Controls
{
    public class UsersSearchHandler : SearchHandler
    {
        public static readonly BindableProperty ItemSourceProperty =
                      BindableProperty.Create(nameof(ItemSource), typeof(ObservableCollection<User>), typeof(UsersSearchHandler), null);

        public ObservableCollection<User> ItemSource
        {
            get { return (ObservableCollection<User>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            if (ItemSource != null)
            {
                if (string.IsNullOrWhiteSpace(newValue))
                {
                    ItemsSource = null;
                }
                else
                {
                    ItemsSource = ItemSource
                        .Where(monkey => monkey.Name.ToLower().Contains(newValue.ToLower()));
                }
            }
        }
    }
}
