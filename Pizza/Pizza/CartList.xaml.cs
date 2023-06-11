using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pizza
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartList : ContentPage
    {
        

        public CartList()
        {
            InitializeComponent();
            pizzasListView.ItemsSource = App.Database.GetPizzas();
        }

        private void SortByNameButton_Clicked(object sender, System.EventArgs e)
        {
            pizzasListView.ItemsSource = App.Database.GetPizzas().OrderBy(pizza => pizza.Name).ToList();
            OnPropertyChanged(nameof(pizzasListView));
        }

        private void SortBySizeButton_Clicked(object sender, System.EventArgs e)
        {
            pizzasListView.ItemsSource = App.Database.GetPizzas().OrderBy(pizza => pizza.Size).ToList();
            OnPropertyChanged(nameof(pizzasListView));
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var pizzaId = ((TappedEventArgs)args).Parameter;
            Navigation.PushAsync(new PizzaDetailsPage { BindingContext = pizzaId });
        }
    }
}