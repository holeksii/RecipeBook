namespace RecipeBook.Services;

using RecipeBook.Data;
using RecipeBook.Models;

public class IngredientService
{
    private RecipeBookDbContext _dbContext;

    public IngredientService(RecipeBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Ingredient? AddIngredient(Ingredient ingredient, long recipeId)
    {
        Recipe? recipe = _dbContext.Find<Recipe>(recipeId);
        if (recipe != null)
        {
            recipe.Ingredients.Add(ingredient);
            _dbContext.Recipes.Update(recipe);
            _dbContext.SaveChanges();
            return ingredient;
        }
        return null;
    }

    public List<Ingredient>? GetIngredients(long recipeId)
    {
        return _dbContext.Find<Recipe>(recipeId)?.Ingredients;
    }

    public Ingredient? DeleteIngredient(long recipeId, long ingredientId)
    {
        Recipe? recipe = _dbContext.Find<Recipe>(recipeId);
        if (recipe != null)
        {
            Ingredient? ingredient = _dbContext.Find<Ingredient>(ingredientId);
            if (ingredient != null)
            {
                recipe.Ingredients.Remove(ingredient);
                _dbContext.Recipes.Update(recipe);
                _dbContext.SaveChanges();
                return ingredient;
            }
        }
        return null;
    }

    public Ingredient? UpdateIngredient(long recipeId, Ingredient ingredient)
    {
        if (_dbContext.Find<Ingredient>(recipeId) != null)
        {
            _dbContext.Update(ingredient);
            _dbContext.SaveChanges();
            return ingredient;
        }
        return null;
    }
}
