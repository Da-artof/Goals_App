using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Flyfly.Services;
using Flyfly.Views;
using Flyfly.Models;

namespace Flyfly
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();


            DependencyService.Register<MockDataStore>();
            DependencyService.Register<WeeklyMockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

