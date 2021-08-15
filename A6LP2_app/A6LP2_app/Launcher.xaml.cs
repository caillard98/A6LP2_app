using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A6LP2_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Launcher : ContentPage
    {
        public Launcher()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // await App.Database.WipeData();
            var recipes = await App.Database.GetRecipesAsync();
            if(recipes.Count == 0)
            {
                await FirstLoading();
                recipes = await App.Database.GetRecipesAsync();
            }
            recipesView.ItemsSource = recipes;
        }
        private void RecipeTapped(object sender, SelectionChangedEventArgs e)
        {
            Recipe selectedRecipe = e.CurrentSelection.FirstOrDefault() as Recipe;
            UpdateConstantsWithSelectedRecipe(selectedRecipe).Wait();
            var recipePage = new MainPage();
            Navigation.PushAsync(recipePage);
        }
        private async Task UpdateConstantsWithSelectedRecipe(Recipe selectedRecipe)
        {
            Constants.SelectedRecipe = selectedRecipe;
            Constants.RecipeIngredients = await App.Database.GetIngredientsForRecipeAsync(selectedRecipe.ID);
            var ids = Constants.RecipeIngredients.Select(ri => ri.Ingredient_ID).ToList();
            Constants.Ingredients = await App.Database.SelectIngredientsAsync(ids);
            Constants.RecipeComments = await App.Database.GetCommentsForRecipeAsync(selectedRecipe.ID);
        }
        protected async Task FirstLoading()
        {
            await App.Database.InsertRecipeAsync(new Recipe
            {
                Name = "Pão Mortadela c/ Wafer",
                ImgUrl = "paomortadelawafer.jpg",
                Rating = "2,2",
                Calories = 220,
                Description = "Este sanduíche é simples, rápido de fazer e com um sabor peculiar e exótico, dada a combinação inusitada dos componentes que fazem a receita.",
                PrepDuration = 2
            });
            await App.Database.InsertRecipeAsync(new Recipe
            {
                Name = "Batata Burger",
                ImgUrl = "paocombatata.jpg",
                Rating = "3,7",
                Calories = 450,
                Description = "Um sanduíche tipicamente servido em jantares no Reino Unido e Irlanda. Este sanduíche simplíssimo coloca a batata frita dentro do pão de hamburguer, fazendo a refeição 2 em 1. Pode ser servido também com molhos dentro do sanduíche.",
                PrepDuration = 30
            });
            await App.Database.InsertRecipeAsync(new Recipe
            {
                Name = "Gelatina Panasonic",
                ImgUrl = "gelatinapanasonic.jpg",
                Rating = "1,1",
                Calories = 6800,
                Description = "É... Bem exótica! Isso sem contar o sabor, que é de matar!",
                PrepDuration = 90
            });
            await App.Database.InsertIngredientAsync(new Ingredient
            {
                Name = "Pão Frances",
                ImgUrl = "paofrances.jpg"
            });
            await App.Database.InsertIngredientAsync(new Ingredient
            {
                Name = "Mortadela",
                ImgUrl = "mortadela.jpg"
            });
            await App.Database.InsertIngredientAsync(new Ingredient
            {
                Name = "Wafer",
                ImgUrl = "wafer.jpg"
            });
            await App.Database.InsertIngredientAsync(new Ingredient
            {
                Name = "Batata",
                ImgUrl = "batata.jpg"
            });
            await App.Database.InsertIngredientAsync(new Ingredient
            {
                Name = "Pão Hamburger",
                ImgUrl = "paoburger.jpg"
            });
            await App.Database.InsertIngredientAsync(new Ingredient
            {
                Name = "Gelatina Tutti-Frutti",
                ImgUrl = "gelatinaazul.jpg"
            });
            await App.Database.InsertIngredientAsync(new Ingredient
            {
                Name = "Pilha Panasonic",
                ImgUrl = "pilhapanasonic.jpg"
            });
            await App.Database.InsertRecipeIngredient(new RecipeIngredient
            {
                Recipe_ID = 1,
                Ingredient_ID = 1,
                Measure = 1,
                MeasureDetail = "",
                MeasureDescription = "1"
            });
            await App.Database.InsertRecipeIngredient(new RecipeIngredient
            {
                Recipe_ID = 1,
                Ingredient_ID = 2,
                Measure = 1,
                MeasureDetail = " fatia",
                MeasureDescription = "1 fatia"
            });
            await App.Database.InsertRecipeIngredient(new RecipeIngredient
            {
                Recipe_ID = 1,
                Ingredient_ID = 3,
                Measure = 2,
                MeasureDetail = " bolachas",
                MeasureDescription = "2 bolachas"
            });
            await App.Database.InsertRecipeIngredient(new RecipeIngredient
            {
                Recipe_ID = 2,
                Ingredient_ID = 4,
                Measure = 150,
                MeasureDetail = "g",
                MeasureDescription = "150g"
            });
            await App.Database.InsertRecipeIngredient(new RecipeIngredient
            {
                Recipe_ID = 2,
                Ingredient_ID = 5,
                Measure = 1,
                MeasureDetail = "",
                MeasureDescription = "1"
            });
            await App.Database.InsertRecipeIngredient(new RecipeIngredient
            {
                Recipe_ID = 3,
                Ingredient_ID = 6,
                Measure = 1,
                MeasureDetail = " pacote",
                MeasureDescription = "1 pacote"
            });
            await App.Database.InsertRecipeIngredient(new RecipeIngredient
            {
                Recipe_ID = 3,
                Ingredient_ID = 7,
                Measure = 2,
                MeasureDetail = " AA",
                MeasureDescription = "2 AA"
            });
            await App.Database.InsertCommentAsync(new Comment
            {
                Recipe_ID = 3,
                Author = "Admin",
                Text = "Eu não aprovei a publicação disto...",
                DateString = "14/08/2021 13:45:21"
            });
        }
    }
}