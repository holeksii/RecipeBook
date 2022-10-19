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
}
