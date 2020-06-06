using ContcatXamarin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContcatXamarin.Views.Base
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePage : ContentPage
    {
        public BasePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            (BindingContext as INavigationAware)?.OnNavigatedTo(null);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            (BindingContext as INavigationAware)?.OnNavigatedFrom(null);
        }
    }
}