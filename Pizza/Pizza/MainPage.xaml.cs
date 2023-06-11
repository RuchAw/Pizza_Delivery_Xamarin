using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using System.IO;
using Xamarin.Forms.Xaml;

namespace Pizza
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ListerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CartList());
        }

        private void AddToCart_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPizza());
        }

        private void ModifyCart_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModifyCart());
        }

        private void DeleteCart_Clicked(object sender, EventArgs e)
        {
            App.Database.RemoveCart();
            DisplayAlert("Warning", "Your Cart is now clean", "Ok");
        }
    }
}
