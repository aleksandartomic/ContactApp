using ContcatXamarin.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ContcatXamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("AddPage", typeof(AddPage));

        }
    }
}
