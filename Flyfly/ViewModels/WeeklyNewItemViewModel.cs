﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Flyfly.Models;
using Flyfly.Services;
using Xamarin.Forms;
using static Xamarin.Essentials.AppleSignInAuthenticator;

namespace Flyfly.ViewModels
{
    public class WeeklyNewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;
        private static string repeat;
        public ObservableCollection<String> Options { get; set; }


        public WeeklyNewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += 
                (_, __) => SaveCommand.ChangeCanExecute();
            Options = new ObservableCollection<String>
            {"Yes", "No"};
        }

        private bool ValidateSave()
        {
            bool a = !String.IsNullOrWhiteSpace(text) && !String.IsNullOrWhiteSpace(description);
            return a;
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public static void setRepeat(string r)
        {
            repeat = r;

        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description,
                Repeat = repeat
            };
            
            await WDataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}

