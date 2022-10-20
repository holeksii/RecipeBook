namespace RecipeBook.Data;

using RecipeBook.Models;
using Microsoft.EntityFrameworkCore;

public class RecipeBookDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Recipe>? Recipes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=RecipeBookDb;Username=postgres;Password=4");
}
