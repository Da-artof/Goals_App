using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Flyfly.Models;
using Flyfly.Views;
using Flyfly.Services;

namespace Flyfly.ViewModels
{
	public class WeeklyViewModel : BaseViewModel
	{
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }
        public Command<Item> Ticked { get; }
        bool isRefreshing = false;

        public WeeklyViewModel()
        {
            Title = "Weekly";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            Ticked = new Command<Item>(OnTick);
        }

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsRefreshing= true;

            try
            {
                Items.Clear();
                var items = await WDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        public void OnAppearing()
        {
            IsRefreshing = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(WeeklyNewItemPage));
        }

        async void OnTick(Item item)
        {
            if (item == null)
                return;

            
            await WDataStore.DeleteItemAsync(item.Id);
            
            IsRefreshing = true;
            IsRefreshing = false;
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}

