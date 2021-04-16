using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClassCreaterClient.Views;
using System.Collections.Generic;
using ClassCreaterClient.Moldes;

namespace ClassCreaterClient
{
    public partial class App : Application
    {
        public List<Class> AllClasses;
        public bool needClassRefresh;

        public App()
        {
            InitializeComponent();
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
