using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace A6LP2_app
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }        
        public string Description { get; set; }
        public string Rating { get; set; }
        public int Calories { get; set; }
        public int PrepDuration { get; set; }

        public Recipe()
        {
            
        }
    }
}
