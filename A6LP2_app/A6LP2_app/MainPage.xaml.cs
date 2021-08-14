using A6LP2_app;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace A6LP2_app
{
    public partial class MainPage : ContentPage
    {
        int servings = 1;
        public Recipe Receita { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            FillRecipeData();
            Ingredients = Receita.Ingredients;

            UpdateServingsControls();
            BindingContext = this;
        }

        private void Servings_Minus(object sender, EventArgs e)
        {
            servings--;
            UpdateServingsControls();
        }

        private void Servings_Plus(object sender, EventArgs e)
        {
            servings++;
            UpdateServingsControls();
        }
        private void UpdateServingsControls()
        {
            _Servings.Text = servings.ToString();
            if (servings == 1)
            {
                btnServingsMinus.IsEnabled = false;
            }
            else if (servings == 15)
            {
                btnServingsPlus.IsEnabled = false;
            }
            else if (!btnServingsMinus.IsEnabled || !btnServingsPlus.IsEnabled)
            {
                btnServingsMinus.IsEnabled = true;
                btnServingsPlus.IsEnabled = true;
            }
            Ingredients.ForEach(item =>
            {
                item.UpdateMeasureMultiplier(servings);
            });
            
        }
        private void FillRecipeData()
        {
            Receita = new Recipe();
            receita_img.Source = Receita.ImgUrl;
            receita_title.Text = Receita.Name;
            receita_duration.Text = Receita.PrepDuration.ToString() + " min";
            receita_calories.Text = Receita.Calories.ToString() + " kcal";
            receita_rating.Text = Receita.Rating;
            receita_description.Text = Receita.Description;
        }

        private void IngredientsTabTapped(object sender, EventArgs e)
        {
            gridRecipe_ingredients.BackgroundColor = (Color)Application.Current.Resources["Destacado"];
            gridRecipe_steps.BackgroundColor = (Color)Application.Current.Resources["BoxBg"];
            gridRecipe_tools.BackgroundColor = (Color)Application.Current.Resources["BoxBg"];
            tabTxt_ingredients.TextColor = Color.White;
            tabTxt_steps.TextColor = Color.FromHex("#808080");
            tabTxt_tools.TextColor = Color.FromHex("#808080");
        }
        private void ToolsTabTapped(object sender, EventArgs e)
        {
            gridRecipe_ingredients.BackgroundColor = (Color)Application.Current.Resources["BoxBg"];
            gridRecipe_steps.BackgroundColor = (Color)Application.Current.Resources["BoxBg"];
            gridRecipe_tools.BackgroundColor = (Color)Application.Current.Resources["Destacado"];
            tabTxt_ingredients.TextColor = Color.FromHex("#808080");
            tabTxt_steps.TextColor = Color.FromHex("#808080");
            tabTxt_tools.TextColor = Color.White;
            DisplayAlert("Alerta", "Função não implementada!", "OK");
        }
        private void StepsTabTapped(object sender, EventArgs e)
        {
            gridRecipe_ingredients.BackgroundColor = (Color)Application.Current.Resources["BoxBg"];
            gridRecipe_steps.BackgroundColor = (Color)Application.Current.Resources["Destacado"]; 
            gridRecipe_tools.BackgroundColor = (Color)Application.Current.Resources["BoxBg"];
            tabTxt_ingredients.TextColor = Color.FromHex("#808080");
            tabTxt_steps.TextColor = Color.White;
            tabTxt_tools.TextColor = Color.FromHex("#808080");
            DisplayAlert("Alerta", "Função não implementada!", "OK");
        }
    }
}
