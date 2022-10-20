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

    public User AddUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return user;
    }

    public List<User>? GetUsers()
    {
        return _dbContext.Users.ToList();
    }

    public User? GetUser(long id)
    {
        return _dbContext.Find<User>(id);
    }

    public User? DeleteUser(User user)
    {
        if (_dbContext.Find<User>(user.Id) != null)
        {
            _dbContext.Remove(user);
            _dbContext.SaveChanges();

            return user;
        }
        return null;
    }

    public User? UpdateUser(User user)
    {
        if (_dbContext.Find<User>(user.Id) != null)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();

            return user;
        }
        return null;
    }
}
