using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.App.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();
        }

        private async void LoadItems()
        {
            var items = await App.Context.GetItemAsyn();
            lista.ItemsSource = items;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void delete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirm", "Are you sure delete the element?", "Yes", "No"))
            {
                var item = (ToDoItem)(sender as MenuItem).CommandParameter;
                var r = await App.Context.DeleteItemAsyn(item);
                if (r==1)
                {
                    LoadItems();
                }
            }
        }
    }
}