using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace A6LP2_app
{
    public class RecipeIngredient
    {
        public int Ingredient_ID { get; set; }
        public int Recipe_ID { get; set; }
        public double Measure { get; set; }
        public string MeasureDetail { get; set; }
        public string MeasureDescription { get; set; }
        public RecipeIngredient()
        {

        }
        public void UpdateMeasures(int multiplier)
        {
            var n = (Measure * multiplier);
            MeasureDescription = (n == (int)n ? n.ToString("N0") : n.ToString("N1")) + MeasureDetail;
        }
    }
}
