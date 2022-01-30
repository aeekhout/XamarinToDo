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
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private async void save_Clicked(object sender, EventArgs e)
        {
            try
            {
                var item = new ToDoItem
                {
                    Name = name.Text,
                    Description = description.Text
                };
                var r = await App.Context.InsertItemAsyn(item);
                if (r==1)
                {
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Add fail!", "Ok");
                }

            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }

        }
    }
}