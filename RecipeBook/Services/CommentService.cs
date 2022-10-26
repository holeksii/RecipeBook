namespace RecipeBook.Services;

using RecipeBook.Data;
using RecipeBook.Models;

public class CommentService
{
    private RecipeBookDbContext _dbContext;

    public CommentService(RecipeBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Comment AddComment(Comment comment, Recipe recipe)
    {
        Recipe? _recipe = _dbContext.Find<Recipe>(recipe.Id);
        if (_recipe != null)
        {
            _recipe.Comments.Add(comment);
            _dbContext?.Recipes?.Update(_recipe);
            _dbContext?.SaveChanges();
        }
        return comment;
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
