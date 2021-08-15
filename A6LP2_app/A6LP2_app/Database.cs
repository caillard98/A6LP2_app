using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace A6LP2_app
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;
        public Database()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _database.CreateTableAsync<Recipe>().Wait();
            _database.CreateTableAsync<RecipeIngredient>().Wait();
            _database.CreateTableAsync<Ingredient>().Wait();
            _database.CreateTableAsync<Comment>().Wait();
        }
        public async Task WipeData()
        {
            await _database.QueryAsync<Recipe>("delete from Recipe");
            await _database.QueryAsync<Recipe>("DELETE FROM SQLITE_SEQUENCE WHERE name='Recipe'");
            await _database.QueryAsync<RecipeIngredient>("delete from RecipeIngredient");
            await _database.QueryAsync<RecipeIngredient>("DELETE FROM SQLITE_SEQUENCE WHERE name='RecipeIngredient'");
            await _database.QueryAsync<Ingredient>("delete from Ingredient");
            await _database.QueryAsync<Ingredient>("DELETE FROM SQLITE_SEQUENCE WHERE name='Ingredient'");
            await _database.QueryAsync<Comment>("delete from Comment");
            await _database.QueryAsync<Comment>("DELETE FROM SQLITE_SEQUENCE WHERE name='Comment'");
        }
        // Recipe
        public Task<List<Recipe>> GetRecipesAsync()
        {
            return _database.Table<Recipe>().ToListAsync();
        }
        public async Task<Recipe> SelectRecipeAsync(int recipeId)
        {
            var query = await _database.QueryAsync<Recipe>("select * from Recipe WHERE ID=?", recipeId);
            return query[0];
        }
        public Task<int> InsertRecipeAsync(Recipe recipe)
        {
            return _database.InsertAsync(recipe);
        }
        // Ingredient
        public Task<List<Ingredient>> GetIngredientsAsync()
        {
            return _database.Table<Ingredient>().ToListAsync();
        }
        public Task<List<Ingredient>> SelectIngredientsAsync(List<int> ids)
        {
            string _query = $"select * from Ingredient WHERE ID in ({string.Join(",", ids)})";
            var query = _database.QueryAsync<Ingredient>(_query);
            query.Wait();
            return query;
        }
        public Task<int> InsertIngredientAsync(Ingredient ingredient)
        {
            return _database.InsertAsync(ingredient);
        }
        // RecipeIngredient M..N
        public Task<List<RecipeIngredient>> GetIngredientsForRecipeAsync(int recipeId)
        {
            var query = _database.QueryAsync<RecipeIngredient>("select * from RecipeIngredient WHERE Recipe_ID=?", recipeId);
            query.Wait();
            return query;
        }
        public Task<int> InsertRecipeIngredient(RecipeIngredient ri)
        {
            return _database.InsertAsync(ri);
        }
        // Comment
        public Task<List<Comment>> GetCommentsForRecipeAsync(int recipeId)
        {
            var query = _database.QueryAsync<Comment>("select * from Comment WHERE Recipe_ID=?", recipeId);
            query.Wait();
            return query;
        }
        public Task<int> InsertCommentAsync(Comment comment)
        {
            var t = _database.InsertAsync(comment);
            t.Wait();
            return t;

        }
    }
}
