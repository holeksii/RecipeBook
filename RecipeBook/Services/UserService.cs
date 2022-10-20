namespace RecipeBook.Services;

using RecipeBook.Data;
using RecipeBook.Models;

public class UserService
{
    private RecipeBookDbContext _dbContext;

    public UserService(RecipeBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
