using System;
using System.Collections.Generic;
using System.Text;

namespace A6LP2_app
{
    public class Recipe
    {
        public string Name { get; }
        public string ImgUrl { get; }        
        public string Description { get; }
        public string Rating { get; }
        public int Calories { get; }
        public int PrepDuration { get; }
        public List<Ingredient> Ingredients { get; set; }

        public Recipe()
        {
            Name = "Sanduíche mortadela c/ wafer";
            ImgUrl = "paomortadelawafer.jpg";
            Description = "Este sanduíche é simples, rápido de fazer e com um sabor peculiar e exótico, dada a combinação inusitada dos componentes que fazem a receita.";
            Rating = "1,9";
            Calories = 108;
            PrepDuration = 2;
            Ingredients = new List<Ingredient>()
            {
                new Ingredient(),
                new Ingredient(),
                new Ingredient(),
                new Ingredient()
            };
        }
        public Recipe(string name, string imgUrl, string description, string rating, int calories, int prepDuration)
        {
            Name = name;
            ImgUrl = imgUrl;
            Description = description;
            Rating = rating;
            Calories = calories;
            PrepDuration = prepDuration;
        }
    }
}
