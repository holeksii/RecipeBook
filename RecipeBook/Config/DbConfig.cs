using RecipeBook.Data;

namespace RecipeBook.Config;

public class DbConfig
{
    private static RecipeBookDbContext _dbContext = new RecipeBookDbContext();

    public RecipeBookDbContext GetDbContexzt()
    {
        return _dbContext;
    }

    private DbConfig()
    {
    }
}
