namespace RecipeBook.Services;

using RecipeBook.Data;
using RecipeBook.Models;
using Microsoft.EntityFrameworkCore;
public class RecipeService
{
    private RecipeBookDbContext _dbContext;

    public RecipeService(RecipeBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Recipe AddRecipe(Recipe recipe, long userId)
    {
        var user = _dbContext.Find<User>(userId);
        user.Recipes.Add(recipe);
        _dbContext.SaveChanges();
        return recipe;
    }

    public List<Recipe>? GetRecipes()
    {
        return _dbContext.Recipes.Include(r => r.Ingredients).Include(r => r.Likes).Include(
            r => r.Comments).ToList();
    }

    public Recipe? GetRecipe(long id)
    {
        return _dbContext.Recipes.Include(r => r.Ingredients).Include(r => r.Likes).Include(
            r => r.Comments).FirstOrDefault(r => r.Id==id);
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
