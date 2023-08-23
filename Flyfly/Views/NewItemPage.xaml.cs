using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Flyfly.Models;
using Flyfly.ViewModels;

namespace Flyfly.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedOption = (String)picker.SelectedItem;

            if (selectedOption != null)
            {
                NewItemViewModel.setRepeat(selectedOption);
            }
        }
    }
}
