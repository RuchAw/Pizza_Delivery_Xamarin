using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
//using System.Collections.Generic;

namespace Pizza
{
    [Table("Carts")]
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Pizza> Pizzas { get; set; }
    }
}
