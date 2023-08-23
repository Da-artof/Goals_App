using System;
using System.Windows.Input;
using Flyfly.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Flyfly.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Command AddItemCommand { get; }

        public AboutViewModel()
        {
            Title = "Goals";
            AddItemCommand = new Command(OnAddItem);
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

    }
}
