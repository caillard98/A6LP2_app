using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace A6LP2_app
{
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public Ingredient()
        {

        }
    }
}
