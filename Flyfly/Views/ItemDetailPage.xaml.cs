using System.ComponentModel;
using Xamarin.Forms;
using Flyfly.ViewModels;

namespace Flyfly.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
