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
    public partial class ModifyCart : ContentPage
    {
        public ModifyCart()
        {
            InitializeComponent();
            pizzasListView.ItemsSource = App.Database.GetPizzas();
        }

        public List<Pizza> SelectedPizzas { get; set; }

        private List<Pizza> selectedPizzas = new List<Pizza>();

        private void Checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

            CheckBox checkbox = (CheckBox)sender;
            Pizza selectedPizza = (Pizza)checkbox.BindingContext;

            if (e.Value)
            {
                selectedPizzas.Add(selectedPizza);
            }
            else
            {
                selectedPizzas.Remove(selectedPizza);
            }
        }

        private void DeletePizzas(object sender, EventArgs e)
        {
            selectedPizzas.ForEach(pizza => { 
                App.Database.RemovePizza(pizza);
            });

            pizzasListView.ItemsSource = App.Database.GetPizzas();

            DisplayAlert("Warning", "The selected Pizzas Has been Deletes","Ok");
        }
    }
}