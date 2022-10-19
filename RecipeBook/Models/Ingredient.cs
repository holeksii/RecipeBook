using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Models;

public class Ingredient
{
    [Key]
    public long Id { get; set; }
    
    [Required]
    [MinLength(3)]
    public string? Name { get; set; }
    
    [Required]
    [Range(0, 1000)]
    public int Quantity { get; set; }
    
    [RegularExpression(@"^(kg|g|l|ml|pcs)$")]
    public string? Measure { get; set; }
}
