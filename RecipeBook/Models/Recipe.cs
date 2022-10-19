using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models;

class Recipe
{
    [Key]
    public long Id { get; set; }

    [MinLength(3)]
    [Required]
    public string? Name { get; set; }

    [Url]
    public string? ImageUrl { get; set; }

    public String? Category { get; set; }
}
