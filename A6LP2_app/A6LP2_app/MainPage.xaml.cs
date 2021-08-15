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
        public Recipe Receita = Constants.SelectedRecipe;
        public IList<ViewIngredient> ViewIngredients;
        public List<RecipeIngredient> RecipeIngredients = Constants.RecipeIngredients;
        public MainPage()
        {
            InitializeComponent();
            FillRecipeData();
            UpdateServingsControls();
            txtComments.Text = Constants.RecipeComments.Count + " comentários";
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
            var recipeIngredients = RecipeIngredients;
            recipeIngredients.ForEach(item =>
            {
                item.UpdateMeasures(servings);
            });
            RecipeIngredients = recipeIngredients;
            ViewIngredients = FillIngredientData(RecipeIngredients);
            collectionIngredients.ItemsSource = ViewIngredients;
        }
        private void FillRecipeData()
        {
            receita_img.Source = Receita.ImgUrl;
            receita_title.Text = Receita.Name;
            receita_duration.Text = Receita.PrepDuration.ToString() + " min";
            receita_calories.Text = Receita.Calories.ToString() + " kcal";
            receita_rating.Text = Receita.Rating;
            receita_description.Text = Receita.Description;
        }
        private static List<ViewIngredient> FillIngredientData(List<RecipeIngredient> recipeIngredients)
        {
            var _ViewIngredients = new List<ViewIngredient>();
            foreach (var ingredient in Constants.Ingredients)
            {
                var description = recipeIngredients
                    .Where(ri => ri.Ingredient_ID == ingredient.ID)
                    .Select(ri => ri.MeasureDescription).FirstOrDefault();
                ViewIngredient _ingredient = new ViewIngredient(ingredient.Name, ingredient.ImgUrl, description);
                _ViewIngredients.Add(_ingredient);
            }
            return _ViewIngredients;
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
            NotImplementedAlert();
        }
        private void StepsTabTapped(object sender, EventArgs e)
        {
            gridRecipe_ingredients.BackgroundColor = (Color)Application.Current.Resources["BoxBg"];
            gridRecipe_steps.BackgroundColor = (Color)Application.Current.Resources["Destacado"]; 
            gridRecipe_tools.BackgroundColor = (Color)Application.Current.Resources["BoxBg"];
            tabTxt_ingredients.TextColor = Color.FromHex("#808080");
            tabTxt_steps.TextColor = Color.White;
            tabTxt_tools.TextColor = Color.FromHex("#808080");
            NotImplementedAlert();
        }
        private void NotImplementedAlert(object sender, EventArgs e)
        {
            DisplayAlert("Alerta", "Função não implementada!", "OK");
        }
        private void NotImplementedAlert()
        {
            DisplayAlert("Alerta", "Função não implementada!", "OK");
        }
        private List<Comment> LoadComments()
        {
            return new List<Comment>()
            {
                new Comment()
            };
        }
        private void ShowComments(object sender, EventArgs e)
        {
            CommentsPage.Comments = Constants.RecipeComments;
            var commentsPage = new CommentsPage();
            commentsPage.UpdateContext();
            MessagingCenter.Subscribe<WriteComment>(this, "Back", (writeSender) =>
            {
                txtComments.Text = Constants.RecipeComments.Count + " comentários";
            });
            Navigation.PushAsync(commentsPage);
        }
    }
}
