using System;
using System.Collections.Generic;
using System.Text;

namespace A6LP2_app
{
    public class Ingredient
    {
        public string Name { get; }
        public string ImgUrl { get; }
        public double Measure { get; set; }
        public string MeasureDetail { get; set; }
        public string MeasureDescription { get; set; }
        public int MeasureMultiplier { get; set; }
        public Ingredient()
        {
            Name = "Pão Francês";
            ImgUrl = "paofrances.jpg";
            MeasureMultiplier = 1;
            Measure = 1;
            MeasureDescription = "1";
        }
        public Ingredient(string name, string imgUrl, double measure, string measureDetail="")
        {
            Name = name;
            ImgUrl = imgUrl;
            Measure = measure;
            MeasureDetail = measureDetail;
            MeasureDescription = measure.ToString() + measureDetail;
            MeasureMultiplier = 1;
        }
        public void SetMeasure(double measure, string measureDetail="")
        {
            Measure = measure;
            if(measureDetail != "")
            {
                MeasureDetail = measureDetail;
            }
            UpdateMeasureDescription();
        }
        public void UpdateMeasureMultiplier(int multiplier)
        {
            MeasureMultiplier = multiplier;
            UpdateMeasureDescription();
        }
        private void UpdateMeasureDescription()
        {
            double measure = Measure * MeasureMultiplier;
            
            MeasureDescription = measure.ToString((measure == (int)measure) ? "N0" : "N1") + MeasureDetail;
        }
    }
}
