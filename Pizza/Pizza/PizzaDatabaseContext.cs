using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Essentials;

namespace Pizza
{
    public partial class PizzaDatabaseContext
    {
        SQLiteConnection database;

        public PizzaDatabaseContext()
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "pizza.db");
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Cart>();
            database.CreateTable<Pizza>();
        }

        public List<Pizza> GetPizzas()
        {
            return database.Table<Pizza>().ToList();
        }

        public void AddToCart(Cart cart)
        {
            database.InsertWithChildren(cart, recursive: true);
        }

        public Cart GetCart()
        {
            return database.GetAllWithChildren<Cart>().FirstOrDefault();
        }
    }
}
