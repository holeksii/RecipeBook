namespace RecipeBook.Services;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
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
        if (_dbContext.Find<Recipe>(recipeId) != null)
        {
            Comment comment = new Comment(text, DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc));
            _dbContext.Recipes.Include(r => r.Ingredients).Include(r => r.Likes).Include(
                r => r.Comments).Include(r=>r.User).FirstOrDefault(
                    r => r.Id==recipeId).Comments.Add(comment);
            _dbContext.SaveChanges();
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
