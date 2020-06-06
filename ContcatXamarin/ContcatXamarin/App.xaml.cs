using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContcatXamarin.Services;
using ContcatXamarin.Views;
using ContcatXamarin.Models;
using System.Diagnostics;

namespace ContcatXamarin
{
    public partial class App : Application
    {
        public static Repository Repository;
        public App(string dbPath)
        {
            InitializeComponent();

            Repository = new Repository(dbPath);
            Repository.Database.EnsureCreated();
            //DependencyService.Register<IDataStore<User>>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
