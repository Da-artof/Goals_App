using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Flyfly.Models;
using Flyfly.Views;
using Flyfly.ViewModels;

namespace Flyfly.Views
{
    public partial class WeeklyPage : ContentPage
    {
        WeeklyViewModel _viewModel;

        public WeeklyPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new WeeklyViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
