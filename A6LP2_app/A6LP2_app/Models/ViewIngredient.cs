using System;
using System.Collections.Generic;
using System.Text;

namespace A6LP2_app
{
    public class ViewIngredient
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public ViewIngredient(string name, string imgUrl, string description) 
        {
            Name = name;
            ImgUrl = imgUrl;
            Description = description;
        }
    }
}
