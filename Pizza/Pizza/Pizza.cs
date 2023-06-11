using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Pizza
{
    [Table("pizzas")]
    public class Pizza
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Size { get; set; }

        public string Ville { get; set; }

        public string Numero { get; set; }

        public string Adresse { get; set; }

        public string Image { get; set; }

    }
}
