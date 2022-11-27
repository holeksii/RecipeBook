namespace RecipeBook.Services;
using RecipeBook.Data;
using RecipeBook.Models;

public class LikeService
{
    private RecipeBookDbContext _dbContext;

    public LikeService(RecipeBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Like? GetLike(long userId, long recipeId){
        return _dbContext.Set<Like>().FirstOrDefault(l => 
            l.User.Id == userId && l.Recipe.Id == recipeId);
    }

    public Like? AddLikeForUser(long userId)
    {
        User? user = _dbContext.Find<User>(userId);
        if (user != null)
        {
            Like like = new(DateTime.Now);
            user.Likes.Add(like);
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return like;
        }
        return null;
    }

    public Like? AddLikeForRecipe(long recipeId, long userId)
    {
        Recipe? recipe = _dbContext.Find<Recipe>(recipeId);
        if (recipe != null)
        {
            Like like = AddLikeForUser(userId);
            if(like != null)
            {
                recipe.Likes.Add(like);
                _dbContext.Recipes.Update(recipe);
                _dbContext.SaveChanges();
                return like;
            }
        }
        return null;
    }


    public Like? DeleteLikeForUser(long userId, long likeId)
    {
        User? user = _dbContext.Find<User>(userId);
        
        if (user != null)
        {
            Like? like = user.Likes.Find(l => l.Id == likeId);
            if (like != null)
            {
                user.Likes.Remove(like);
                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
                return like;
            }
        }
        return null;
    }

    public Like? DeleteLikeForRecipe(long recipeId, long likeId)
    {
        Recipe? recipe = _dbContext.Find<Recipe>(recipeId);
        if (recipe != null)
        {
            Like? like = recipe.Likes.Find(l => l.Id == likeId);
            if (like != null)
            {
                recipe.Likes.Remove(like);
                _dbContext.Recipes.Update(recipe);
                _dbContext.SaveChanges();
                return like;
            }
        }
        return null;
    }
}
