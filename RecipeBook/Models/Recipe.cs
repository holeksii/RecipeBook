using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models;

public class Recipe
{
    [Key]
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string? Name { get; set; }

    [Url]
    public string? ImageUrl { get; set; }

    [Required]
    [MinLength(10)]
    public string Instructions { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    public string? Category { get; set; }

    [Range(1, 1000, ErrorMessage = "The value must be between 1 and 1000")]
    public int TimeToCook { get; set; }

    [Required]
    public List<Ingredient>? Ingredients { get; set; }
    public List<Like>? Likes { get; set; }
    public List<Comment>? Comments { get; set; }
}
