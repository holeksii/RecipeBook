namespace RecipeBook.Data;

using RecipeBook.Models;
using Microsoft.EntityFrameworkCore;

public class RecipeBookDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Recipe> Recipes { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=RecipeBookDb;Username=postgres;Password=4");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(p => p.Username)
            .IsUnique(true);
    }
}
