using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models;

public class User
{
    [Key]
    public long Id { get; set; }
    
    [MinLength(3)]
    [Required]
    public string? Username { get; set; }

    [EmailAddress]
    [Required]
    public string? Email { get; set; }

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")]
    public string? Password { get; set; }
    
    [Url]
    public string? ImageUrl { get; set; }

    public List<Recipe> Recipes { get; set; }
    public List<Like> Likes { get; set; }

    public User(string username, string email, string password, string imageUrl)
    {
        Username = username;
        Email = email;
        Password = password;
        ImageUrl = imageUrl;
        Recipes = new List<Recipe>();
        Likes = new List<Like>();
    }

    public override string ToString()
    {
        return $"User:Id: {Id}, Username: {Username}, Email: {Email}, Password: {Password}, ImageUrl: {ImageUrl}";
    }
}
