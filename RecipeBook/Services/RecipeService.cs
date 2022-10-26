namespace RecipeBook.Services;

using RecipeBook.Data;
using RecipeBook.Models;

public class RecipeService
{
    private RecipeBookDbContext _dbContext;

    public RecipeService(RecipeBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Recipe AddRecipe(Recipe recipe)
    {
        _dbContext.Recipes.Add(recipe);
        _dbContext.SaveChanges();
        return recipe;
    }

    public List<Recipe>? GetRecipes()
    {
        return _dbContext.Recipes.ToList();
    }

    public Recipe? GetRecipe(long id)
    {
        return _dbContext.Find<Recipe>(id);
    }

    public Recipe? DeleteRecipe(Recipe recipe)
    {
        if (_dbContext.Find<Recipe>(recipe.Id) != null)
        {
            _dbContext.Remove(recipe);
            _dbContext.SaveChanges();
            return recipe;
        }
        return null;
    }

    public Recipe? UpdateRecipe(Recipe recipe)
    {
        if (_dbContext.Find<Recipe>(recipe.Id) != null)
        {
            _dbContext.Update(recipe);
            _dbContext.SaveChanges();
            return recipe;
        }
        return null;
    }
}
