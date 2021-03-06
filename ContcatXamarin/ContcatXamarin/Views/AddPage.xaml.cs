﻿using ContcatXamarin.Models;
using ContcatXamarin.ViewModels;
using ContcatXamarin.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContcatXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : BasePage
    {
        public AddPage()
        {
            InitializeComponent();

            BindingContext = new AddPageViewModel();
        }
    }
}