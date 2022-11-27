using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    public List<Ingredient> Ingredients { get; set; }
    public List<Like> Likes { get; set; }
    public List<Comment> Comments { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    public Recipe(string name, string imageUrl, string instructions, string category, int timeToCook)
    {
        Name = name;
        ImageUrl = imageUrl;
        Instructions = instructions;
        Category = category;
        TimeToCook = timeToCook;
        Ingredients = new List<Ingredient>();
        Likes = new List<Like>();
        Comments = new List<Comment>();
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, ImageUrl: {ImageUrl}, Instructions: {Instructions}, Category: {Category}, TimeToCook: {TimeToCook}";
    }
}
