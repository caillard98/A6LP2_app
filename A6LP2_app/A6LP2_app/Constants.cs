using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace A6LP2_app
{
    public static class Constants
    {
        public const string DatabaseFilename = "SQLite.db3";
        public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
        public static Recipe SelectedRecipe { get; set; }
        public static List<RecipeIngredient> RecipeIngredients { get; set; }
        public static List<Ingredient> Ingredients { get; set; }
        public static List<Comment> RecipeComments { get; set; }
    }
}
