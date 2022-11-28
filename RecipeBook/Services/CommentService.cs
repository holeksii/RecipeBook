namespace RecipeBook.Services;
using System.Collections.Generic;
using RecipeBook.Data;
using RecipeBook.Models;

public class CommentService
{
    private RecipeBookDbContext _dbContext;

    public CommentService(RecipeBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Comment? AddComment(string text, long recipeId)
    {
        RecipeService recipeService = new RecipeService(_dbContext);
        Recipe? _recipe = recipeService.GetRecipe(recipeId);
        if (_recipe != null)
        {
            Comment comment = new Comment(text, DateTime.Now);
            _recipe.Comments.Add(comment);
            _dbContext.Recipes.Remove(_recipe);
            _dbContext.Recipes.Add(_recipe);
            return comment;
        }
        return null;
    }

    public List<Comment>? GetComments(Recipe recipe)
    {
        return _dbContext.Find<Recipe>(recipe.Id)?.Comments.ToList();
    }

    public Comment? GetComment(long id)
    {
        return _dbContext.Find<Comment>(id);
    }

    public Comment? DeleteComment(Comment comment)
    {
        if (_dbContext.Find<Comment>(comment.Id) != null)
        {
            _dbContext.Remove(comment);
            _dbContext.SaveChanges();
            return comment;
        }
        return null;
    }

    public Comment? UpdateComment(Comment comment)
    {
        if (_dbContext.Find<Comment>(comment.Id) != null)
        {
            _dbContext.Update(comment);
            _dbContext.SaveChanges();
            return comment;
        }
        return null;
    }
}
