using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pizza
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPizza : ContentPage
    {
        public AddPizza()
        {
            InitializeComponent();
        }

        string pizzaSize;
        string pizzaName;
        string pizzaImage;

        private void OnAddPizzaClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(villeEntry.Text) && !string.IsNullOrWhiteSpace(numeroEntry.Text) && !string.IsNullOrWhiteSpace(adresseEntry.Text))
            {
                switch (pizzaName)
                {
                    case "Pizza Margarita":
                        pizzaImage = "Pizza_Margarita.jpg";
                        break;

                    case "Pizza 4 fromage":
                        pizzaImage = "Pizza_4_fromage.jpg";
                        break;
                    case "Pizza Viande Hachée":
                        pizzaImage = "Pizza_Viande_Hache.jpg";
                        break;
                    case "Pizza au poulet":
                        pizzaImage = "Pizza_au_poulet.jpg";
                        break;
                    default:
                        break;
                }

                var pizza = new Pizza
                {
                    Name = pizzaName,
                    Size = pizzaSize,
                    Ville = villeEntry.Text,
                    Numero = numeroEntry.Text,
                    Adresse = adresseEntry.Text,
                    Image = pizzaImage

                };
                App.Database.AddPizza(pizza);

                villeEntry.Text = string.Empty;
                numeroEntry.Text = string.Empty;
                adresseEntry.Text = string.Empty;
                
                Navigation.PushAsync(new CartList());

                var pageToRemove = Navigation.NavigationStack.FirstOrDefault(p => p.GetType() == typeof(AddPizza));
                if (pageToRemove != null)
                {
                    Navigation.RemovePage(pageToRemove);
                }
            }
            else
            {
                DisplayAlert("Error", "Please enter valid pizza details.", "OK");
            }
        }

        private void Small_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            pizzaSize = "Small";
        }

        private void Medium_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            pizzaSize = "Medium";
        }

        private void Large_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            pizzaSize = "Large";
        }

        private void PizzaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PizzaName.SelectedIndex == -1)
            {
                pizzaName = "Pizza Margarita";
            }
            else
            {
                pizzaName = PizzaName.SelectedItem as string;
            }
        }
    }
}