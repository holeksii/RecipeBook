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

    public Ingredient(string name, int quantity, string measure)
    {
        Name = name;
        Quantity = quantity;
        Measure = measure;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Quantity: {Quantity}, Measure: {Measure}";
    }
}
