using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using SQLite;

namespace Pizza
{
    public class DatabaseHelper
    {
        SQLiteConnection database;

        public DatabaseHelper(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Pizza>();
        }

        public List<Pizza> GetPizzas()
        {
            return database.Table<Pizza>().ToList();
        }

        public void AddPizza(Pizza pizza)
        {
            database.Insert(pizza);
        }

        public void ModifyPizza(Pizza pizza)
        {
            database.Update(pizza);
        }

        public Pizza FindPizzaById(String id)
        {
            var foundPizza = database.Find<Pizza>(id);
            return foundPizza;
        }

        public void RemovePizza(Pizza pizza)
        {
            database.Delete(pizza);
        }

        public void RemoveCart()
        {
            database.DeleteAll<Pizza>();
        }
    }
}
