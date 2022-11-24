using RecipeBook.Data;

namespace RecipeBook.Config;

public class DbConfig
{
    private static RecipeBookDbContext _dbContext = new RecipeBookDbContext();

    public static RecipeBookDbContext GetDbContext()
    {
        return _dbContext;
    }

    private DbConfig()
    {
    }
}
